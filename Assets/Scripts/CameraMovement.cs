using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    float zOffset;
    [SerializeField] float cameraMovementSpeed;
    void Start()
    {
       zOffset = transform.position.z - playerTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0, 0, zOffset), Time.deltaTime * cameraMovementSpeed);
    }
}