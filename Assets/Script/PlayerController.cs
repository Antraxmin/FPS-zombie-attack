using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    public Transform gunTransform;
    Weapon weapon;

    void Update()
    {
        if (photonView.IsMine)
        {
            HandleMovement();
            HandleShooting();
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

    [PunRPC]
    void ShootRPC()
    {
        weapon.PlayMuzzleFlash();
        weapon.ProcessRaycast();
    }

    // 나머지 코드는 동일
}
