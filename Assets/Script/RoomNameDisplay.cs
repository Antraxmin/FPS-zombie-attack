using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomNameDisplay : MonoBehaviour
{
    public Text roomNameText;
    public Text usernameText;

    private void Start()
    {
        UpdateRoomName();
        UpdateUsername();
    }

    private void UpdateRoomName()
    {
        if (roomNameText != null)
        {
            string roomName = PhotonNetwork.CurrentRoom.Name;
            roomNameText.text = roomName;
        }
    }

    private void UpdateUsername()
    {
        if (usernameText != null)
        {
            string username = PhotonNetwork.NickName;
            usernameText.text = username;
        }
    }
}

