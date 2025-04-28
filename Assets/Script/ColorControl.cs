using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ColorControl : MonoBehaviour
{
    public static ColorControl Instance;

    private List<GoalControl> yellowObjects = new List<GoalControl>();

    public TextMeshProUGUI timerText;  // UIのTextMeshProUGUI
    private TimeControl timeControl;  // TimeControlスクリプトへの参照

    [SerializeField] private int yellowTargetCount = 11;
    public int currentYellowCount = 0;

    [SerializeField] private GameObject clearTextUI; // ゲームクリアのUI

    void Start()
    {
        timeControl = FindObjectOfType<TimeControl>();

        if (timeControl == null)
        {
            Debug.LogError("TimeControlが見つかりません。シーンにアタッチされていますか？");
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReportYellowChange(GoalControl obj)
    {
        if (!yellowObjects.Contains(obj))
        {
            yellowObjects.Add(obj);
            currentYellowCount++;

            if (currentYellowCount >= yellowTargetCount)
            {
                GameClear();
            }
        }
    }

    private void GameClear()
    {
        Time.timeScale = 0f; // ゲーム停止
        if (clearTextUI != null)
        {
            clearTextUI.SetActive(true);
        }
        if (timeControl != null)
        {
            // クリア時間を表示
            timerText.text = "ClearTime: " + timeControl.clearTime.ToString("F2"); // 秒単位で表示
        }
    }

    public void ResetAllColors()
    {
        foreach (GoalControl obj in yellowObjects)
        {
            if (obj != null)
            {
                obj.ResetColor();
            }
        }

        yellowObjects.Clear();
        currentYellowCount = 0;

        if (clearTextUI != null)
        {
            clearTextUI.SetActive(false); // クリア表示も消しておく
        }
    }
}
