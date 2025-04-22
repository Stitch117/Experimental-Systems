using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class CoconutManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_Coconuts = new GameObject[3];
    Vector3[] m_Positions = new Vector3[3];
    Quaternion[] m_Rotations = new Quaternion[3];

    [SerializeField] PrizeManager m_PrizeManager;
    int m_CoconutsHit = 0;
    public int m_BallsThrown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < m_Coconuts.Length; i++)
        {
            m_Positions[i] = m_Coconuts[i].transform.position;
            m_Rotations[i] = m_Coconuts[i].transform.rotation;
        }
    }

    private void Update()
    {
        if (m_PrizeManager.m_CurrentWinStyle == PrizeManager.HowToWin.OnCondition && m_BallsThrown >= 3)
        {
            WaitAndSpawnPrize();
            for (int i = 0; i < m_BallsThrown; i++)
            {
                Destroy(FindFirstObjectByType<Ball>());
            }
        }
    }

    IEnumerator WaitAndSpawnPrize()
    {
        yield return new WaitForSeconds(2);

        ResetPositions();
    }

    public void ResetPositions()
    {
        for(int i = 0;i < m_Coconuts.Length;i++)
        {
            if (m_Coconuts[i].GetComponent<Rigidbody>().isKinematic == false)
            {
                m_Coconuts[i].GetComponent<Rigidbody>().isKinematic = true;
                m_Coconuts[i].transform.position = m_Positions[i];
                m_Coconuts[i].transform.rotation = m_Rotations[i];
                m_CoconutsHit++;
            }
        }

        switch (m_CoconutsHit)
        {
            case 3:
                m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Big;
                m_PrizeManager.SpawnPrizeBox();
                break;
            case 2:
                m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Medium;
                m_PrizeManager.SpawnPrizeBox();
                break;
            case 1:
                m_PrizeManager.m_PrizeLevel = PrizeManager.PrizeLevel.Small;
                m_PrizeManager.SpawnPrizeBox();
                break;
            default:break;
        }

        m_CoconutsHit = 0;
        m_BallsThrown = 0;
    }
}
