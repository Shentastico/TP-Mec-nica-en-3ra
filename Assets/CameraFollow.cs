using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 7f;
    [SerializeField] private float height = 3f;
    [SerializeField] private float rotationSpeed = 5f;

    private float currentX = 0f;
    private float currentY = 15f;

    private void LateUpdate()
    {
        if (target == null) return;

        
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            currentY = Mathf.Clamp(currentY, -5f, 60f); 
        }

        
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, height, -distance);

        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position + Vector3.up * 1f);
    }
}