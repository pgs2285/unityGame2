using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeTestSlot : Singleton<RecipeTestSlot>
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Inventory.instance.itemList[0]);
        Debug.Log(Inventory.instance.quantityList[0]);
    }
}
