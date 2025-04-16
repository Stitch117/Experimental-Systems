using UnityEngine;

public class Confetti : MonoBehaviour
{
    float m_Lifetime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Lifetime -= Time.deltaTime;

        if (m_Lifetime <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
