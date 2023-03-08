using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct moveInfo{ 

    public bool isMove;
    public bool loadScene;
    
    public GameObject npcID;
    public string direction;
    public float figure; 
    public float speed;
    public float Delay;
    public string[] context;
    public Animation animation;
    public string LoadScene;
    
}

public class secondCutScene : MonoBehaviour
{
    [SerializeField]
    public moveInfo[] mvInfo;

    Animation anim;

    private void Start(){

        CharacterData.Instance.IsMove = false;
        if (mvInfo[0].isMove) StartCoroutine(move(0));
        else StartCoroutine(talk(0));
        
    }

    Vector3 targetVector;
    IEnumerator move(int index){
        yield return new WaitForSeconds(mvInfo[index].Delay);
        if (mvInfo[index].animation != null) mvInfo[index].animation.Play();
        bool checkMove = true;
        mvInfo[index].npcID.SetActive(true);
        switch(mvInfo[index].direction){
            case "UP":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.y += mvInfo[index].figure;
            break;

            case "DOWN":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.y -= mvInfo[index].figure;
            break;
            
            case "LEFT":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.x -= mvInfo[index].figure;
            break;

            case "RIGHT":
            targetVector = mvInfo[index].npcID.transform.position;
            targetVector.x += mvInfo[index].figure;
            break;

            case "flipLEFT":
            mvInfo[index].npcID.transform.eulerAngles = new Vector3(0, 180, 0);
            checkMove = false;
            break;

            case "flipRIGHT":            
            mvInfo[index].npcID.transform.eulerAngles = new Vector3(0, 0, 0);
            checkMove = false;
            break;
        }
        
        while(Mathf.Abs(Vector3.Distance(targetVector, mvInfo[index].npcID.transform.position)) > 0.001f && checkMove){ // 근접시
            
            Debug.Log(Vector3.Distance(targetVector, mvInfo[index].npcID.transform.position));
            mvInfo[index].npcID.transform.position = Vector3.MoveTowards(mvInfo[index].npcID.transform.position, targetVector, mvInfo[index].speed);     
            yield return new WaitForSeconds(0.00001f); // return을 통해 Scene에 진행과정 보이게함
        
        }
        
        index += 1;
        if(index < mvInfo.Length)
        {
            if (mvInfo[index].loadScene) { SceneManager.LoadScene(mvInfo[index].LoadScene); CharacterData.Instance.IsMove = true; }
            if (mvInfo[index].isMove) StartCoroutine(move(index));
            else if(!mvInfo[index].isMove) StartCoroutine(talk(index));

        }
        else
        {
            CharacterData.Instance.IsMove = true;
        }
    }

    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    GameObject chatPanel;
    IEnumerator flipleft(int index){
        yield return new WaitForSeconds(mvInfo[index].Delay);
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
    IEnumerator flipright(int index){
        yield return new WaitForSeconds(mvInfo[index].Delay);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    IEnumerator talk(int index){
        yield return new WaitForSeconds(mvInfo[index].Delay);
        int textIndex = 0;
        while(mvInfo[index].context.Length > textIndex){

            chatPanel.SetActive(true);
            text.text = mvInfo[index].context[textIndex];
            if(Input.GetKeyDown(KeyCode.Space)) textIndex++;
            yield return new WaitForSeconds(0.001f);
        }

        chatPanel.SetActive(false);

        index += 1;
        if(index < mvInfo.Length)
        {
            if (mvInfo[index].loadScene) { SceneManager.LoadScene(mvInfo[index].LoadScene); CharacterData.Instance.IsMove = true; }
            if (mvInfo[index].isMove) StartCoroutine(move(index));
            else if(!mvInfo[index].isMove) StartCoroutine(talk(index));
        }
        else
        {
            CharacterData.Instance.IsMove = true;
        }
    }
    
}


/*





1.  using UnityEngine;
2.  using UnityEngine.UI;
3.  
4.  #if UNITY_EDITOR
5.  using UnityEditor;
6.  #endif
7.  
8.  public class RandomScript : MonoBehaviour
9.  {
10.      [HideInInspector] // HideInInspector makes sure the default inspector won't show these fields.
11.      public bool StartTemp;
12.  
13.      [HideInInspector]
14.      public InputField iField;
15.  
16.      [HideInInspector]
17.      public GameObject Template;
18.  
19.      // ... Update(), Awake(), etc
20.  }
21.  
22.  #if UNITY_EDITOR
23.  [CustomEditor(typeof(RandomScript))]
24.  public class RandomScript_Editor : Editor
25.  {
26.      public override void OnInspectorGUI()
27.      {
28.          DrawDefaultInspector(); // for other non-HideInInspector fields
29.  
30.          RandomScript script = (RandomScript)target;
31.  
32.          // draw checkbox for the bool
33.          script.StartTemp = EditorGUILayout.Toggle("Start Temp", script.StartTemp);
34.          if (script.StartTemp) // if bool is true, show other fields
35.          {
36.              script.iField = EditorGUILayout.ObjectField("I Field", script.iField, typeof(InputField), true) as InputField;
37.              script.Template = EditorGUILayout.ObjectField("Template", script.Template, typeof(GameObject), true) as GameObject;
38.          }
39.      }
40.  }
41.  #endif


// 커스텀 에디터 example





*/
