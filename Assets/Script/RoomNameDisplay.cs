using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomNameDisplay : MonoBehaviour
{
    public Text roomNameText;

    private void Start()
    {
        UpdateRoomName();
    }

    private void UpdateRoomName()
    {
        if (roomNameText != null)
        {
            string roomName = PhotonNetwork.CurrentRoom.Name;
            roomNameText.text = "Room: " + roomName;
        }
    }
}
