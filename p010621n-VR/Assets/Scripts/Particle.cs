using UnityEngine;

public class Particle : MonoBehaviour
{
    float m_Timer = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
