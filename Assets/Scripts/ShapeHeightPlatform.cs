using UnityEngine;

public class ShapeHeightPlatform : MonoBehaviour
{
    public ShapeHeightCamera ShapeHeightCamera;
    public GameObject spawnerPlatform;
    public Vector3 transformOverride;

    [Header("Platform Smooth Movement Settings")]
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnerPlatform.transform.position = Vector3.SmoothDamp(spawnerPlatform.transform.position, ShapeHeightCamera.totalHeight + transformOverride, ref velocity, smoothTime );
    }
}
