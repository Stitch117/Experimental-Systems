using UnityEngine;

public class WaterGun : MonoBehaviour
{
    [SerializeField] GameObject m_WaterBullet;
    [SerializeField] GameObject m_FireTransform;
    Quaternion startRot;

    float bulletSpeed = 10.0f;
    bool Firing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Firing)
        {    
            GameObject BulletSpawn = Instantiate(m_WaterBullet, m_FireTransform.transform.position, m_FireTransform.transform.rotation);
            if (BulletSpawn.GetComponent<Rigidbody>() != null)
            {
                BulletSpawn.GetComponent<Rigidbody>().AddForce(m_FireTransform.transform.up * bulletSpeed, ForceMode.Impulse);
            }
        }
    }

    
    public void StartFiring()
    {
        Firing = true;
    }

    public void StopFiring()
    {
        Firing = false;
    }

    public void ResetRot()
    {
        gameObject.transform.rotation = startRot;
        if (Firing)
        {
            Firing = false;
        }
    }
}
