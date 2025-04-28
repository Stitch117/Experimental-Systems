using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Duckmanager : MonoBehaviour
{
    [SerializeField] GameObject[] m_Ducks = new GameObject[24];
    [SerializeField] PrizeManager m_PrizeManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    { 
        Debug.Log("COLISIONNNNNNN");
        if(collision.gameObject.CompareTag("Duck"))
        {
            collision.gameObject.AddComponent<XRGrabInteractable>();
            m_PrizeManager.m_PrizeLevel = collision.gameObject.GetComponent<Duck>().m_PrizeLevel;
            m_PrizeManager.SpawnPrizeBox();
        }
    }

    public void ResetDucks()
    {
        for (int i = 0; i < m_Ducks.Length; i++)
        {
            if (m_Ducks[i].GetComponent<XRGrabInteractable>() != null)
            {
                Destroy(m_Ducks[i].GetComponent<XRGrabInteractable>());
            }

            m_Ducks[i].transform.position = m_Ducks[i].GetComponent<Duck>().m_StartPos;
        }
    }
}
