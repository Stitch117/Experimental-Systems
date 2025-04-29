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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Duck"))
        {
            if (other.gameObject.GetComponent<Duck>().m_Checked == false)
            {
                other.gameObject.GetComponent<Duck>().m_Checked = true;
                other.gameObject.AddComponent<XRGrabInteractable>();
                m_PrizeManager.m_PrizeLevel = other.gameObject.GetComponent<Duck>().m_PrizeLevel;
                m_PrizeManager.SpawnPrizeBox();
            }
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
            m_Ducks[i].transform.rotation = m_Ducks[i].GetComponent<Duck>().m_StartRot;
        }
    }
}
