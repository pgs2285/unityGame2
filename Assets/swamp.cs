using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swamp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        CharacterData.Instance.Speed -= 1f;   
    }
    private void OnTriggerExit2D(Collider2D other) {
        CharacterData.Instance.Speed += 1f;
    }
}
