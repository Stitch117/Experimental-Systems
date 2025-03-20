using UnityEngine;

public class FerrisRotation : MonoBehaviour
{
    Quaternion Rotation;
    [SerializeField] GameObject locationPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Rotation;
        transform.position = new Vector3(locationPosition.transform.position.x, locationPosition.transform.position.y - 1.0f, locationPosition.transform.position.z) ;
    }
}
