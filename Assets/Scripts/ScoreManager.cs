using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int g_IntPlayerScore ;

    [SerializeField]
    Text g_ScoreText ;

    void Awake()
    {
        g_IntPlayerScore = 0 ;
        g_ScoreText.text = g_IntPlayerScore.ToString();
    }

    public void m_ManagePlayerScore ()
    {
        g_IntPlayerScore++ ;
        g_ScoreText.text = g_IntPlayerScore.ToString();
        PlayerPrefs.SetInt("PlayerScore", g_IntPlayerScore);
    }
}
