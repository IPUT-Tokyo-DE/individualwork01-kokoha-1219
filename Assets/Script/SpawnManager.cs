using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPrefab;

    [SerializeField] private Transform player;         // �v���C���[��Transform
    [SerializeField] private float spawnInterval = 3f; // �X�|�[���Ԋu�i�b�j
    [SerializeField] private float minDistance = 8f; // �v���C���[����ŒႱ�̋����͘b���ăX�|�[��
    [SerializeField] private float spawnRadius = 13f;  // �v���C���[�̎��́Z�Zm�͈̔͂ɃX�|�[��
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

        // �����_���ȓG��I��
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector2 spawnPos;

        //Vector2 randomPos = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        // �v���C���[�Ƃ̋�����minDistance�ȏ�ɂȂ�܂ňʒu���Đ���
        do
        {
            spawnPos = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
        } while (Vector2.Distance(spawnPos, player.transform.position) < minDistance);


        Instantiate(enemyPrefab[enemyIndex], spawnPos, Quaternion.identity);
    }
}
