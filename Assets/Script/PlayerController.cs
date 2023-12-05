using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f; // 마우스 감도
    public Transform gunTransform;
    Weapon weapon;

    void Update()
    {
        if (photonView.IsMine)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // 수직 회전은 플레이어 캐릭터의 X 축을 중심으로 한다.
            transform.Rotate(Vector3.up * mouseX);

            // 수평 회전은 총 기준 Y 축을 중심으로 한다.
            gunTransform.Rotate(Vector3.left * mouseY);
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            photonView.RPC("ShootRPC", RpcTarget.All);
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 수직 회전은 플레이어 캐릭터의 X 축을 중심으로 한다.
        transform.Rotate(Vector3.up * mouseX);

        // 수평 회전은 총 기준 Y 축을 중심으로 한다.
        gunTransform.Rotate(Vector3.left * mouseY);
    }

    [PunRPC]
    void ShootRPC()
    {
        weapon.PlayMuzzleFlash();
        weapon.ProcessRaycast();
    }

    // 나머지 코드는 동일
}
