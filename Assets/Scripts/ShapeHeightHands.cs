using Leap;
using Unity.VisualScripting;
using UnityEngine;

public class ShapeHeightHands : MonoBehaviour

{
    private Vector3 handsTransformOverride;
    public ShapeHeightCamera ShapeHeightCamera;
    public LeapServiceProvider Hands;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handsTransformOverride.y = -0.5f;
        handsTransformOverride.z = 0.6f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Hands.transform.position = ShapeHeightCamera.totalHeight + handsTransformOverride;
    }
}
