
using UnityEngine;

public class SpawnerCollider : MonoBehaviour
{
    public bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shape")
        {
            canSpawn = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shape")
        {
            canSpawn = true;
        }

    }
}
