using System.Collections;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WaterGun : MonoBehaviour
{
    [SerializeField] GameObject m_WaterBullet;
    [SerializeField] GameObject m_FireTransform;
    Quaternion startRot;
    XRGrabInteractable m_GrabInteractable;
    public ClownManager m_ClownManager;

    float bulletSpeed = 10.0f;
    bool Firing = false;

    bool m_IsActive = false;
    float m_Timer = 90.0f;
    [SerializeField] TextMeshProUGUI m_Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRot = gameObject.transform.rotation;
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
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

        if (m_IsActive)
        {
            m_Timer -= Time.deltaTime;
        }

        if (m_Timer <= 0)
        {
            m_GrabInteractable.enabled = false;
            ResetGrab();
            ResetRot();
            m_IsActive = false;
            m_Timer = 90.0f;
            m_ClownManager.ResetClowns();
        }


        //update timer text
        int minutes = (int) m_Timer / 60;
        int seconds = (int) m_Timer % 60;
        string StringSeconds = seconds.ToString();
        if (seconds < 10)
        {
            StringSeconds = "0" + seconds.ToString();
        }
        m_Text.text = minutes + ":" + StringSeconds;
    }

    IEnumerator ResetGrab()
    {
        yield return new WaitForSeconds(1);

        m_GrabInteractable.enabled = true;
    }
    
    public void StartFiring()
    {
        Firing = true;
        m_IsActive = true;
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
