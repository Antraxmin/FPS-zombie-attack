using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }



    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    
    void CreateController()
    {
        PhotonNetwork.Instantiate("Player1 Variant", Vector3.zero, Quaternion.identity);
    }
}
