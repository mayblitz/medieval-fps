using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipCameraFollowStandard : MonoBehaviour
{
    public float ySensitivity = 2.5f;
    private Camera clipCamera;
    private Quaternion cameraTargetRot;

    void Start()
    {
        clipCamera = GetComponent<Camera>();
        cameraTargetRot = clipCamera.transform.localRotation;
    }

    void Update()
    {
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;
        cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);
        cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);
        clipCamera.transform.localRotation = cameraTargetRot;
    }
    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -112.5f, 112.5f);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }
}
