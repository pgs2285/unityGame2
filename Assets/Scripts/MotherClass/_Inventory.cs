using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Inventory : Singleton<_Inventory>
{
    public GameObject InventoryPanel;
    public GameObject InventoryInfo;
    // public GameObject UIPanel;
    bool activeInventory = false;
    // public GameObject InventoryInfo;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            activeInventory = !activeInventory;
            InventoryPanel.SetActive(activeInventory);
            InventoryInfo.SetActive(activeInventory);

            // InventoryInfo.SetActive(activeInventory);
            // UIPanel.SetActive(!activeInventory);
            CharacterData.Instance.IsMove = !activeInventory;
        }
    }
}
