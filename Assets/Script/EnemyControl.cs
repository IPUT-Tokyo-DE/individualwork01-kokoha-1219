using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform��ݒ�
    public float speed = 4.0f;  // �ǂ�������X�s�[�h
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
            // �v���C���[�ւ̕������v�Z
            Vector3 direction = (player.position - transform.position).normalized;

            // �G�l�~�[���v���C���[�Ɍ������Ĉړ�������
            transform.position += direction * speed * Time.deltaTime;
        }
        int enemyspeed = enemycontrol.currentYellowCount;
        if (enemyspeed == 5)
        {
            speed = 5;
        }
    }
}
