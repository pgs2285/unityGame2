using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBossStageEntrance : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    Vector3 Target;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Target = new Vector3(player.transform.position.x, player.transform.position.y + 16f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        while(Vector3.Distance(player.transform.position, Target) < 0.1f){
            player.transform.position = Vector3.Lerp(player.transform.position, Target, 0.1f);
        }
    }
}
