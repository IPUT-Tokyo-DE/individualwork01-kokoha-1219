using UnityEngine;

public class CircleEnemy : MonoBehaviour
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
        // �v���C���[�ƏՓ˂������ǂ������`�F�b�N
        if (collision.CompareTag("PlayerS"))
        {
            // �������g�����ł�����
            Destroy(gameObject);
        }
    }
}
