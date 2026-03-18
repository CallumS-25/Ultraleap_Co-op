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
        spawnerPlatform.transform.position = ShapeHeightCamera.totalHeight + transformOverride;
    }
}
