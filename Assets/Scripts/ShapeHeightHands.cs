
using Leap;
using UnityEngine;

public class ShapeHeightHands : MonoBehaviour

{
    public ShapeHeightCamera ShapeHeightCamera;
    [SerializeField]
    public LeapServiceProvider Hands;
    [SerializeField]
    public Vector3 handsTransformOverride;


    [Header("Hand Smooth Movement Settings")]
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 0);

    // Update is called once per frame
    void LateUpdate()
    {
        Hands.transform.position = Vector3.SmoothDamp(Hands.transform.position, ShapeHeightCamera.totalHeight + handsTransformOverride, ref velocity, smoothTime);
    }
}
