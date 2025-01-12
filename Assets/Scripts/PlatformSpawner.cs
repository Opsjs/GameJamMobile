using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platform Prefabs")]
    [SerializeField] GameObject[] platformPrefabs;

    [Header("Values")]
    [SerializeField] float minX = -2.5f; 
    [SerializeField] float maxX = 2.5f; 
    [SerializeField] float minY = 1.5f; 
    [SerializeField] float maxY = 2.5f; 
    [SerializeField] float platformSpawnThreshold = 5f; 

    private float highestPlatformY = 0f; 

    void Update()
    {
        if (Camera.main.transform.position.y + platformSpawnThreshold > highestPlatformY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(randomX, highestPlatformY + randomY, 0);

        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject platform = platformPrefabs[randomIndex];
        if (platform.CompareTag("MovingPlatform"))
        {
            Debug.Log("Moving Platform");
            randomX = Camera.main.transform.position.x;
        }

        Instantiate(platform, spawnPosition, Quaternion.identity);

        highestPlatformY += randomY;
    }
}
