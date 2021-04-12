using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Preah")
        {
            if(collision.collider.GetComponent<ManagerScript>().parryScript.parryTimer<=0f)
            {
                collision.collider.GetComponent<CollisionScript>().grounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Preah")
        {
            if (collision.collider.GetComponent<ManagerScript>().parryScript.parryTimer <= 0f)
            {
                collision.collider.GetComponent<CollisionScript>().grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Preah")
        {
            collision.collider.GetComponent<CollisionScript>().grounded = false;
        }
    }
}
