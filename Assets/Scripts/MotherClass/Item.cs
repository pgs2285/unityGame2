using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
 
    public String itemName;
    public int itemId;
    public sprite itemImage;

    public bool Use(){
        return false; // 아이템의 사용여부 반환
    }

}
