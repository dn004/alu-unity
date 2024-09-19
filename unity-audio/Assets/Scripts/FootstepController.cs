using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public TyAnimations tyAnimations;
    public AudioSource audioSource;
    public AudioClip footstepsGrass;
    public AudioClip footstepsStone;
    public AudioClip landingGrass;
    public AudioClip landingStone;

    private string currentSurface = "Grass";
    private bool isFalling = false;
    void Update()
    {
        DetectFalling();
    }

    public void PlayFootstepSound()
    {
        if (tyAnimations.TyAnimator.GetBool("JumpInitiated") || isFalling)
            return;

        if (!audioSource.isPlaying)
        {
            if (currentSurface == "Grass")
            {
                audioSource.clip = footstepsGrass;
            }
            else if (currentSurface == "Stone")
            {
                audioSource.clip = footstepsStone;
            }

            audioSource.Play();
        }
    }

    private void DetectFalling()
    {
        if (GetComponent<Rigidbody>().velocity.y < -0.1f)
        {
            isFalling = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFalling)
        {
            PlayLandingSound();
            isFalling = false;
        }

        if (collision.gameObject.CompareTag("Grass"))
        {
            currentSurface = "Grass";
        }
        else if (collision.gameObject.CompareTag("Stone"))
        {
            currentSurface = "Stone";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass") || collision.gameObject.CompareTag("Stone"))
        {
            currentSurface = "Grass";
        }
    }

    private void PlayLandingSound()
    {
        if (!audioSource.isPlaying)
        {
            if (currentSurface == "Grass")
            {
                audioSource.clip = landingGrass;
            }
            else if (currentSurface == "Stone")
            {
                audioSource.clip = landingStone;
            }

            audioSource.Play();
        }
    }
}
