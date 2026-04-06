using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Callers")]
    [SerializeField]
    public List<ShapeHeightPlatform> ShapeHeightPlatform;
    [SerializeField]
    public GameObject HandPhysics;
    [SerializeField]
    public GameObject Hands;

    [Header("Timer Settings")]
    [SerializeField]
    public Canvas gameTimerCanvas;
    [SerializeField]
    public TMP_Text gameTimerText;
    public float gameTimer;
    private float gameTimerEnd;

    [Header("General Settings")]
    [SerializeField]
    public bool gameStarted;
    [SerializeField]
    public bool gameTimerFinished;
    [SerializeField]
    public TMP_Text gameFinishedText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 180;
        gameTimerEnd = gameTimer;
        gameTimerCanvas.gameObject.SetActive(false);
    }

    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(gameTimerEnd / 60);
        float secs = Mathf.FloorToInt(gameTimerEnd % 60);

        gameTimerText.text = string.Format("Timer: " + "{0:00}:{1:00}", mins, secs);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            //Debug.LogWarning("Tick...");
            gameTimerCanvas.gameObject.SetActive(true);
            if (gameTimerEnd >= 0)
            {
                gameTimerEnd -= Time.deltaTime;
                if (gameTimerEnd > 60)
                {
                    FormatToMinSec();
                }
                else
                {
                    gameTimerText.text = gameTimerEnd.ToString("Timer: " + "0.0");
                }
            }
            else
            {
                gameFinishedText.gameObject.SetActive(true);
                ShapeHeightPlatform.GetRange(0, ShapeHeightPlatform.Count).ForEach(platform => platform.gameObject.SetActive(false));
                HandPhysics.gameObject.SetActive(false);
                Hands.gameObject.SetActive(false);
                gameTimerText.gameObject.SetActive(false);
                //Debug.LogWarning("GAME TIME'S UP!");
            }
        }
    }
}
