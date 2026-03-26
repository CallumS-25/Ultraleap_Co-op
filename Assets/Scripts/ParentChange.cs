
using UnityEngine;

public class ParentChange : MonoBehaviour
{
    public GameObject Object;

    Rigidbody body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.useGravity == false)
        {
            transform.parent = Object.transform;
        }

    }
}
