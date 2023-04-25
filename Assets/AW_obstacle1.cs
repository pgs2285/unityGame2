using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AW_obstacle1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 dirVec = new Vector2(0,0);
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        if(transform.localEulerAngles.z == 90) dirVec = new Vector2(1,0);
        else if(transform.localEulerAngles.z == 180) dirVec = new Vector2(0,1);
        else if(transform.localEulerAngles.z == 270) dirVec = new Vector2(-1,0);
        else if(transform.localEulerAngles.z == 0) dirVec = new Vector2(0,-1);

    }   
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, 1f, LayerMask.GetMask("Player")); 
        Debug.DrawRay(transform.position, dirVec* 1f, new Color(0,1,0));   
        if(rayHit.collider !=null){
            anim.SetBool("attack", true);
            //공격발싸
        }
    }

    public GameObject bulletPrefab;  // 쏘고자 하는 object 프리팹
    public Transform firePoint;  // 발사 위치
    public string playerTag;  // 플레이어 태그
    public float bulletSpeed = 8f;  // 총알 속도
    public void animeReset(){
        anim.SetBool("attack", false);
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            Vector3 targetPos = player.transform.position;
            targetPos.z = 0f;

            Vector3 fireDirection = targetPos - firePoint.position;
            fireDirection.z = 0f;
                            // rotation 값을 계산
            float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position,rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = fireDirection.normalized * bulletSpeed;

            Destroy(bullet, 2f);  // 총알이 화면 밖으로 나가면 자동으로 삭제
        }
    }
}
