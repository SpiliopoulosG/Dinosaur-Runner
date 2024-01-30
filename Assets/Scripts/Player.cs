using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public float volume = 1.0f;
    public AudioSource audioSource;
    public AudioClip clip;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
            PlayJumpSound();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void PlayJumpSound()
    {
        if (audioSource)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
      Debug.Log("Collided with other Object");
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        }    
    }
}
