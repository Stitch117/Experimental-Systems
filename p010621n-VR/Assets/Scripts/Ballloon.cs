using System.Xml.Serialization;
using UnityEngine;

public class Ballloon : MonoBehaviour
{
    AudioSource m_AudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            m_AudioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
