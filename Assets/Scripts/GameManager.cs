using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject g_GameManager ;

    [SerializeField] GameObject g_Needle ;
    Button g_ShootButton ;

    Vector3 g_NeedleOrigin ;

    GameObject g_LoadedNeedle ;

    void Awake ()
    {
        g_ShootButton = GameObject.Find ("ShootButton").GetComponent<Button>() ; 
        g_ShootButton.onClick.AddListener( () => m_ShootNeedle() ) ;
    }

    // Start is called before the first frame update
    void Start()
    {
        g_NeedleOrigin = new Vector3 ( 0.0f , -4.0f , 0.0f );
        g_LoadedNeedle = Instantiate( g_Needle , g_NeedleOrigin , Quaternion.identity) ;
    }

    public void m_ShootNeedle ()
    {
        // first shoot the needle 
        g_LoadedNeedle.GetComponent<NeedleMovement>().m_ShootNeedle();

        // instantiate the needle in the place of old needle 
        g_LoadedNeedle = Instantiate( g_Needle , g_NeedleOrigin , Quaternion.identity) ;
    }
}
