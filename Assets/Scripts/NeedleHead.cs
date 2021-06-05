using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedleHead : MonoBehaviour
{
    void OnTriggerEnter2D ( Collider2D trigger )
    {
        if ( trigger.CompareTag("NeedleHead") )
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
