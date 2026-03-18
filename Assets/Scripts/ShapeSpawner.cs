using Leap;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Shapes and Spawn Points")]
    public GameObject[] Shapes;
    public GameObject Parent;
    public GameObject[] spawnPoints;
    public SpawnerCollider[] colliders;

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
        int randomSpawnPosition = Random.Range(0, spawnPoints.Length);
        
        if (stopSpawning)
        {
            CancelInvoke(nameof(SpawnObject));
        }

        if (colliders[randomSpawnPosition].canSpawn == true)
        {
            GameObject obj = Instantiate(Shapes[randomIndex], spawnPoints[randomSpawnPosition].transform.position, Quaternion.identity, transform.parent);
            obj.GetComponent<ParentChange>().Object = Parent;
            Debug.Log(obj + " is now " + Parent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
