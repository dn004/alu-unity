using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public TyAnimations tyAnimations;
    public AudioSource audioSource;
    public AudioClip footstepsGrass;
    public AudioClip footstepsStone;

    private string currentSurface = "Grass"; 
    public void PlayFootstepSound()
    {
        if (tyAnimations.TyAnimator.GetBool("JumpInitiated"))
            return;

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

    private void OnCollisionEnter(Collision collision)
    {
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
}
