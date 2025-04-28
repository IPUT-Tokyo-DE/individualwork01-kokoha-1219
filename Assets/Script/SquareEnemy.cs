using UnityEngine;

public class SquareEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーと衝突したかどうかをチェック
        if (collision.CompareTag("PlayerT"))
        {
            // 自分自身を消滅させる
            Destroy(gameObject);
        }
    }
}
