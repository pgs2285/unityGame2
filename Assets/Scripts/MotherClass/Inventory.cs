using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryPanel;
    // public GameObject UIPanel;
    bool activeInventory = false;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            activeInventory = !activeInventory;
            InventoryPanel.SetActive(activeInventory);
            // UIPanel.SetActive(!activeInventory);
        }
    }
}
