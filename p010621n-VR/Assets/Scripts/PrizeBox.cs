using UnityEngine;

public class PrizeBox : MonoBehaviour
{
    [SerializeField] GameObject[] m_BigPrizes = new GameObject[4];
    [SerializeField] GameObject[] m_MediumPrizes = new GameObject[6];
    [SerializeField] GameObject[] m_SmallPrizes = new GameObject[10];

    [SerializeField] GameObject m_Handle;
    HingeJoint m_HandleHinge;
    PrizeManager m_PrizeManager;

    private int m_PrizeNumber = -1;

    private float m_TotalRotation = 0f;
    private float m_LastAngle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_PrizeManager = FindFirstObjectByType<PrizeManager>();
        m_HandleHinge = m_Handle.GetComponent<HingeJoint>();

        m_LastAngle = m_HandleHinge.angle;
    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = m_HandleHinge.angle;
        float deltaAngle = Mathf.DeltaAngle(m_LastAngle, currentAngle);

        m_TotalRotation += deltaAngle;
        m_LastAngle = currentAngle;

        if (Mathf.Abs(m_TotalRotation) >= 1080.0f)
        {
            MakePrize(m_PrizeManager.m_PrizeLevel);
        }
    }

    public void MakePrize(PrizeManager.PrizeLevel prizeLevel)
    {
        if (prizeLevel == PrizeManager.PrizeLevel.Big)
        {
            m_PrizeNumber = Random.Range(0, m_BigPrizes.Length - 1);
            Instantiate(m_BigPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }
        else if (prizeLevel == PrizeManager.PrizeLevel.Medium)
        {
            m_PrizeNumber = Random.Range(0, m_MediumPrizes.Length - 1);
            Instantiate(m_MediumPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }
        else if (prizeLevel == PrizeManager.PrizeLevel.Small)
        {
            m_PrizeNumber = Random.Range(0, m_SmallPrizes.Length - 1);
            Instantiate(m_SmallPrizes[m_PrizeNumber], transform.position, transform.rotation);
        }

        m_PrizeNumber = -1;
        Destroy(m_Handle);
        Destroy(gameObject);
    }
}
