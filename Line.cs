using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{
    public Vector3 vertice1;
    public Vector3 vertice2;

    public Line(Vector3 vertice1, Vector3 vertice2)
    {
        this.vertice1 = vertice1;
        this.vertice2 = vertice2;
    }
}
