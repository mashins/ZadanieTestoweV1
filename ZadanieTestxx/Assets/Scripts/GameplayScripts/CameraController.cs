using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    Transform playerBody;
    float yRotation;

    void Start()
    {
        playerBody = transform.parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseMoveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseMoveY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseMoveX);
    }
}
