using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTalk : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed;
    public Animation animation;
    public string animationName;
    public string dialogue;

    private bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(1f);

        // Move character across the screen
        while (character.transform.position.x < 10f)
        {
            character.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }

        // Play animation
        animation.Play(animationName);

        // Display dialogue
        Debug.Log(dialogue);

        isPlaying = false;
    }
}
