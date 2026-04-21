using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Experimental.Rendering;

public class EndGameSystem : MonoBehaviour
{
    [Header("Script Callers")]
    //SCRIPTS
    [SerializeField]
    public UIHeightScore UIHeightScore;
    [SerializeField]
    public ReadyUpSystem ReadyUpSystem;
    [SerializeField]
    public ShapeSpawner ShapeSpawner;
    [SerializeField]
    public List<SpawnerCollider> SpawnerColliders;

    [Header("Children to Total Height")]
    //Children of Total Height
    [SerializeField]
    public GameObject totalHeight;

    [Header("Game Object Callers")]
    //HANDS
    [SerializeField]
    public List<GameObject> handPhysics;
    [SerializeField]
    public List<GameObject> hands;
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
    public TMP_Text gameOverText;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 180;
        gameTimerEnd = gameTimer;
        gameOverText.gameObject.SetActive(false);
        gameTimerText.gameObject.SetActive(false);
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
        handPhysics.GetRange(0, handPhysics.Count).ForEach(handphys => handphys.gameObject.SetActive(false));
        hands.GetRange(0, hands.Count).ForEach(HANDS => HANDS.gameObject.SetActive(false));
        gameTimerText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        ShapeSpawner.gameObject.SetActive(false);
        SpawnerColliders.GetRange(0, SpawnerColliders.Count).ForEach(spawner => spawner.canSpawn = true);
        //Debug.LogWarning("GAME TIME'S UP!");
    }
    public void ShowResults()
    {
        gameOverText.gameObject.SetActive(false);
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
        gameTimer = 180;
        gameFinishedTimer = 3;
        ReadyUpSystem.readyP1 = false;
        ReadyUpSystem.readyP2 = false;
        finishDelay = false;
        gameStarted = false;
        ReadyUpSystem.welcomeCanvas.gameObject.SetActive(true);
        Leaderboard.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        handPhysics.GetRange(0, handPhysics.Count).ForEach(handphys => handphys.gameObject.SetActive(true));
        hands.GetRange(0, hands.Count).ForEach(HANDS => HANDS.gameObject.SetActive(true));
        gameTimerEnd = gameTimer;
        FormatToMinSec();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            //Debug.LogWarning("Tick...");
            gameTimerText.gameObject.SetActive(true);
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
