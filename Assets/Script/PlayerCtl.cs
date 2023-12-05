using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCtl : MonoBehaviourPun, IPunObservable
{
    public float speed = 5.0f;
    public float rotSpeed = 120.0f;

    private Transform tr;
    private PhotonView pv;
    public Material[] _material;

    private Vector3 currPos;
    private Quaternion currRot;

    void Start()
    {
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();

        pv.ObservedComponents[0] = this;

        if (pv.IsMine)
        {
            this.GetComponent<Renderer>().material = _material[0];
        }
        else
        {
            this.GetComponent<Renderer>().material = _material[1];
        }
    }

    
    void Update()
    {
        if (pv.IsMine)
        {
            // 로컬 플레이어에게만 키보드 조작 허용
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            tr.Translate(Vector3.forward * v * Time.deltaTime * speed);
            tr.Rotate(Vector3.up * h * Time.deltaTime * rotSpeed);
        }
        else
        {
            // 네트워크로 연결된 원격 플레이어
            tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
            tr.rotation = Quaternion.Lerp(tr.rotation, currRot, Time.deltaTime * 10.0f);
        }
    }

    public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {   // 로컬 플레이어 정보를 원격 플레이어에게 전송
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        else
        {
            // 원격 플레이어 정보 수신
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
