using TMPro;
using UnityEngine;

public class ReadyUpSystem : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField]
    Canvas welcomeCanvas;
    [SerializeField]
    public Canvas countdownCanvas;
    [SerializeField]
    public TMP_Text countdownText;
    public float countdownTimer;
    private float countdownEnd;

    [Header("Callers")]
    [SerializeField]
    public ShapeSpawner ShapeSpawner;

    [Header("Ready Up Settings")]
    [SerializeField]
    public bool Ready;
    [SerializeField]
    TextMeshProUGUI ReadyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdownTimer = 3;
        countdownEnd = countdownTimer;
        countdownCanvas.enabled = false;
    }

    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(countdownEnd / 60);
        float secs = Mathf.FloorToInt(countdownEnd % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }

    public void ToggleReady()
    {
        Ready = true;
        ReadyText.color = Color.green;
        ReadyText.text = "READY";
    }

    public void ToggleNotReady()
    {
        Ready = false;
        ReadyText.color = Color.black;
        ReadyText.text = "NOT READY";
    }

    // Update is called once per frame
    void Update()
    {
        if (Ready)
        {
            //Debug.LogWarning("Tick...");
            countdownCanvas.enabled = true;
            if (countdownEnd > 0)
            {
                countdownEnd -= Time.deltaTime;
                if(countdownEnd > 60)
                {
                    FormatToMinSec();
                }
                else
                {
                    countdownText.text = countdownEnd.ToString("0.0");
                }
            }
            else
            {
                welcomeCanvas.gameObject.SetActive(false);
                countdownCanvas.gameObject.SetActive(false);
                ShapeSpawner.gameObject.SetActive(true);
                //Debug.LogWarning("TIME'S UP!");
            }
        }
        else
        {
            welcomeCanvas.enabled = true;
            countdownEnd = 3;
            countdownCanvas.enabled = false;
            //Debug.LogWarning("TIMER RESET");
        }
    }
}
