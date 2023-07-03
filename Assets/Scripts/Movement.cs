using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float thrustPower = 1f;
    [SerializeField] public float rotationPower = 2f;
    Rigidbody rb;
    Transform tm;
    AudioSource audioSource;



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
            rb.AddRelativeForce(0, 1, 0 * thrustPower * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }

    }

        void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationPower);
            Debug.Log("Rotated Left");
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationPower);
            Debug.Log("Rotated Right");
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotation
        tm.Rotate(0, 0, 1 * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //freezing rotation so we can manually rotation
    }
}
