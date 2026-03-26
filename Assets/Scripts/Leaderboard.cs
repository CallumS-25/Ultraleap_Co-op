
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> Names;
    [SerializeField]
    private List<TextMeshProUGUI> Scores;

    private string publicLeaderBoardKey = "b42592cc5cf1d4f645ad63b603bd70fc71c2826ffdf4604741bf60fc995d9725";


    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) => 
        {
            int loopLength = (msg.Length < Names.Count ? msg.Length : Names.Count);
            for (int i = 0; i < loopLength; ++i)
            {
                Names[i].text = msg[i].Username;
                Scores[i].text = msg[i].Score.ToString() + "M";
            }
        })); 
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, ((msg) =>
        {
            username.Substring(0, 3);
            LeaderboardCreator.ResetPlayer();
            GetLeaderboard();
        }));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GetLeaderboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
