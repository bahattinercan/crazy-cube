using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatformPrefabs;
    public GameObject breakablePlatformPrefab;

    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;
    private int platformSpawnCount;
    public float minX = -2f, maxX = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            platformSpawnCount++;
            float playerX = playerMovement.transform.position.x;
            Vector3 temp = transform.position;

            float max = playerX + 1.5f;
            float min = playerX - 1.5f;
            if (min < minX)
                min = minX;
            if (max > maxX)
                max = maxX;

            temp.x = Random.Range(min, max);
            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2)
            {
                if (Random.Range(0, 2) == 1)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(
                        movingPlatformPrefabs[Random.Range(0, movingPlatformPrefabs.Length)],
                        temp,
                        Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) == 1)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    max = playerX + 2f;
                    min = playerX - 2f;
                    if (min < minX)
                        min = minX;
                    if (max > maxX)
                        max = maxX;

                    temp.x = Random.Range(min, max);
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) == 1)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatformPrefab, temp, Quaternion.identity);
                }
                platformSpawnCount = 0;
            }

            if (newPlatform)
                newPlatform.transform.parent = transform;
            currentPlatformSpawnTimer = 0f;
        }
    }
}