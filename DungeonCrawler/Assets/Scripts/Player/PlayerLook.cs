using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private string mouseXInputName = "Mouse X", mouseYInputName = "Mouse Y";

    [SerializeField]
    private float mouseSensitivity = 100f;

    [SerializeField]
    private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xAxisClamp = 0.0f;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 80.0f)
        {
            xAxisClamp = 80.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(280.0f);
        }
        else if (xAxisClamp < -80.0f)
        {
            xAxisClamp = -80.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(80.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
