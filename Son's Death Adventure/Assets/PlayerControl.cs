using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    [SerializeField] float moveSpeed = 10f;

    // Update is called once per frame
public void Update()
{
    float horizontalInput = Input.GetAxis("Horizontal") * 15 * Time.deltaTime;
    float verticalInput = Input.GetAxis("Vertical") * 15 * Time.deltaTime;

    anim.SetFloat("Horizontal", horizontalInput);
    anim.SetFloat("Vertical", verticalInput);

    transform.Translate(horizontalInput, 0, verticalInput);
}

}
