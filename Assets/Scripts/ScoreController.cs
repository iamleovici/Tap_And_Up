using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMesh text;
    public PlatformController platform;
    public int score;

    private void Start()
    {
        score = 0;
    }
    void Update()
    {
        text.text = platform.score.ToString();
        score = platform.score;
    }
}
