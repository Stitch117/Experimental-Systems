using UnityEngine;

public class ClownManager : MonoBehaviour
{
    [SerializeField] int m_ClownAmount = 16;
    GameObject[] m_Clowns;

    [SerializeField] PrizeManager m_PrizeManager;
    int m_ClownsPopped = 0;

    AudioSource m_AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Clowns = new GameObject[m_ClownAmount];
        m_Clowns = GameObject.FindGameObjectsWithTag("Clown");
        m_AudioSource =  GetComponent<AudioSource>();
    }

    public void ResetClowns()
    {
        for (int i = 0; i < m_Clowns.Length; i++)
        {
            if (m_Clowns[i] != null && m_Clowns[i].activeInHierarchy == false)
            {
                m_Clowns[i].SetActive(true);
                m_ClownsPopped++;
            }
        }


        if (m_ClownsPopped >= 12)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Big;
            m_PrizeManager.SpawnPrizeBox();
        }
        else if (m_ClownsPopped >= 8)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Medium;
            m_PrizeManager.SpawnPrizeBox();
        }
        else if (m_ClownsPopped >= 4)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Small;
            m_PrizeManager.SpawnPrizeBox();
        }

        m_ClownsPopped = 0;
    }

    public void PlaySound()
    {
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
    }
}
