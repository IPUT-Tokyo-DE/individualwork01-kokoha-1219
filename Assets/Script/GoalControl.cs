using UnityEngine;

public class GoalControl : MonoBehaviour
{
    public string targetTag = "Player";  // 反応させたい相手のタグ
    [SerializeField] private GameObject nuno;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;

    private Color originalColor1;
    private Color originalColor2;

    private bool isYellow = false; // ← 一度だけカウントするためのフラグ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer2 = nuno.GetComponent<SpriteRenderer>();

        // 最初の色を記録
        originalColor1 = spriteRenderer.color;
        originalColor2 = spriteRenderer2.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log ("OnTriggerEnter" + other.gameObject.tag);
        if (other.CompareTag(targetTag))
        {
            Debug.Log("プレイヤーが触れました");
            spriteRenderer.color = Color.yellow;
            spriteRenderer2.color = Color.yellow;
            isYellow = true;

            // GameManagerに報告
            if (ColorControl.Instance != null)
            {
                ColorControl.Instance.ReportYellowChange(this);
            }
            else
            {
                Debug.LogWarning("ColorControl.Instance がまだ存在しません！");
            }
        }
    }
    // ColorControl から呼ばれるリセット処理
    public void ResetColor()
    {
        if (spriteRenderer != null) spriteRenderer.color = originalColor1;
        if (spriteRenderer2 != null) spriteRenderer2.color = originalColor2;
        isYellow = false;
    }
}
