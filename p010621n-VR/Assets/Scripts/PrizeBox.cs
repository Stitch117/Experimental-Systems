using UnityEngine;

public class PrizeBox : MonoBehaviour
{
    [SerializeField] GameObject[] m_BigPrizes = new GameObject[4];
    [SerializeField] GameObject[] m_MediumPrizes = new GameObject[6];
    [SerializeField] GameObject[] m_SmallPrizes = new GameObject[10];

    [SerializeField] GameObject m_Handle;
    HingeJoint m_HandleHinge;
    PrizeManager m_PrizeManager;

    public PrizeManager.PrizeLevel m_PrizeLevel;

    private int m_PrizeNumber = -1;

    private float m_TotalRotation = 0f;
    private float m_LastAngle = 0f;

    [SerializeField] GameObject m_SmokeEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_PrizeManager = FindFirstObjectByType<PrizeManager>();
        m_HandleHinge = m_Handle.GetComponent<HingeJoint>();
        m_TotalRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = m_HandleHinge.angle;
        float deltaAngle = Mathf.DeltaAngle(m_LastAngle, currentAngle);

        m_TotalRotation += deltaAngle;
        m_LastAngle = currentAngle;

        //Jimmy solution
        if(float.IsNaN(m_TotalRotation))
        {
            m_TotalRotation = 0f;
        }    

        if (Mathf.Abs(m_TotalRotation) >= 1080.0f)
        {
            MakePrize();
        }
    }

    public void MakePrize()
    {
        m_PrizeManager.PlaySound();

        if (m_PrizeLevel == PrizeManager.PrizeLevel.Big)
        {
            m_PrizeNumber = Random.Range(0, m_BigPrizes.Length - 1);
            Instantiate(m_BigPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }
        else if (m_PrizeLevel == PrizeManager.PrizeLevel.Medium)
        {
            m_PrizeNumber = Random.Range(0, m_MediumPrizes.Length - 1);
            Instantiate(m_MediumPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }
        else if (m_PrizeLevel == PrizeManager.PrizeLevel.Small)
        {
            m_PrizeNumber = Random.Range(0, m_SmallPrizes.Length - 1);
            Instantiate(m_SmallPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }

        m_PrizeManager.ChangeUI(m_PrizeLevel, m_PrizeNumber);

        m_PrizeNumber = -1;
        Instantiate(m_SmokeEffect, transform.position, Quaternion.identity);
        Destroy(m_Handle);
        Destroy(gameObject);
    }
}
