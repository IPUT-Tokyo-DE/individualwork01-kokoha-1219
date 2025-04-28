using UnityEngine;

public class ColoerReset : MonoBehaviour
{
    private GoalControl[] allGoals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allGoals = FindObjectsOfType<GoalControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
