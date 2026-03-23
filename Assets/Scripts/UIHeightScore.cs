using TMPro;
using UnityEngine;

public class UIHeightScore : MonoBehaviour
{
    public ShapeHeightCamera ShapeHeight;
    public GameObject heightMeasurer;
    public Vector3 transformOverride;

    [Header("Height Measurer Score")]
    public float currentHeightScore;
    public float highestHeightScore;

    [Header("Height Measurer Smooth Movement Settings")]
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 0);

    [Header("UI")]
    public Canvas scoreCanvas;
    [SerializeField]
    public TMP_Text highestScoreText;
    [SerializeField]
    public TMP_Text currentScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        heightMeasurer.transform.position = Vector3.SmoothDamp(heightMeasurer.transform.position, ShapeHeight.totalHeight + transformOverride, ref velocity, smoothTime);
        currentHeightScore = ShapeHeight.totalHeight.y * 10 - 1;

        if (currentHeightScore > highestHeightScore)
        {
            highestHeightScore = currentHeightScore;
        }

        currentScoreText.text = "Current Score: " + currentHeightScore.ToString("F1") + "M";
        highestScoreText.text = "Highest Score: " + highestHeightScore.ToString("F1") + "M";
    }
}
