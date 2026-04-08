using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndGameSystem : MonoBehaviour
{
    [Header("Script Callers")]
    //SCRIPTS
    [SerializeField]
    public List<ShapeHeightPlatform> ShapeHeightPlatform;
    [SerializeField]
    public UIHeightScore UIHeightScore;
    [SerializeField]
    public ReadyUpSystem ReadyUpSystem;
    [SerializeField]
    ShapeSpawner ShapeSpawner;
    [Header("Children to Total Height")]
    //Children of Total Height
    [SerializeField]
    public GameObject totalHeight;
    [Header("Game Object Callers")]
    //HANDS
    [SerializeField]
    public GameObject handPhysics;
    [SerializeField]
    public GameObject hands;
    //LEADERBOARD
    [SerializeField]
    public GameObject Leaderboard;
    [SerializeField]
    public GameObject gameOver;
    [SerializeField]
    public TMP_Text finalScoreText;

    [Header("Timer Settings")]
    //UI
    [SerializeField]
    public Canvas gameTimerCanvas;
    [SerializeField]
    public TMP_Text gameTimerText;
    //GAME TIMER
    public float gameTimer;
    private float gameTimerEnd;
    //DELAY ENDGAME
    private bool finishDelay;
    private float gameFinishedTimer;

    [Header("General Settings")]
    //GAME STATUS
    [SerializeField]
    public bool gameStarted;
    [SerializeField]
    public bool gameTimerFinished;
    //GAME FINISHED UI
    [SerializeField]
    public TMP_Text gameFinishedText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 3;
        gameTimerEnd = gameTimer;
        gameTimerCanvas.gameObject.SetActive(false);
        gameFinishedTimer = 3;
    }

    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(gameTimerEnd / 60);
        float secs = Mathf.FloorToInt(gameTimerEnd % 60);

        gameTimerText.text = string.Format("Timer: " + "{0:00}:{1:00}", mins, secs);
    }

    public void GameFinished()
    {
       UIHeightScore.scoreCanvas.gameObject.SetActive(false);
        gameFinishedText.gameObject.SetActive(true);
        ShapeHeightPlatform.GetRange(0, ShapeHeightPlatform.Count).ForEach(platform => platform.gameObject.SetActive(false));
        handPhysics.gameObject.SetActive(false);
        hands.gameObject.SetActive(false);
        gameTimerText.gameObject.SetActive(false);
        //Debug.LogWarning("GAME TIME'S UP!");
    }
    public void ShowResults()
    {
        gameFinishedText.gameObject.SetActive(false);
        Leaderboard.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        finalScoreText.color = Color.green;
        finalScoreText.text = UIHeightScore.highestHeightScore.ToString("0");
    }

    public void Restart()
    {
        //ShapeSpawners
        GameObject[] i = GameObject.FindGameObjectsWithTag("Shape");
        foreach (GameObject go in i)
        {
            Destroy(go);
        }
        gameTimer = 3;
        gameFinishedTimer = 3;
        ReadyUpSystem.Ready = false;
        finishDelay = false;
        gameStarted = false;
        gameFinishedText.gameObject.SetActive(false);
        ReadyUpSystem.welcomeCanvas.gameObject.SetActive(true);
        ShapeSpawner.gameObject.SetActive(false);
        Leaderboard.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        handPhysics.gameObject.SetActive(true);
        hands.gameObject.SetActive(true);
        gameTimerEnd = gameTimer;
        FormatToMinSec();
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
                GameFinished();
                finishDelay = true;
            }
        }
        if (finishDelay)
        {
            if (gameFinishedTimer > 0)
            {
                gameFinishedTimer -= Time.deltaTime;
            }
            else if (gameFinishedTimer <= 0)
            {
                ShowResults();
            }
        }
    }
}
