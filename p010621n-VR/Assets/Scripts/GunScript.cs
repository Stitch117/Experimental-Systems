using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] GameObject m_FireTransform;
    XRBaseInteractable Ammo;
    int ammo = 0;
    float bulletSpeed = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire()
    {
        if (ammo > 0)
        { 
            GameObject BulletSpawn = Instantiate(m_BulletPrefab, m_FireTransform.transform.position , m_FireTransform.transform.rotation);
            if (BulletSpawn.GetComponent<Rigidbody>() != null)
            {
                BulletSpawn.GetComponent<Rigidbody>().AddForce(m_FireTransform.transform.up * bulletSpeed, ForceMode.Impulse);
            }

            ammo -= 1;
            
        }
    }

    public void Reload()
    {
        ammo = 10;
    }
    public void Unload()
    {
        ammo = 0;
    }
}
