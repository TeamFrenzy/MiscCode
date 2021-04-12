using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    [SerializeField]
    internal JumpScript jumpScript;

    [SerializeField]
    internal CollisionScript collisionScript;

    [SerializeField]
    internal DebugScript debugScript;

    [SerializeField]
    internal EffectScript effectScript;

    [SerializeField]
    internal ParryScript parryScript;

    [SerializeField]
    internal HorizontalScript horizontalScript;

    [SerializeField]
    internal AntiGravScript antiGravScript;

    [SerializeField]
    internal BoostScript boostScript;

    [SerializeField]
    internal BalanceScript balanceScript;

    [SerializeField]
    internal BrakeScript brakeScript;

    [SerializeField]
    internal WallClimbScript wallClimbScript;

    [SerializeField]
    internal MovementAnimationScript movementAnimationScript;

    [SerializeField]
    internal FacingScript facingScript;

    [SerializeField]
    internal AccelerationStateScript accelerationStateScript;

    [SerializeField]
    internal CrouchScript crouchScript;

    [SerializeField]
    internal SlidingScript slidingScript;

    [SerializeField]
    internal Rigidbody rb;

    [SerializeField]
    internal float xSpeed;

    [SerializeField]
    internal float ySpeed;

    [SerializeField]
    internal float inertia;

    [SerializeField]
    internal float vInertia;

    [SerializeField]
    internal float forceTolerance;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        xSpeed = rb.velocity.x;
        ySpeed = rb.velocity.y;
        inertia = Mathf.Abs(rb.velocity.x);
        vInertia = Mathf.Abs(rb.velocity.y);

        if (antiGravScript.antiGrav == true)
        {
            forceTolerance = 10f;
        }
        else if (antiGravScript.antiGrav == false)
        {
            forceTolerance = inertia;
        }
    }
}
