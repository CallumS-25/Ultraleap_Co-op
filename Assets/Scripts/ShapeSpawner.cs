using Leap;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Shapes and Spawn Points")]
    public GameObject[] Shapes;
    public GameObject Parent;
    public GameObject[] spawnPoints;

    [Header("Spawn Settings")]
    public bool stopSpawning;
    public float spawnTimer;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnTimer, spawnDelay);
    }

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, Shapes.Length);
        int randomSpawnPosition = (Random.Range(0, spawnPoints.Length));

        Instantiate(Shapes[randomIndex], spawnPoints[randomSpawnPosition].transform.position, Quaternion.identity).transform.parent = Parent.transform;

        if (stopSpawning)
        {
            CancelInvoke(nameof(SpawnObject));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
