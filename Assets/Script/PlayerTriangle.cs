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
        // �^�O�� "EnemyA" �܂��� "EnemyB" �Ȃ�Q�[���I�[�o�[
        if (other.CompareTag("EnemyT") || other.CompareTag("EnemyC"))
        {
            Debug.Log("�G�ɐڐG�I�Q�[���I�[�o�[�I");
            RestartScene();
        }
    }

    void RestartScene()
    {
        // ���݂̃V�[�����ēǂݍ��݂���
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
