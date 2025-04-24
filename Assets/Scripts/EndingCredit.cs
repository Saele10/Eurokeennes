using UnityEngine;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{

    public float scrollspeed = 60f;

    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollspeed * Time.deltaTime);
    }
}
