using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    [SerializeField]
    internal ManagerScript managerScript;

    [SerializeField]
    internal GameObject[] blueCircle;

    public void BlueCircle(Vector3 contactPoint)
    {
        GameObject parryPoint = GameObject.Instantiate(blueCircle[0]);
        parryPoint.transform.position = new Vector3(contactPoint.x, contactPoint.y, -9f);
        Destroy(parryPoint, 0.25f);
    }
}
