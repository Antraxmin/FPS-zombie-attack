using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ReloadGame()
    {
        SceneManager.LoadScene(0);      // 게임 로딩
    }
    public void QuitGame()
    {
        Application.Quit();     // 게임 종료
    }
}
