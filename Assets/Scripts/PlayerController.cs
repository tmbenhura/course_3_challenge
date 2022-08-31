using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public float jumpForce = 1f;
    public float gravityModifier = 1f;
    public bool gameOver = false;
    public ParticleSystem crashParticleSystem;
    public ParticleSystem dirtParticleSystem;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource audioSource;
    private Animator playerAnimator;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            isOnGround = false;
            audioSource.PlayOneShot(jumpSound, 1f);
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticleSystem.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            audioSource.PlayOneShot(crashSound, 1f);
            crashParticleSystem.Play();
            dirtParticleSystem.Stop();
            Debug.Log("Game Over");
        }
    }
}
