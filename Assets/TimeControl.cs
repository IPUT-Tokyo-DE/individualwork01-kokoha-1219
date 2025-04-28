using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TimeControl : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private int minute;
    private float seconds;
    private float oldSeconds;
    // 最初の時間
    private float startTime;
    public float clearTime;  // 変更: ColorControl型からfloat型に変更

    private bool counting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counting = true;
        timerText = GetComponent<TextMeshProUGUI>();
        oldSeconds = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            // Time.timeでの時間計測
            seconds = Time.time - startTime;

            minute = (int)seconds / 60;

            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)(seconds % 60)).ToString("00");
            }
            oldSeconds = seconds;
        }

        int timegoal = ColorControl.Instance.currentYellowCount;
        if (timegoal == 10)
        {
            
            clearTime = oldSeconds; // クリア時間を保存
            
        }
    }
}
