using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // 새로운 플레이어가 방에 접속했을 때 호출되는 콜백
        // 여기에서 해당 플레이어에 대한 초기화 작업 수행
        Debug.Log($"Player {newPlayer.NickName} entered the room.");
    }
}
