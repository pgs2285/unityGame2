using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Hp = 100;
    public float currentHp=100;

    Rigidbody2D rigidbody2d;
    private float curtime;
    public float cooltime;
    public void TakeDamage(float damage)
    {
        this.GetComponent<Animator>().SetTrigger("hit");
        currentHp = currentHp - damage;
        // HpbarFilled.fillAmount = (float)currentHp / Hp;
        // HpbarBackground.SetActive(true);

        hpBar.GetChild(0).GetComponent<Image>().fillAmount = currentHp / Hp;
        
    }
    
    public GameObject prfHPBar;
    public GameObject canvas;
    RectTransform hpBar;
    public GameObject prfHpBar;

    public SpawnManager spawnManager;
    void Start()
    {
        currentHp = Hp;
        prfHpBar = Instantiate(prfHPBar, canvas.transform);
        hpBar = prfHpBar.GetComponent<RectTransform>();
        spawnManager = GameObject.Find("enemySpawn").GetComponent<SpawnManager>();
    }

    public float height;
    private void Awake() {
        canvas = GameObject.Find("UI");
    }
    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * height);
        hpBar.position = _hpBarPos;
        if (currentHp <= 0)
        {

            Destroy(prfHpBar.gameObject);
            Destroy(gameObject);


        }


    }
    public void OnDestroy(){

            int random = Random.Range(0, 100);
            if(gameObject.name == "bear_enermy_canKill(Clone)"){
                Debug.Log("bear_enermy_canKill");
                if(random < 40){ //30% 확률로 키 드랍
                    if(!RecipeSystem.Instance.recipeList.Contains(Resources.Load("Prefab/goldRecipe")as RecipePrefabs)){
                        Instantiate(Resources.Load("Prefab/goldRecipe"), transform.position, Quaternion.identity);
                    }

                }
            }
            else if(gameObject.name == "bearStone"){
                    Instantiate(Resources.Load("Prefab/BearStone"), transform.position, Quaternion.identity);
            }
            spawnManager.EnemyCount--;
    }
    void hitReset(){
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-70, 0));
    }

    void nuckback(){
        GetComponent<Rigidbody2D>().AddForce(new Vector2(70, 0));
    }
}
