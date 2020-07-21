using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Move());
    }

    /// <summary>
    /// 移動
    /// </summary>
    private IEnumerator Move()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += transform.forward;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
