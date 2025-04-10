using UnityEngine;

public class WaterBulletTimer : MonoBehaviour
{
    float m_Time = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Time -= Time.deltaTime;

        if (m_Time <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
