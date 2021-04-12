using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovementScript : MonoBehaviour
{
    public float movementController;
    public float initialPosition;
    public float exponent;
    bool forward;

    private void Awake()
    {
        initialPosition = transform.position.y;
        forward = true;
        movementController = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if(movementController<=1f && forward)
        {
            movementController = movementController + (Time.deltaTime/exponent);
        }

        if (movementController > 1f)
        {
            forward = false;
        }

        if (movementController>-1f && !forward)
        {
            movementController = movementController - (Time.deltaTime / exponent);
        }

        if (movementController <= -1f && !forward)
        {
            forward = true;
        }

        transform.position = new Vector3(transform.position.x, initialPosition-movementController, transform.position.z);
    }
}
