using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    float g_FloatMinMovementSpeed ;
    float g_FloatMaxMovementSpeed ;
    
    float g_FloatRotationSpeed ;

    float g_FloatAngle ;
    
    float g_FloatMinWaitTime ;
    float g_FloatMaxWaitTime ;

    // Start is called before the first frame update
    void Start()
    {
        g_FloatMinMovementSpeed = 50.0f ;
        g_FloatMaxMovementSpeed = 100.0f ;

        g_FloatMinWaitTime = 8.0f ;
        g_FloatMaxWaitTime = 12.0f ;

        g_FloatRotationSpeed = -75.0f ;
        g_FloatAngle = 0.0f ;
        StartCoroutine ( m_ChangeSpeedOfCircle () ) ;
        StartCoroutine ( m_ChangeDirectionOfCircle () ) ;
    }

    // Update is called once per frame
    void Update()
    {
        m_RotateCircle () ;
    }

    void m_RotateCircle ()
    {
        g_FloatAngle = this.transform.eulerAngles.z ;
        g_FloatAngle += g_FloatRotationSpeed * Time.deltaTime ;
        this.transform.rotation = Quaternion.Euler ( 0.0f , 0.0f , g_FloatAngle ) ; 
    }

    IEnumerator m_ChangeSpeedOfCircle ()
    {
        float l_FloatWaitTime = Random.Range ( g_FloatMinWaitTime , g_FloatMaxWaitTime ) ;
        yield return new WaitForSeconds( l_FloatWaitTime );
        g_FloatRotationSpeed = Random.Range( g_FloatMinMovementSpeed , g_FloatMaxMovementSpeed );
        StartCoroutine ( m_ChangeSpeedOfCircle () ) ;
    }

    IEnumerator m_ChangeDirectionOfCircle ()
    {
        float l_FloatWaitTime = Random.Range ( g_FloatMinWaitTime , g_FloatMaxWaitTime ) ;
        yield return new WaitForSeconds( l_FloatWaitTime );
        g_FloatRotationSpeed *= -1.0f ;
        StartCoroutine ( m_ChangeDirectionOfCircle () ) ;
    }
}
