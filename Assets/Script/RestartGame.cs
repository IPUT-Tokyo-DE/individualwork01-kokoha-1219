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

    // ‚±‚ÌŠÖ”‚ğƒ{ƒ^ƒ“‚É“o˜^‚µ‚ÄŒÄ‚Ño‚·
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