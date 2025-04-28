using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    [SerializeField] private Transform centerPoint;  // 中心点
    [SerializeField] private float maxRadius = 43f;   // 最大半径

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BoxCollider2D がなければ追加
        if (GetComponent<BoxCollider2D>() == null)
        {
            BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
            collider.isTrigger = false; // 必要に応じて true に（トリガーにしたい場合）
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 入力の取得
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        Debug.Log($"moveInput: {moveInput}");

        moveInput.Normalize(); // 斜め移動を速くしないため

        // 移動処理
        Vector2 pos = transform.position;
        pos += moveInput * moveSpeed;

        // === 円形の範囲制限を追加 ===
        Vector2 center = centerPoint.position; // 中心点（Transformをインスペクターで設定）
        float distance = Vector2.Distance(pos, center);

        if (distance > maxRadius)
        {
            Vector2 dir = (pos - center).normalized;
            pos = center + dir * maxRadius;
        }

        // === 実際の移動反映 ===
        transform.position = pos;
    }


}
