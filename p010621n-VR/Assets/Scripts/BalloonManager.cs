using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] int m_BalloonsAmount = 16;
    GameObject[] m_Balloons;
    [SerializeField] PrizeManager m_PrizeManager;

    int m_PoppedBalloons = 0;

    private void Awake()
    {
        m_Balloons = new GameObject[m_BalloonsAmount];
        m_Balloons = GameObject.FindGameObjectsWithTag("Balloon");
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

        if (m_PoppedBalloons >= 10)
        {
            m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Big;
            m_PrizeManager.SpawnPrizeBox();
        }
        else if (m_PoppedBalloons >= 6)
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
    }
}
