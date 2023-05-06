using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotateSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        float yValue = rotateSpeed*Time.deltaTime;
        transform.Rotate(0, yValue, 0);
    }
}
