using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D g_Rigidbody ;
    [SerializeField] BoxCollider2D g_BoxCollider ;
    [SerializeField] CircleCollider2D g_CircleCollider ;
    [SerializeField] GameObject g_NeedleBody ;

    bool g_BoolCanShootNeedle ;
    bool g_BoolHasTouchedCircle ;

    float g_FloatMoveSpeed ;

    [SerializeField] ScoreManager g_ScoreManager ;
    
    void Awake ()
    {
        g_ScoreManager = GameObject.Find ( "PlayerScore") .GetComponent<ScoreManager>();
        g_Rigidbody = this.GetComponent<Rigidbody2D>();
        g_BoxCollider = this.GetComponent<BoxCollider2D>();
        g_CircleCollider = this.GetComponentInChildren<CircleCollider2D>();
        g_NeedleBody = this.gameObject.transform.GetChild(0).gameObject ;
    }

    // Start is called before the first frame update
    void Start()
    {
        g_CircleCollider.enabled = false;

        g_FloatMoveSpeed = 6.0f ;
    }

    void FixedUpdate()
    {
        m_MoveNeedle () ;
    }

    void m_MoveNeedle ()
    {
        if ( !g_BoolCanShootNeedle ) return ;

        Vector3 l_NeedleMovement = this.transform.position ;
        l_NeedleMovement += Vector3.up * g_FloatMoveSpeed * Time.fixedDeltaTime ;
        g_Rigidbody.MovePosition ( l_NeedleMovement ) ;
    }

    public void m_ShootNeedle ()
    {
        g_NeedleBody.SetActive(true);
        g_BoolCanShootNeedle = true ;
        g_BoxCollider.enabled = true ;
    }

    void OnTriggerEnter2D ( Collider2D trigger )
    {

        if ( g_BoolHasTouchedCircle ) return ;

        if ( trigger.gameObject.CompareTag ( "Circle") )
        {
            g_CircleCollider.enabled = true ;

            g_BoolHasTouchedCircle = true ;
            g_BoolCanShootNeedle = false ;
            this.transform.SetParent ( trigger.transform ) ;

            g_ScoreManager.m_ManagePlayerScore () ;
        }
    }
}
