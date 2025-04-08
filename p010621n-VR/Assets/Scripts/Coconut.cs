using Unity.XR.CoreUtils;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Ball"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
