using Unity.XR.CoreUtils;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Timer;
    bool m_InAir = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_InAir)
        {
            m_Timer -= Time.deltaTime;
        }


        if (m_Timer <= 0 )
        {
            m_Rigidbody.linearVelocity = -m_Rigidbody.linearVelocity;
            m_Timer = 1.5f;
            m_InAir = false;
        }
    }

    public void StartThrow()
    {
        m_Timer = 1.5f;
        m_InAir = true;
    }
}
