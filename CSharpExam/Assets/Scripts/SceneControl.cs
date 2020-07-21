using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private void Update()
    {
        ChangeScene();
    }

    /// <summary>
    /// 切換場景
    /// </summary>
    private void ChangeScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.O)) index--;
        if (Input.GetKeyDown(KeyCode.P)) index++;

        if (index == -1) index = 4;
        if (index == 5) index = 0;

        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene(index);
    }
}

