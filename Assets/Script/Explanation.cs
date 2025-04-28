using UnityEngine;

public class Explanation : MonoBehaviour
{

    [SerializeField] private GameObject targetObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (targetObject != null)
            {
                bool isActive = targetObject.activeSelf;
                Debug.Log("�؂�ւ��O�F" + isActive);
                targetObject.SetActive(!isActive);
                Debug.Log("�؂�ւ���F" + targetObject.activeSelf);
            }
            else
            {
                Debug.LogWarning("targetObject �� null �ł��I");
            }
        }
    }
}
