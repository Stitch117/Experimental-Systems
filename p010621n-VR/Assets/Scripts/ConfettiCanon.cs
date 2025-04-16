using UnityEngine;

public class ConfettiCanon : MonoBehaviour
{
    [SerializeField] GameObject m_ConfettiPrefab;
    [SerializeField] GameObject m_FireTransform;

    float m_ConfettiSpeed = 10.0f;

    public void ShootCannon()
    {
        GameObject ConfettiSpawn = Instantiate(m_ConfettiPrefab, m_FireTransform.transform.position, m_FireTransform.transform.rotation);
        foreach (Rigidbody Confetti in ConfettiSpawn.GetComponentsInChildren<Rigidbody>())
        {
            Confetti.AddForce(m_FireTransform.transform.up * m_ConfettiSpeed, ForceMode.Impulse);
        }

    }
}
