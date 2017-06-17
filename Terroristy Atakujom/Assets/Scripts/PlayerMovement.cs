using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5f;
    public float Jump = 25f;
    public float x = 0f;
    private Rigidbody rb;
    private bool grounded;

    public AudioClip jumpSound;
    private AudioSource source;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale != 0) {
            x = Input.GetAxis("Horizontal");
            rb.AddForce(Speed * x, 0, 0);

            if (!grounded && rb.velocity.y == 0)
            {
                grounded = true;
            }

            if (Input.GetButtonDown("Jump") && grounded)
            {
                rb.AddForce(transform.up * Jump);
                float vol = 1.0f;
                source.PlayOneShot(jumpSound, vol);
                grounded = false;
            }
        }
    }
}

