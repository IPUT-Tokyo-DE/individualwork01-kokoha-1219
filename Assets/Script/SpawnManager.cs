using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPrefab;

    [SerializeField] private Transform player;         // プレイヤーのTransform
    [SerializeField] private float spawnInterval = 3f; // スポーン間隔（秒）
    [SerializeField] private float minDistance = 8f; // プレイヤーから最低この距離は話してスポーン
    [SerializeField] private float spawnRadius = 13f;  // プレイヤーの周囲〇〇mの範囲にスポーン
    [SerializeField] private ColorControl goalcount;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int changeinterval = goalcount.currentYellowCount;
        if (changeinterval == 5)
        {
            spawnInterval = 2.5f;
        }
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab.Length == 0 || player == null) return;

        // ランダムな敵を選ぶ
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector2 spawnPos;

        //Vector2 randomPos = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        // プレイヤーとの距離がminDistance以上になるまで位置を再生成
        do
        {
            spawnPos = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        } while (Vector2.Distance(spawnPos, player.transform.position) < minDistance);


        Instantiate(enemyPrefab[enemyIndex], spawnPos, Quaternion.identity);
    }
}
