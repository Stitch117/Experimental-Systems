using UnityEngine;

public class ClownManager : MonoBehaviour
{
    [SerializeField] int m_ClownAmount = 16;
    GameObject[] m_Clowns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Clowns = new GameObject[m_ClownAmount];
        m_Clowns = GameObject.FindGameObjectsWithTag("Clown");
    }

    public void ResetClowns()
    {
        for (int i = 0; i < m_Clowns.Length; i++)
        {
            if (m_Clowns[i] != null && m_Clowns[i].activeInHierarchy == false)
            {
                m_Clowns[i].SetActive(true);
            }
        }
    }
}
