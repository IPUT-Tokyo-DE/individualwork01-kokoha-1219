using UnityEngine;

public class GoalControl : MonoBehaviour
{
    public string targetTag = "Player";  // ����������������̃^�O
    [SerializeField] private GameObject nuno;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;

    private Color originalColor1;
    private Color originalColor2;

    private bool isYellow = false; // �� ��x�����J�E���g���邽�߂̃t���O

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer2 = nuno.GetComponent<SpriteRenderer>();

        // �ŏ��̐F���L�^
        originalColor1 = spriteRenderer.color;
        originalColor2 = spriteRenderer2.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log ("OnTriggerEnter" + other.gameObject.tag);
        if (other.CompareTag(targetTag))
        {
            Debug.Log("�v���C���[���G��܂���");
            spriteRenderer.color = Color.yellow;
            spriteRenderer2.color = Color.yellow;
            isYellow = true;

            // GameManager�ɕ�
            if (ColorControl.Instance != null)
            {
                ColorControl.Instance.ReportYellowChange(this);
            }
            else
            {
                Debug.LogWarning("ColorControl.Instance ���܂����݂��܂���I");
            }
        }
    }
    // ColorControl ����Ă΂�郊�Z�b�g����
    public void ResetColor()
    {
        if (spriteRenderer != null) spriteRenderer.color = originalColor1;
        if (spriteRenderer2 != null) spriteRenderer2.color = originalColor2;
        isYellow = false;
    }
}
