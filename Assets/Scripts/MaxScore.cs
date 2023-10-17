using UnityEngine;

public class MaxScore : MonoBehaviour
{
    public TextMesh text;
    public ScoreController score;
    private int maxScore;

    void Start()
    {
        Load();
    }


    void Update()
    {
        if (score.score > maxScore)
        {
            maxScore = score.score;
            Save();
        }
    }


    public void ResetMaxScore()
    {
        maxScore = 0;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);
        text.text = $"MAX SCORE\n{maxScore}";
    }
    private void Load()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        text.text = $"MAX SCORE\n{maxScore}";
    }

}
