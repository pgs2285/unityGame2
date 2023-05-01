using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soundController : Singleton<soundController>
{
    // Start is called before the first frame update
    AudioSource backgroundMusic;
    AudioClip bgm;
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        BGMChanger();    
 

    }

    void BGMChanger(){
        switch(SceneManager.GetActiveScene().name)
        {
            case "-1.MainMenu 1":
                bgm = Resources.Load<AudioClip>("BGMController/1MainMenu");
                backgroundMusic.clip = bgm;
                backgroundMusic.Play();
            break;

            case "0.StartMap":
                backgroundMusic.Stop();
                break;

            case "1.Tutorial":
                bgm = Resources.Load<AudioClip>("BGMController/TutorialStage");
                backgroundMusic.clip = bgm;
                backgroundMusic.Play();
            break;

            case "2.Demo 1":
                bgm = Resources.Load<AudioClip>("BGMController/brightCave");
                backgroundMusic.clip = bgm;
                backgroundMusic.Play();
                break;


        }
    }
    bool changeMusic = true;
    string sceneName;
    // Update is called once per frame
    void Update()
    {

        if(changeMusic){
            sceneName = SceneManager.GetActiveScene().name;
            changeMusic = false;
        }
        if(sceneName != SceneManager.GetActiveScene().name){
            BGMChanger();
            changeMusic = true;
        }

    }
}
