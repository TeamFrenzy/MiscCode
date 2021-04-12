using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Preah")
        {
            collision.collider.GetComponent<WallClimbScript>().wallHanging = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Preah")
        {
            collision.collider.GetComponent<WallClimbScript>().wallHanging = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Preah")
        {
            collision.collider.GetComponent<WallClimbScript>().wallHanging = false;
        }
    }
}
