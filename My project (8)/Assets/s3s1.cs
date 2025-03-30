using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // 引入协程

public class s3s1 : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame 按钮被点击！");
        StartCoroutine(LoadSceneWithDelay());
    }

    IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(0.0f); // 等待1秒
        SceneManager.LoadScene("S1");
    }
}
