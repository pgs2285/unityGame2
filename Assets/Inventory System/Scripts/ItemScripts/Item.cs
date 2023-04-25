
using UnityEngine;


// BASE ITEM
public class Item : ScriptableObject
{
    public string itemName;

    // The ID of every Item needs to be different in order to be saved and loaded 
    public int ID;

    // The price of an item can be used to set up a shop
    public int price;

    // If you want an item to be stackable, set this bool True
    public bool Stackable;

    // The UI icon of the item 
    public Sprite itemIcon;

    public string Description;
    
    public virtual void Use()
    {

        Debug.Log(ID);
        switch (ID)
        {
            case 2:
                CharacterData.Instance.Hungry += 5;
                break;
            case 10: // TutorialApple
                CharacterData.Instance.Hungry += 5;
                if(CharacterData.Instance.QuestID == 30){
                    CharacterData.Instance.QuestID += 10;
                }
                break;
            case 30:
                CharacterData.Instance.Hungry += 30;
                break;
            case 40:
                CharacterData.Instance.Hungry += 2;

                break;
        }
        Inventory.instance.RemoveItem(this, 1);
    }
}
