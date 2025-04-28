using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] int m_BalloonsAmount = 16;
    GameObject[] m_Balloons;
    [SerializeField] PrizeManager m_PrizeManager;
    GunScript m_GunScript;

    int m_PoppedBalloons = 0;
    AudioSource m_AudioSource;

    private void Awake()
    {
        m_Balloons = new GameObject[m_BalloonsAmount];
        m_Balloons = GameObject.FindGameObjectsWithTag("Balloon");
        m_GunScript = FindFirstObjectByType<GunScript>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void ResetBalloons()
    {
        for (int i = 0; i < m_Balloons.Length; i++)
        {
            if (m_Balloons[i] != null && m_Balloons[i].activeInHierarchy == false)
            {
                m_Balloons[i].SetActive(true);
                m_PoppedBalloons++;
            }
        }

        if (m_PoppedBalloons >= 8)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Big;
            m_PrizeManager.SpawnPrizeBox();
        }
        else if (m_PoppedBalloons >= 5)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Medium;
            m_PrizeManager.SpawnPrizeBox();
        }
        else if (m_PoppedBalloons >= 3)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Small;
            m_PrizeManager.SpawnPrizeBox();
        }

        m_PoppedBalloons = 0;
        m_GunScript.m_FiredShots = 0;
    }


    public void PlaySound()
    {
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
    }
}
