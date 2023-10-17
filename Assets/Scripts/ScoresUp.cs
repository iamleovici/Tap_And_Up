using UnityEngine;

public class ScoresUp : MonoBehaviour
{
    public GameObject prefab;
    public PlatformController platform;
    private int score = 0;

    void Update()
    {
        if (platform.score > score)
        {
            GameObject scoresUp =  Instantiate(prefab, transform);
            Destroy(scoresUp, 1f);
            score = platform.score;
        }
    }
}
