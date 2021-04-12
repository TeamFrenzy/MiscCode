using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationScript : MonoBehaviour
{
    [SerializeField]
    internal ManagerScript managerScript;

    [SerializeField]
    internal Animator animator;

    [SerializeField]
    internal float tolerance;

    [SerializeField]
    internal bool tester;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("FallSpeed", managerScript.ySpeed);

        if(managerScript.crouchScript.crouching)
        {
            animator.SetBool("Crouching", true);
        }
        else
        {
            animator.SetBool("Crouching", false);
        }

        if (managerScript.slidingScript.sliding == true)
        {
            animator.SetBool("Sliding", true);
        }
        else
        {
            animator.SetBool("Sliding", false);
        }

        if (managerScript.collisionScript.grounded)
        {
            animator.SetFloat("CrashForce", managerScript.accelerationStateScript.lastVelocityY);
        }
        else
        {
            animator.SetFloat("CrashForce", 0f);
        }

        if(managerScript.balanceScript.overBoard)
        {
            animator.SetBool("OverBoard", true);
        }
        else
        {
            animator.SetBool("OverBoard", false);
        }

        if (managerScript.inertia>managerScript.boostScript.lvlSpeed[0]+0.2f && managerScript.inertia<managerScript.balanceScript.noControlThreshold && managerScript.balanceScript.riding)
        {
            animator.SetBool("Imbalanced", true);
        }
        else
        {
            animator.SetBool("Imbalanced", false);
        }

        if (managerScript.inertia >= managerScript.balanceScript.noControlThreshold)
        {
            animator.SetBool("NoControl", true);
        }
        else
        {
            animator.SetBool("NoControl", false);
        }

        if (managerScript.balanceScript.crashed)
        {
            animator.SetBool("Crashed", true);
        }
        else
        {
            animator.SetBool("Crashed", false);
        }

        if (managerScript.balanceScript.standing)
        {
            animator.SetBool("Standing", true);
        }
        else
        {
            animator.SetBool("Standing", false);
        }

        if (managerScript.parryScript.parrying)
        {
            animator.SetBool("Jogging", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Rising", false);
            animator.SetBool("Running", false);
            animator.SetBool("FastRunning", false);
            animator.SetBool("Turning", false);
            animator.SetBool("Parry", true);
        }

        if(managerScript.balanceScript.riding == true)
        {
            animator.SetBool("Riding", true);
        }
        else if (managerScript.balanceScript.riding == false)
        {
            animator.SetBool("Riding", false);
        }

        if (managerScript.jumpScript.rising && managerScript.rb.velocity.y > tolerance)
        {
            animator.SetBool("Jogging", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Turning", false);
            animator.SetBool("Rising", true);
        }

        if (managerScript.jumpScript.falling && managerScript.rb.velocity.y < -tolerance)
        {
            animator.SetBool("Rising", false);
            animator.SetBool("Falling", true);
        }

        //Horizontal Movement
        if (managerScript.collisionScript.grounded)
        {
            if(managerScript.balanceScript.riding == false)
            {
                animator.SetBool("Parry", false);
            }
            animator.SetBool("Grounded", true);
            animator.SetBool("Falling", false);

            if (managerScript.facingScript.turning)
                {
                    animator.SetBool("Jogging", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Rising", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("FastRunning", false);
                    animator.SetBool("Turning", true);
                }
            else if (managerScript.accelerationStateScript.deacceleratingX)
                {
                    if (managerScript.brakeScript.braking == true)
                {
                    animator.SetBool("Jogging", false);
                        animator.SetBool("Idle", false);
                        animator.SetBool("Rising", false);
                        animator.SetBool("Running", false);
                        animator.SetBool("FastRunning", false);
                        animator.SetBool("Turning", false);
                        animator.SetBool("Braking", true);
                    }
                }
                else if (managerScript.horizontalScript.idle && managerScript.inertia < 0.05f)
                {
                    animator.SetBool("Jogging", false);
                    animator.SetBool("Turning", false);
                    animator.SetBool("Rising", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Idle", true);
                }
                else if (managerScript.inertia > 0.1f && managerScript.inertia <= (managerScript.boostScript.lvlSpeed[0] + 0.5))
                {
                    animator.SetBool("Idle", false);
                    animator.SetBool("Turning", false);
                    animator.SetBool("Rising", false);
                    animator.SetBool("Running", false);
                animator.SetBool("Braking", false);
                animator.SetBool("Jogging", true);
                }
                else if (managerScript.inertia > (managerScript.boostScript.lvlSpeed[0] + 0.5) && managerScript.inertia <= (managerScript.boostScript.lvlSpeed[1] + 0.5))
            {
                animator.SetBool("Turning", false);
                    animator.SetBool("Rising", false);
                    animator.SetBool("Jogging", false);
                    animator.SetBool("FastRunning", false);

                animator.SetBool("Braking", false);
                animator.SetBool("Running", true);
                }
                else if (managerScript.inertia > (managerScript.boostScript.lvlSpeed[1] + 0.5) && managerScript.inertia <= (managerScript.boostScript.lvlSpeed[2] + 0.5))
            {
                animator.SetBool("Turning", false);
                    animator.SetBool("Rising", false);
                    animator.SetBool("Jogging", false);
                    animator.SetBool("Running", false);
                animator.SetBool("Braking", false);
                animator.SetBool("FastRunning", true);
                }
        }
        else if(!managerScript.collisionScript.grounded)
        {
            animator.SetBool("Grounded", false);
        }
    }
}
