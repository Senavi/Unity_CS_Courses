using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreParentScale : MonoBehaviour
{
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial scale
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the object's scale to its initial scale divided by the parent's scale
        // This effectively cancels out the parent's scaling
        transform.localScale = initialScale;
    }
}
