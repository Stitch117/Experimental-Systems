using TMPro;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] GameObject m_PrizeTransform;
    [SerializeField] GameObject m_PrizeBoxPrefab;
    PrizeBox m_PrizeBox;

    public GameObject[] m_PrizeIcons = new GameObject[40];

    AudioSource m_PrizeAudioSource;

    public enum HowToWin
    {
        OnReset,
        OnCondition
    }

    public enum PrizeLevel
    {
        Big,
        Medium,
        Small,
        Fail
    }

    public HowToWin m_CurrentWinStyle = HowToWin.OnReset;
    [SerializeField] TextMeshProUGUI m_Text;

    public PrizeLevel m_PrizeLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_PrizeAudioSource = GetComponent<AudioSource>();
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

    public void SpawnPrizeBox()
    {
        GameObject PrizeBox = Instantiate(m_PrizeBoxPrefab, m_PrizeTransform.transform.position, m_PrizeTransform.transform.rotation);
        m_PrizeBox = PrizeBox.GetComponent<PrizeBox>();
        m_PrizeBox.m_PrizeLevel = m_PrizeLevel;
    }

    public void ChangeUI(PrizeLevel prizeLevel, int prizeNumber)
    {
        if (prizeLevel == PrizeLevel.Big)
        {
            switch (prizeNumber)
            {
                case 0:
                    m_PrizeIcons[32].SetActive(false);
                    m_PrizeIcons[33].SetActive(true);
                    break;
                case 1:
                    m_PrizeIcons[34].SetActive(false);
                    m_PrizeIcons[35].SetActive(true);
                    break;
                case 2:
                    m_PrizeIcons[36].SetActive(false);
                    m_PrizeIcons[37].SetActive(true);
                    break;
                case 3:
                    m_PrizeIcons[38].SetActive(false);
                    m_PrizeIcons[39].SetActive(true);
                    break;
                default:break;
            }
        }
        else if (prizeLevel == PrizeLevel.Medium)
        {
            switch (prizeNumber)
            {
                case 0:
                    m_PrizeIcons[20].SetActive(false);
                    m_PrizeIcons[21].SetActive(true);
                    break;
                case 1:
                    m_PrizeIcons[22].SetActive(false);
                    m_PrizeIcons[23].SetActive(true);
                    break;
                case 2:
                    m_PrizeIcons[24].SetActive(false);
                    m_PrizeIcons[25].SetActive(true);
                    break;
                case 3:
                    m_PrizeIcons[26].SetActive(false);
                    m_PrizeIcons[27].SetActive(true);
                    break;
                case 4:
                    m_PrizeIcons[28].SetActive(false);
                    m_PrizeIcons[29].SetActive(true);
                    break;
                case 5:
                    m_PrizeIcons[30].SetActive(false);
                    m_PrizeIcons[31].SetActive(true);
                    break;
                default:break;
            }
        }
        else if (prizeLevel == PrizeLevel.Small)
        {
            switch (prizeNumber)
            {
                case 0:
                    m_PrizeIcons[0].SetActive(false);
                    m_PrizeIcons[1].SetActive(true);
                    break;
                case 1:
                    m_PrizeIcons[2].SetActive(false);
                    m_PrizeIcons[3].SetActive(true);
                    break;
                case 2:
                    m_PrizeIcons[4].SetActive(false);
                    m_PrizeIcons[5].SetActive(true);
                    break;
                case 3:
                    m_PrizeIcons[6].SetActive(false);
                    m_PrizeIcons[7].SetActive(true);
                    break;
                case 4:
                    m_PrizeIcons[8].SetActive(false);
                    m_PrizeIcons[9].SetActive(true);
                    break;
                case 5:
                    m_PrizeIcons[10].SetActive(false);
                    m_PrizeIcons[11].SetActive(true);
                    break;
                case 6:
                    m_PrizeIcons[12].SetActive(false);
                    m_PrizeIcons[13].SetActive(true);
                    break;
                case 7:
                    m_PrizeIcons[14].SetActive(false);
                    m_PrizeIcons[15].SetActive(true);
                    break;
                case 8:
                    m_PrizeIcons[16].SetActive(false);
                    m_PrizeIcons[17].SetActive(true);
                    break;
                case 9:
                    m_PrizeIcons[18].SetActive(false);
                    m_PrizeIcons[19].SetActive(true);
                    break;
                default:break;
            }
        }
    }

    public void PlaySound()
    {
        m_PrizeAudioSource.PlayOneShot(m_PrizeAudioSource.clip);
    }
}
