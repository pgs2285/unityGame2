using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reGen());
    }


    IEnumerator reGen(){
        while(true){
            yield return new WaitForSeconds(60f);
            int num = gameObject.transform.childCount;
            for(int i = 0; i < num; i++){
                gameObject.transform.GetChild(i).gameObject.GetComponent<RandomIngredient>().SetItemObtain();
            }
        }
    }
}
