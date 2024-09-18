using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyAnimations : MonoBehaviour
{
    public Animator TyAnimator;

    void Update()
    {
        playerIsJumping();
        playerIsMoving();
    }

    public void playerIsMoving()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            TyAnimator.SetBool("MoveInitiated", true);
        }
        else
        {
            TyAnimator.SetBool("MoveInitiated", false);
        }
    }

    public void playerIsJumping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TyAnimator.SetBool("JumpInitiated", true);
        }
        else
        {
            TyAnimator.SetBool("JumpInitiated", false);
        }
    }
}
