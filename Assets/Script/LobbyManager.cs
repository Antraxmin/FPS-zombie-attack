using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public InputField roomnameInput;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        string roomName = roomnameInput.text;
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.NickName = usernameInput.text;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GamePlayScene"); // GamePlayScene 씬으로 이동
    }
}
