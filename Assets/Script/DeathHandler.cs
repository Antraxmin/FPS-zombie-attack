using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas; // 캔버스 객체

    private void Start()
    {
        // 게임 시작할 때 종료 UI가 나타나지 않도록
        gameOverCanvas.enabled = false;
    }

    // 플레이어가 죽었을때 종료 UI 활성화
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;

        // 마우스 클릭 활성화
        Cursor.lockState = CursorLockMode.None;

        // 사용자가 마우스 확인 가능하도록
        Cursor.visible = true;
    }
}
