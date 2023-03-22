using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portalManager : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("4.Mob");
        }
        if(this.gameObject.name.ToString() == "CavePortal")
        {
            if (collision.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene("3.cutTreeVillage");
        
            }
        }
    }
}
