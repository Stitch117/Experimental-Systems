using UnityEngine;

public class Duck : MonoBehaviour
{
    public PrizeManager.PrizeLevel m_PrizeLevel;
    public Vector3 m_StartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
