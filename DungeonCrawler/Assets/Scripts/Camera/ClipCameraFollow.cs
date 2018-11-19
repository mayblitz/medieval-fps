using UnityEngine;

public class ClipCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    void LateUpdate()
    {
        float mainX = mainCamera.transform.eulerAngles.x;

        float x;

        if (mainX > 270.0f)
            x = (mainX - 360.0f) * 1.2f;
        else
            x = mainX * 1.2f;

        transform.eulerAngles = new Vector3(x, mainCamera.transform.eulerAngles.y, mainCamera.transform.eulerAngles.z);
    }
}
