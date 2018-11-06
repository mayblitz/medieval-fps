using UnityEngine;

public class ClipCameraFollow : MonoBehaviour
{
    [SerializeField]
    private string mouseYInputName = "Mouse Y";

    [SerializeField]
    private float mouseSensitivity = 150f;

    private float xAxisClamp;

    void Start()
    {
        mouseSensitivity = mouseSensitivity * 1.22f;
        xAxisClamp = 0.0f;
    }

    void LateUpdate()
    {
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 110)
        {
            xAxisClamp = 110;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(290);
        }
        else if (xAxisClamp < -110)
        {
            xAxisClamp = -110;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(70);
        }

        transform.Rotate(Vector3.left * mouseY);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
