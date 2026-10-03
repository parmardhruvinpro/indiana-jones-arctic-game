using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public Transform target;
    public float distance = 8f;
    public float height = 4f;
    public float rotationSpeed = 120f;
    public float pitch = 18f;
    public float yaw;

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        if (Input.GetMouseButton(1))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, 8f, 45f);
        }

        Vector3 desiredPosition = target.position + new Vector3(0f, height, 0f);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 cameraOffset = rotation * (new Vector3(0f, 0f, -distance));

        transform.position = desiredPosition + cameraOffset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
