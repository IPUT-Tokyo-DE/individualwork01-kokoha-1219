using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // この関数をボタンに登録して呼び出す
    public void Restart()
    {
        Time.timeScale = 1f;

        if (ColorControl.Instance != null)
        {
            ColorControl.Instance.ResetAllColors();
        }

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}