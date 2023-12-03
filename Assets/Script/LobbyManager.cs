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

    public void SetNickname()
    {
        PhotonNetwork.NickName = usernameInput.text;
    }

    public void CreateRoom()
    {
        SetNickname();
        string roomName = roomnameInput.text;
        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 4 });
    }

    public void JoinRoom()
    {
        string roomName = roomnameInput.text;
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        //PhotonNetwork.NickName = usernameInput.text;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Joined User: " + PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("GamePlayScene"); // GamePlayScene 씬으로 이동
    }
}
