using UnityEngine;
using System.Collections;

public class DrawDiamond : MonoBehaviour
{
    [Header("立方體")]
    public GameObject diamond;

    private void Start()
    {
        StartCoroutine(Draw());
        StartCoroutine(DrawDifferent());
    }

    /// <summary>
    /// 繪製菱形
    /// </summary>
    private IEnumerator Draw()
    {
        float length = 10;                                              // 繪製長度：10 層

        for (float i = 0; i < length; i++)                              // 第一個迴圈：10 層
        {
            float count = (i < length / 2 ? i : length - i);            // 第二個迴圈要執行的次數：1 2 3 4 5 4 3 2 1

            for (float j = 0; j < count; j++)                           // 第二個迴圈：繪製每層的立方體
            {
                Transform temp = Instantiate(diamond).transform;
                Vector3 pos = Vector3.zero;

                pos.x = -(count / 2) + j + 7;                           // X：- (次數 / 2) + j | 例如第二層為：-0.5 0.5
                pos.y = i - 4;                                          // Y：每層 - 4 | 往下移動 4 個單位讓攝影機看的到
                temp.position = pos;

                yield return null;
            }
        }
    }

    /// <summary>
    /// 繪製菱形 1 3 5 7 5 3 1
    /// </summary>
    private IEnumerator DrawDifferent()
    {
        int length = 11;                                            // 繪製長度：11 層
        int start = -(length - 1 / 2);                              // 開始編號：-(長度 - 1 / 2) | 例 11 層 編號 -(11 - 1 / 2) | -5

        for (int i = start; i < -start; i++)                        // 第一個迴圈：11 層：-5 -4 -3 -2 -1 0 1 2 3 4 5
        {
            int count = length - Mathf.Abs(2 * i);                  // 數量： 11 - |-5 * 2|：1 3 5 7 9 11 9 7 5 3 1

            for (int j = 0; j < count; j++)                         // 第二個迴圈：繪製每層的立方體
            {
                Transform temp = Instantiate(diamond).transform;
                Vector3 pos = Vector3.zero;

                pos.x = i - 4;                                          // X：-5 -4 -3 -2 -1 0 1 2 3 4 5
                pos.y = Mathf.Abs(i) - Mathf.Abs(start) + j + 7;        // Y：第幾層 - 長度一半 + 第幾顆，例：第二層 |-4| - |-5| + 0 = -1，|-4| - |-5| + 1 = 0，|-4| - |-5| + 2 = 1
                temp.position = pos;

                yield return null;
            }
        }
    }
}
