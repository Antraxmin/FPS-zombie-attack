using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";   // 게임 버전 선언
    public Text connectionInfoText;
    public Button joinButton;

    private void Start()
    {
        // 마스터 서버 접속 시도 
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "Connecting to Master Server...";
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Successfully connected to master server";
    }

    public void Connect()
    {
        joinButton.interactable = false;
        // 마스터 서버에 접속된 상태에서만 랜덤 룸 접속 시도
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to Random Room";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // 마스터 서버에 접속되지 않은 상태라면 재접속 시도
            connectionInfoText.text = "Disconnected to Master Server. Retry...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // 랜덤 룸 접속에 실패한 경우
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "No Empty Room. Creating New Room...";
        // 최대 4명 수용 가능한 빈 방 생성
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    // 룸 접속에 성공한 경우
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "Room connection successful";
        // 모든 룸 참가자가 GamePlayScene 로드
        PhotonNetwork.LoadLevel("GamePlayScene");

        // 플레이어 캐릭터를 생성할 랜덤 위치를 지정
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        randomSpawnPos.y = 0f;

        PhotonNetwork.Instantiate("Player1", randomSpawnPos, Quaternion.identity);
    }
}


//public class LobbyManager : MonoBehaviourPunCallbacks
//{
//    public InputField usernameInput;
//    public InputField roomnameInput;

//    private void Start()
//    {
//        PhotonNetwork.ConnectUsingSettings();
//    }

//    public void SetNickname()
//    {
//        PhotonNetwork.NickName = usernameInput.text;
//    }

//    public void CreateRoom()
//    {
//        SetNickname();
//        string roomName = roomnameInput.text;
//        PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = 4 });
//    }

//    public void JoinRoom()
//    {
//        SetNickname();
//        string roomName = roomnameInput.text;
//        PhotonNetwork.JoinRoom(roomName);
//    }

//    public override void OnConnectedToMaster()
//    {
//        Debug.Log("Connected to Photon Master Server");
//        //PhotonNetwork.NickName = usernameInput.text;
//    }

//    public override void OnJoinedRoom()
//    {
//        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
//        Debug.Log("Joined User: " + PhotonNetwork.NickName);
//        PhotonNetwork.LoadLevel("GamePlayScene"); // GamePlayScene 씬으로 이동
//    }
//}
