using UnityEngine;

public class FormChange : MonoBehaviour
{
    public GameObject[] shapeObjects; // Circle, Square, TriangleÇÃèáÇ…ÉZÉbÉg
    private int currentIndex = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex = (currentIndex + 1) % shapeObjects.Length;
            UpdateShape();
        }
    }

    void UpdateShape()
    {
        for (int i = 0; i < shapeObjects.Length; i++)
        {
            shapeObjects[i].SetActive(i == currentIndex);
        }
    }


}
