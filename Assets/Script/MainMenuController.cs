using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SinglePlayStart()
    {
        // SinglePlayScene으로 전환
        SceneManager.LoadScene("SinglePlayScene");
    }
    public void MultiPlayStart()
    {
        // LobbyScene으로 전환
        SceneManager.LoadScene("LobbyScene");
    }
}
