using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {transform.Translate(1,0,0);}

        else if (Input.GetKeyDown(KeyCode.A))
        {{transform.Translate(-1,0,0);}}
    }
}
