using UnityEngine;
using UnityEngine.UI;
public class HungrySystem : MonoBehaviour
{
    // Start is called before the first frame update
    private int MaxHugnry = 100;
    public int decreaseInterval = 60;
    public Slider hungryBar;
    private float timeElapsed = 0f;
    void Start()
    {
        hungryBar.maxValue = MaxHugnry;
    }

    // Update is called once per frame
    void Update()
    {
        hungryBar.value = CharacterData.instance.Hungry;

        timeElapsed += Time.deltaTime;

        if(timeElapsed >= decreaseInterval)
        {
            CharacterData.instance.Hungry -= 2; // 일정시간마다 2씩 감소
            hungryBar.value = CharacterData.instance.Hungry;

            timeElapsed = 0f;
        }
    }
}
