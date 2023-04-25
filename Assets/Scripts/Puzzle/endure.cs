using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endure : MonoBehaviour
{
    public void resetAnime()
    {
        GetComponent<Animator>().SetBool("reduce", false);

    }
}
