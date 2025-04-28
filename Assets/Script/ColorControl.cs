using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ColorControl : MonoBehaviour
{
    public static ColorControl Instance;

    private List<GoalControl> yellowObjects = new List<GoalControl>();

    public TextMeshProUGUI timerText;  // UI��TextMeshProUGUI
    private TimeControl timeControl;  // TimeControl�X�N���v�g�ւ̎Q��

    [SerializeField] private int yellowTargetCount = 11;
    public int currentYellowCount = 0;

    [SerializeField] private GameObject clearTextUI; // �Q�[���N���A��UI

    void Start()
    {
        timeControl = FindObjectOfType<TimeControl>();

        if (timeControl == null)
        {
            Debug.LogError("TimeControl��������܂���B�V�[���ɃA�^�b�`����Ă��܂����H");
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
        Time.timeScale = 0f; // �Q�[����~
        if (clearTextUI != null)
        {
            clearTextUI.SetActive(true);
        }
        if (timeControl != null)
        {
            // �N���A���Ԃ�\��
            timerText.text = "ClearTime: " + timeControl.clearTime.ToString("F2"); // �b�P�ʂŕ\��
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
            clearTextUI.SetActive(false); // �N���A�\���������Ă���
        }
    }
}
