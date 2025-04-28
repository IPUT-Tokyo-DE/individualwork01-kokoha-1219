using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriangle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // タグが "EnemyA" または "EnemyB" ならゲームオーバー
        if (other.CompareTag("EnemyT") || other.CompareTag("EnemyC"))
        {
            Debug.Log("敵に接触！ゲームオーバー！");
            RestartScene();
        }
    }

    void RestartScene()
    {
        // 現在のシーンを再読み込みする
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
