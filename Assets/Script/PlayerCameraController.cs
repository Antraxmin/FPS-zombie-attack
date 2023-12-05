using UnityEngine;
using Photon.Pun;
using System;

public class PlayerCameraController : MonoBehaviourPun
{
    [NonSerialized] public Transform playerBody;
    [NonSerialized] public float sensitivity = 2f;

    private float rotationX = 0f;

    void Start()
    {
        // 로컬 플레이어의 경우에만 카메라를 활성화
        if (photonView.IsMine)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // 원격 플레이어의 경우에는 카메라를 비활성화
            GetComponent<Camera>().enabled = false;
        }
    }

    void Update()
    {
        // 로컬 플레이어의 경우에만 입력을 받아서 시점 변경
        if (photonView.IsMine)
        {
            HandleMouseLook();
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
