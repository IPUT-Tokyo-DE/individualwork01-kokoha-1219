using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransformを設定
    public float speed = 4.0f;  // 追いかけるスピード
    public ColorControl enemycontrol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("player").transform;
        enemycontrol = GameObject.Find("goal").GetComponent<ColorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // プレイヤーへの方向を計算
            Vector3 direction = (player.position - transform.position).normalized;

            // エネミーをプレイヤーに向かって移動させる
            transform.position += direction * speed * Time.deltaTime;
        }
        int enemyspeed = enemycontrol.currentYellowCount;
        if (enemyspeed == 5)
        {
            speed = 5;
        }
    }
}
