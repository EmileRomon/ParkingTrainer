using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 mouseSensitivity = new Vector2(100f, 100f);
    [SerializeField] private Vector2 xRotationLimit = new Vector2(-90f, 90f);
    [SerializeField] private Vector2 yRotationLimit = new Vector2(-90f, 90f);
    private Vector2 rotation = Vector2.zero;

    void Update()
    {
        float xMove = Input.GetAxis("Mouse X") * mouseSensitivity.x * Time.deltaTime;
        float yMove = Input.GetAxis("Mouse Y") * mouseSensitivity.y * Time.deltaTime;
        rotation.x = Mathf.Clamp(rotation.x + xMove, xRotationLimit.x, xRotationLimit.y);
        rotation.y = Mathf.Clamp(rotation.y - yMove, yRotationLimit.x, yRotationLimit.y);
        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, 0f);
    }
}
