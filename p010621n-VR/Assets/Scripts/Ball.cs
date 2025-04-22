using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] CoconutManager m_CoconutManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrownCounter()
    {
        m_CoconutManager.m_BallsThrown++;
    }
}
