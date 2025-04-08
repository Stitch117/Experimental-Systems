using UnityEngine;
using UnityEngine.UIElements;

public class CoconutManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_Coconuts = new GameObject[3];
    Vector3[] m_Positions = new Vector3[3];
    Quaternion[] m_Rotations = new Quaternion[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < m_Coconuts.Length; i++)
        {
            m_Positions[i] = m_Coconuts[i].transform.position;
            m_Rotations[i] = m_Coconuts[i].transform.rotation;
        }
    }

    public void ResetPositions()
    {
        for(int i = 0;i < m_Coconuts.Length;i++)
        {
            m_Coconuts[i].GetComponent<Rigidbody>().isKinematic = true;
            m_Coconuts[i].transform.position = m_Positions[i];
            m_Coconuts[i].transform.rotation = m_Rotations[i];
        }
    }
}
