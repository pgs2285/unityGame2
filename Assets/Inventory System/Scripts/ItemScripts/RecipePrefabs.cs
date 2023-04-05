using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "Item/Recipe")]
public class RecipePrefabs : Item
{
    public Item[] ingredients;

    public override void Use()
    {
        base.Use();

        //Use Resource

        //Use the following line if you want to destroy this type of item after use
        // Inventory.instance.RemoveItem(this, 1);
    }

    
}

