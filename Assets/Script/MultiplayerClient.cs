using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net.WebSockets;

public class MultiplayerClient : MonoBehaviour
{
    private WebSocket ws;

    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        ws = new WebSocket("ws://localhost:3000");

        ws.OnMessage += OnMessage;
        ws.OnOpen += OnOpen;
        ws.OnClose += OnClose;

        ws.Connect();
    }

    void OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connected to server");
    }

    void OnMessage(object sender, MessageEventArgs e)
    {
        // 서버로부터의 메시지 처리
        var data = JsonUtility.FromJson<MessageData>(e.Data);

        if (data.type == "playerId")
        {
            Debug.Log("Received player ID: " + data.playerId);
        }
        else if (data.type == "playerConnected")
        {
            Debug.Log("Player connected: " + data.playerId);
        }
        else if (data.type == "playerDisconnected")
        {
            Debug.Log("Player disconnected: " + data.playerId);
        }
   
    }

    void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Connection closed");
    }

    [System.Serializable]
    public class MessageData
    {
        public string type;
        public string playerId;

    }
}
