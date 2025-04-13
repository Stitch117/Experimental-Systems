using TMPro;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    public enum HowToWin
    {
        OnReset,
        OnCondition
    }

    public HowToWin m_CurrentWinStyle = HowToWin.OnReset;
    [SerializeField] TextMeshProUGUI m_Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = "Current win type: " + m_CurrentWinStyle;
    }

    public void ChangeWinStyle()
    {
        if (m_CurrentWinStyle == HowToWin.OnReset)
        {
            m_CurrentWinStyle = HowToWin.OnCondition;
        }
        else
        {
            m_CurrentWinStyle = HowToWin.OnReset;
        }
    }
}
