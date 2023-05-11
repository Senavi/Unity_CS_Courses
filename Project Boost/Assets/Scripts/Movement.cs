using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
Rigidbody rb;
AudioSource audioSource;
[SerializeField] private float Thread = 10f;
[SerializeField] private float RotationThread = 2f;

    // Start is called before the first frame update
    void Start()
    {
rb = GetComponent<Rigidbody>();
audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
ProcessThrust();
ProcessRotate();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
rb.AddRelativeForce(Vector3.up*Thread*Time.deltaTime);
if (!audioSource.isPlaying)
{
audioSource.Play();
}
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotate()
    {
       if (Input.GetKey(KeyCode.D))
        {
       ApplyRotation(RotationThread);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-RotationThread);
        }
    }


    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(-Vector3.forward*rotationThisFrame*Time.deltaTime);
        rb.freezeRotation = false;
    }
}
