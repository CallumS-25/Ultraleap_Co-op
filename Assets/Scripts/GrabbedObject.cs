using Leap;
using UnityEngine;

public class GrabbedObject : MonoBehaviour
{
    public GrabDetector grabDetector;
    public ShapeHeight ShapeHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabDetector.GrabStartedThisFrame)
        {
            // Handle grab start logic here
            Debug.Log("Grab started this frame.");
        }
    }
}
