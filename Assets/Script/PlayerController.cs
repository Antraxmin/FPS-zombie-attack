using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f; // 마우스 감도
    public Transform gunTransform;
    private Weapon weapon;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        
        HandleMovement();
        HandleShooting();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 다른 플레이어에게 움직임을 전달하는 RPC 호출
        //photonView.RPC("SyncMovement", RpcTarget.Others, transform.position);
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
        if (weapon != null)
        {
            weapon.PlayMuzzleFlash();
            weapon.ProcessRaycast();
        }
    }

    [PunRPC]
    void SyncMovement(Vector3 newPosition)
    {
        // 다른 플레이어의 화면에서 로컬 플레이어를 움직임
        transform.position = newPosition;
    }
}
