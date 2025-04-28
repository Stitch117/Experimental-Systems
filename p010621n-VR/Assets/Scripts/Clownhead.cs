using UnityEngine;

public class Clownhead : MonoBehaviour
{
    int health = 75;
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
        if (collision.gameObject.CompareTag("WaterBullet"))
        {
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                m_AudioSource.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
