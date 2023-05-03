using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{

[SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime;
        float zValue = Input.GetAxis("Vertical")*Time.deltaTime;
        float xSpeed = xValue*moveSpeed;
        float zSpeed = zValue*moveSpeed;

        transform.Translate(xSpeed, 0,zSpeed);
    }



}
