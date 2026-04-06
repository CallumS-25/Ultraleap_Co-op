
using UnityEngine;

public class ShapeHeightCamera : MonoBehaviour
{

    public Vector3 totalHeight;
    public Camera Camera;
    public GameObject floatingSpawners;
    public GameObject cubeTracker;

    [Header("Camera Smooth Movement Settings")]
    public float smoothTime = 15;
    public Vector3 velocity = new Vector3(0, 0, 0);

    //Visually displays the bounding box

    private void OnDrawCube()
    {
        
        //Draw each child's bounds
        foreach (var child in GetComponentsInChildren<Collider>())
        {
            cubeTracker.transform.localScale = child.bounds.center + child.bounds.size;
        }
        var maxBounds = GetMaxBounds(gameObject);
        cubeTracker.transform.localScale = maxBounds.center + maxBounds.size;
        totalHeight.y = maxBounds.size.y + 0.1f;
        //Debug.Log("Total height is " + totalHeight);
    }

    Bounds GetMaxBounds(GameObject parent)
    {
        var total = new Bounds(parent.transform.position, Vector3.zero);
        foreach (var child in parent.GetComponentsInChildren<Collider>())
        {
            total.Encapsulate(child.bounds);
        }
        return total;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        OnDrawCube();
        Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, totalHeight, ref velocity, smoothTime);
    }
}
