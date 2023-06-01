
using UnityEngine;


// BASE ITEM
public class Item : ScriptableObject
{
    private GameObject fox;
    private QuestManager questManager;

    
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
                    fox = GameObject.Find("FOX");
                    questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
                    CharacterData.Instance.QuestID += 10;
                    Destroy(questManager.questState);
                    questManager.questState = Instantiate(Resources.Load("QuestState/QuestStartOrEnd") as GameObject, new Vector2(fox.transform.position.x + 0.5f, fox.transform.position.y +0.8f), Quaternion.identity);
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
