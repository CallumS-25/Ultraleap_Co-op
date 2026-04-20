
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ReadyUpSystem : MonoBehaviour
{

    [Header("Timer Settings")]
    [SerializeField]
    public Canvas welcomeCanvas;
    [SerializeField]
    public GameObject countdownCanvas;
    [SerializeField]
    public Canvas heightScoreCanvas;
    [SerializeField]
    public TMP_Text countdownText;
    public float countdownTimer;
    public float countdownEnd;

    [Header("Callers")]
    [SerializeField]
    public EndGameSystem EndGameSystem;
    [SerializeField]
    public ShapeSpawner ShapeSpawner;
    [SerializeField]
    public List<SpawnerCollider> SpawnerColliders;
    [SerializeField]
    public UIHeightScore UIHeightScore;

    [Header("Ready Up Settings")]
    [SerializeField]
    public bool readyP1;
    [SerializeField]
    TextMeshProUGUI readyP1Text;
    [SerializeField]
    public bool readyP2;
    [SerializeField]
    TextMeshProUGUI readyP2Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShapeSpawner.gameObject.SetActive(false);
        countdownTimer = 3;
        countdownEnd = countdownTimer;
        countdownCanvas.gameObject.SetActive(false);
    }

    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(countdownEnd / 60);
        float secs = Mathf.FloorToInt(countdownEnd % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", mins, secs);
    }

    public void ToggleReadyP1()
    {
        readyP1 = true;
        readyP1Text.color = Color.green;
        readyP1Text.text = "READY";
    }

    public void ToggleNotReadyP1()
    {
        readyP1 = false;
        readyP1Text.color = Color.black;
        readyP1Text.text = "NOT READY";
    }

    public void ToggleReadyP2()
    {
        readyP2 = true;
        readyP2Text.color = Color.green;
        readyP2Text.text = "READY";
    }

    public void ToggleNotReadyP2()
    {
        readyP2 = false;
        readyP2Text.color = Color.black;
        readyP2Text.text = "NOT READY";
    }

    // Update is called once per frame
    void Update()
    {
        if (readyP1 && readyP2 == true) 
        {
            //Debug.LogWarning("Tick...");
            countdownCanvas.gameObject.SetActive(true);
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
                heightScoreCanvas.gameObject.SetActive(true);
                ShapeSpawner.gameObject.SetActive(true);
                SpawnerColliders.GetRange(0, SpawnerColliders.Count).ForEach(spawner => spawner.canSpawn = true);
                GameObject[] i = GameObject.FindGameObjectsWithTag("Shape");
                foreach (GameObject go in i)
                {
                    Destroy(go);
                }
                UIHeightScore.currentHeightScore = 0;
                UIHeightScore.highestHeightScore = 0;
                EndGameSystem.gameStarted = true;
                //Debug.LogWarning("TIME'S UP!");
            }
            if (EndGameSystem.gameStarted == true)
            {
                countdownCanvas.gameObject.SetActive(false);
            }
        }
        else
        {
            welcomeCanvas.enabled = true;
            countdownEnd = 3;
            countdownCanvas.gameObject.SetActive(false);
            //Debug.LogWarning("TIMER RESET");
        }
    }
}
