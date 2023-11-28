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
}
