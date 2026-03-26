
using Leap;
using UnityEngine;

public class ShapeHeightHands : MonoBehaviour

{
    private Vector3 handsTransformOverride;
    public ShapeHeightCamera ShapeHeightCamera;
    public LeapServiceProvider Hands;
    

    [Header("Hand Smooth Movement Settings")]
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handsTransformOverride.y = -0.5f;
        handsTransformOverride.z = 0.6f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Hands.transform.position = Vector3.SmoothDamp(Hands.transform.position, ShapeHeightCamera.totalHeight + handsTransformOverride , ref velocity, smoothTime);
    }
}
