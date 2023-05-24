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
    Enermy_Ai enermy_Ai;
    public void TakeDamage(float damage)
    {
        if(gameObject.name == "Fences"){
            if(CharacterData.Instance.QuestID != 50) return;
        
        }
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
        enermy_Ai = GetComponent<Enermy_Ai>();
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

    
    void nuckback(){
        knockBackCoroutine = StartCoroutine(Knockback(0.5f, 2));
    }

    public IEnumerator Knockback(float dur, float power)
    {
        float cTime = 0;
        while(cTime < dur){
            if(transform.rotation.y == 0){
                Debug.Log("KnockBackposition : LEFT");
                transform.Translate(Vector2.left * power * Time.deltaTime);
                enermy_Ai.key_ai = 0;
                enermy_Ai.nav.velocity = Vector2.zero;
            }else{
                Debug.Log("KnockBackposition : RIGHT");
                transform.Translate(new Vector2(-1,0) * power * Time.deltaTime);
                enermy_Ai.key_ai = 0;
                enermy_Ai.nav.velocity = Vector2.zero;
            }
            cTime += Time.deltaTime;
            yield return null;
            
        }
        enermy_Ai.key_ai = 1;
        yield return null;
    }

    Coroutine knockBackCoroutine;
}
