using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomItem : MonoBehaviour
{
    [Header("道具")]
    public Sprite[] items;
    [Header("道具介面")]
    public Image item;

    public void StartRandom()
    {
        StartCoroutine(RandomEffect());
    }

    /// <summary>
    /// 隨機特效
    /// </summary>
    public IEnumerator RandomEffect()
    {
        int r = Random.Range(0, items.Length);      // 隨機取得道具編號

        int count = 0;                              // 執行迴圈次數

        while (count < items.Length * 2 + r)        // 迴圈次數 < 所有項目 * 2 + 當前隨機道具 - 跑兩圈
        {
            item.sprite = items[count % items.Length];
            count++;
            yield return null;
        }
    }
}
