using UnityEngine;

public class ShapeHeightPlatform : MonoBehaviour
{
    public ShapeHeightCamera ShapeHeightCamera;
    public GameObject spawnerPlatform;
    public Vector3 transformOverride;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //WARNING: SHAPES SPAWNING ON THE PLATFORM WON'T SPAWN ON THE PLATFORM DUE TO THE SHAPES BEING IN THE TOTAL HEIGHT, MOVING THE CAMERA AND THEREFORE THE FLOATING SPAWNER.
        spawnerPlatform.transform.position = ShapeHeightCamera.totalHeight + transformOverride;
    }
}
