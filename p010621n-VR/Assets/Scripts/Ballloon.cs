using System.Xml.Serialization;
using UnityEngine;

public class Ballloon : MonoBehaviour
{
    public BalloonManager m_BalloonManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            m_BalloonManager.PlaySound();
            gameObject.SetActive(false);
        }
    }
}
