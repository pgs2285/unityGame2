using System.Collections.Generic;
using UnityEngine;

public class aiscript : MonoBehaviour
{
    public Transform player;            // 추적할 플레이어의 Transform
    public float speed = 5f;            // AI의 이동 속도
    public float avoidDistance = 2f;    // 장애물을 피하기 위한 거리
    public float avoidForce = 5f;       // 장애물 피하기 위한 힘
    public LayerMask obstacleLayer;     // 장애물 레이어
    public float updatePathInterval = 0.5f;  // 경로 업데이트 간격

    private Rigidbody2D _rigidbody;         // AI의 Rigidbody2D
    private List<Vector2> _path;            // AI가 따라갈 경로
    private int _currentWaypointIndex = 0;  // AI가 따라가고 있는 경로의 인덱스
    private bool _isUpdatingPath = false;   // 경로 업데이트 중인지 여부

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _path = new List<Vector2>();
        InvokeRepeating("UpdatePath", 0f, updatePathInterval);
    }

    void FixedUpdate()
    {
        if (_path.Count > 0)
        {
            // 다음 목표 위치로 이동
            Vector2 targetPosition = _path[_currentWaypointIndex];
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            _rigidbody.velocity = moveDirection * speed * Time.fixedDeltaTime;

            // 다음 목표 위치까지 도착하면 인덱스 증가
            float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
            if (distanceToTarget < 0.1f)
            {
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= _path.Count)
                {
                    _path.Clear();
                    _currentWaypointIndex = 0;
                }
            }
        }
    }

    void UpdatePath()
    {
        if (_isUpdatingPath) return;
        _isUpdatingPath = true;

        // 목표 위치 설정
        Vector2 targetPosition = player.position;

        // 시작 위치와 목표 위치 사이에 있는 모든 장애물과 벽을 가져옴
        List<Vector2> obstacles = new List<Vector2>();
        Vector2 startPosition = transform.position;
        RaycastHit2D[] hits = Physics2D.LinecastAll(startPosition, targetPosition, obstacleLayer);
        foreach (RaycastHit2D hit in hits)
        {
            obstacles.Add(hit.point);
        }
        obstacles.Add(targetPosition);

        // A* 알고리즘을 사용하여 가장 짧은 경로를 찾음
        _path = AStar(startPosition, targetPosition, obstacles);

        // 경로 업데이트 완료
        _isUpdatingPath = false;
    }

    List<Vector2> AStar(Vector2 startPosition, Vector2 targetPosition, List<Vector2> obstacles)
    {
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        Node startNode = new Node(startPosition, null, 0f, Vector2.Distance(startPosition, targetPosition));
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost ||
                    (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (Vector2.Distance(currentNode.position, targetPosition) < 0.1f)
            {
                // 목표 위치에 도착함
                return GetPath(currentNode);
            }

            foreach (Vector2 obstacle in obstacles)
            {
                if (Vector2.Distance(currentNode.position, obstacle) < avoidDistance)
                {
                    // 장애물을 피해 이동하는 경로를 계산함
                    Vector2 avoidForceVector = (currentNode.position - obstacle).normalized * avoidForce;
                    Vector2 newNodePosition = currentNode.position + avoidForceVector * Time.fixedDeltaTime;
                    Node newNode = new Node(newNodePosition, currentNode, currentNode.gCost + Vector2.Distance(currentNode.position, newNodePosition), Vector2.Distance(newNodePosition, targetPosition));

                    if (closedSet.Contains(newNode)) continue;

                    float newFCost = newNode.gCost + newNode.hCost;
                    if (newFCost < currentNode.fCost || !openSet.Contains(newNode))
                    {
                        openSet.Add(newNode);
                    }
                }
            }
        }

        // 경로를 찾지 못함
        return new List<Vector2>();
    }

    List<Vector2> GetPath(Node endNode)
    {
        List<Vector2> path = new List<Vector2>();
        Node currentNode = endNode;
        while (currentNode != null)
        {
            path.Add(currentNode.position);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        return path;
    }

    class Node
    {
        public Vector2 position;
        public Node parent;
        public float gCost;
        public float hCost;
        public float fCost { get { return gCost + hCost; } }

        public Node(Vector2 position, Node parent, float gCost, float hCost)
        {
            this.position = position;
            this.parent = parent;
            this.gCost = gCost;
            this.hCost = hCost;
        }
    }
}
