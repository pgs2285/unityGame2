using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class getItem : MonoBehaviour
{
    public GameObject light2DSprite;
    public void Get(){
        Debug.Log(gameObject.name);
        try{
            Inventory.instance.AddItem(Resources.Load<Item>("Item/" + gameObject.name),1);
            GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
            GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = gameObject.name;
            GameObject.Find("ItemImage").GetComponent<Image>().sprite = Resources.Load<Item>("Item/" + gameObject.name).itemIcon;
        }catch{
            Debug.Log("Item not found");
        }
        switch(gameObject.name){


            case "goldRecipe(Clone)":
                RecipeSystem.Instance.recipeList.Add(Resources.Load("Item/goldRecipe") as RecipePrefabs);
                GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
                GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = "goldRecipe";
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            break;

            case "flashlight":
                light2DSprite.SetActive(true);
                GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
                GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = "flashlight";
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            break;

            case "BearStone(Clone)":
                Inventory.instance.AddItem(Resources.Load<Item>("Item/BearStone"),1);
                GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
                GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = "BearStone";
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            break;
            case "BearStone":
                Inventory.instance.AddItem(Resources.Load<Item>("Item/BearStone"),1);
                GameObject.Find("ItemPanel").GetComponent<Animator>().SetBool("state",true);
                GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = "BearStone";
                GameObject.Find("ItemImage").GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            break;
        }
        Destroy(gameObject);
    }
}
