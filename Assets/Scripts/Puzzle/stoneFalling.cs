using UnityEngine;

public class stoneFalling : MonoBehaviour
{
    // Throw stone animation event
    public void OnThrowStone(AnimationEvent animEvent)
    {
        // Call function to throw a stone
        Throw();
    }

    // Function to throw a stone
    public GameObject rockPrefab; // 던질 돌 프리팹
    public Transform shootPoint; // 돌이 생성될 위치
    public float shootForce; // 돌을 던질 힘
    private void Throw()
    {
        GameObject rock = Instantiate(rockPrefab, shootPoint.position, Quaternion.identity); // 돌 오브젝트 생성
        Rigidbody2D rockRb = rock.GetComponent<Rigidbody2D>();
        rockRb.AddForce(transform.forward * shootForce, ForceMode2D.Impulse); // 돌을 발사
    
    }
}
