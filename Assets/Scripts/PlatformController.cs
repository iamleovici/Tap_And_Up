using System;
using UnityEngine;


public class PlatformController : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject playerBody;
    private GameObject newPlatform;
    public GameObject startPlatform;
    private Renderer platformColor;
    public int score;

    public static Action onTouch;

    public int SideOfPlatform { get; private set; } = 1;

    private void Start()
    {
        score = 0;
        newPlatform = startPlatform;
    }
    public void SpawnPlatform()
    {
        float platformPositionX = UnityEngine.Random.Range(0.5f, 2.2f);
        float offsetPositionY = UnityEngine.Random.Range(3f, 6f);
        float randomScale = UnityEngine.Random.Range(0.3f, 1.5f);


        Vector3 spawnPosition = new Vector3(platformPositionX * SideOfPlatform, newPlatform.transform.position.y - offsetPositionY, 0f);
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity, transform);
        platform.transform.localScale = new Vector3(randomScale, platform.transform.localScale.y, platform.transform.localScale.z);
        newPlatform = platform;
        platformColor = newPlatform.GetComponent<Renderer>();


        SideOfPlatform = -SideOfPlatform;


    }


    public void platformWasTouched()
    {
        score++;
        platformColor.material.color = Color.red;
        Destroy(newPlatform, 5f);
        SpawnPlatform();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTouch?.Invoke();
            platformWasTouched();

        }
    }
}
