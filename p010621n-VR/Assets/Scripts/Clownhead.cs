using UnityEngine;

public class Clownhead : MonoBehaviour
{
    int health = 75;

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
        if (collision.gameObject.CompareTag("WaterBullet"))
        {
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
