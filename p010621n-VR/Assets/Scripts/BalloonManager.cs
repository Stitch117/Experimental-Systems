using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] int m_BalloonsAmount = 16;
    GameObject[] m_Balloons;

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
            }
        }
    }
}
