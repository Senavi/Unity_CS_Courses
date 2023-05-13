using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Thread = 10f;
    [SerializeField] private float RotationThread = 2f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem LeftParticle;
    [SerializeField] ParticleSystem RightParticle;
    [SerializeField] ParticleSystem MainBoost;

    Rigidbody rb;
    AudioSource audioSource;


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
        audioSource.PlayOneShot(mainEngine);
        }
            if (!MainBoost.isPlaying) { 
            MainBoost.Play();
            }
        }
        else
        {
            audioSource.Stop();
            MainBoost.Stop();
        }
    }

    void ProcessRotate()
    {
       if (Input.GetKey(KeyCode.D))
        {
       ApplyRotation(RotationThread);

            if (!RightParticle.isPlaying) 
            { 
            RightParticle.Play();
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-RotationThread);

            if (!LeftParticle.isPlaying)
            {
                LeftParticle.Play();
            }
        }
        else
        {
            LeftParticle.Stop();
            RightParticle.Stop();
        }
    }


    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(-Vector3.forward*rotationThisFrame*Time.deltaTime);
        rb.freezeRotation = false;
    }

}
