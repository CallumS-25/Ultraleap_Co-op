using Leap;
using UnityEngine;

public class ShapeHeightCamera : MonoBehaviour
{

    public Vector3 totalHeight;
    public Camera Camera;
    //Visually displays the bounding box

    private void OnDrawGizmos()
    {
        
        //Draw each child's bounds
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.1f);
        foreach (var child in GetComponentsInChildren<Collider>())
        {
            Gizmos.DrawCube(child.bounds.center, child.bounds.size);
        }
        Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        var maxBounds = GetMaxBounds(gameObject);
        Gizmos.DrawCube(maxBounds.center, maxBounds.size);
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
        //if (Vector3.Distance) << maybe use this???
        Camera.transform.position = totalHeight;
    }
}
