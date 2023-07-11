using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float thrustPower = 1f;
    [SerializeField] public float rotationPower = 2f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    Transform tm;
    AudioSource audioSource;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    [SerializeField] ParticleSystem mainThrusterParticles;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            RotationLeft();

        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            RotationRight();

        }
        else
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();
        }

    }

    void StartThrusting()
    {
        rb.AddRelativeForce(0, 1, 0 * thrustPower * Time.deltaTime);
        mainThrusterParticles.Play();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainThrusterParticles.Stop();
    }


    private void RotationRight()
    {
        ApplyRotation(-rotationPower);
        rightThrusterParticles.Play();
        Debug.Log("Rotated Right");

        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    private void RotationLeft()
    {
        ApplyRotation(rotationPower);
        Debug.Log("Rotated Left");

        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotation
        tm.Rotate(0, 0, 1 * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //freezing rotation so we can manually rotation
    }
}
