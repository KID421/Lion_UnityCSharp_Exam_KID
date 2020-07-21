using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("結束畫面")]
    public GameObject final;

    private Runner runner;

    private void Start()
    {
        runner = FindObjectOfType<Runner>();

        runner.onEnd += GameOver;                   // 訂閱事件
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    private void GameOver()
    {
        final.SetActive(true);
    }
}
