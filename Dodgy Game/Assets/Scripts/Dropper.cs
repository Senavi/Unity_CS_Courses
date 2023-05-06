using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public Rigidbody rigid;
    public MeshRenderer meshRenderer;
   // public MeshRenderer meshRenderer; 
    public float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigid.useGravity = false;
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    GetTimeFlow(time);
    }

    void GetTimeFlow(float time)
    {
        if(Time.time > time) {
            meshRenderer.enabled = true;
            rigid.useGravity = true;
        }
}
}
