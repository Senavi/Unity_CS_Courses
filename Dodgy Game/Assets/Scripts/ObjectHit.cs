using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] Color newColour = new Color(248, 78, 107);
private void OnCollisionEnter(Collision other)
{
        if(other.gameObject.tag == "Player")
GetComponent<MeshRenderer>().material.color = newColour;

}
}
