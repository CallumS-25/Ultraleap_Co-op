using Leap;
using UnityEngine;

public class DestroyShape : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shape"))
        {
            Destroy(other.gameObject);
        }
    }
}
