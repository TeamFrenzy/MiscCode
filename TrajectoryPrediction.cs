using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aIManagerScript;

    [SerializeField]
    internal GameObject marker;

    public float x;
    public Vector3 initialVelocity;
    public Vector3 initialPosition;
    public Vector3 lineVector;
    public Vector3 testVectorPosition;
    public Vector3 p1;
    public Vector3 p2;
    public Shader lineShader;
    //La relacion entre la velocidad y la gravedad determina la longitud de la parabola. Mientras menos velocidad, menor distancia cubierta.
    //Y varia constantemente en base a la relacion entre velocidad y gravedad. X, en cambio, siempre es contante.
    //La velocidad en y determina la altura maxima.

    private void Start()
    {
        DrawLine(new Vector3(10, 3), new Vector3(-10, -7), Color.red);
        DrawLine(new Vector3(0, -20), new Vector3(0, 20), Color.blue);
        DrawLine(new Vector3(-20,0), new Vector3(20,0), Color.blue);
        Vector3 testIntersection = GetIntersection(lineVector, initialVelocity, initialPosition);
        Debug.Log("testIntersection: " + testIntersection);
        //Debug.Log("IsPointInLIne: " + IsPointInLine(new Vector3(4f, 2f, 0), new Vector3(-4f, -2f, 0), new Vector3(-2f, -1f, 0)));

        /*
        Vector3[] intersections = TestEquation(0, initialVelocity, initialCharPosition, p1, p2);
        Debug.Log("Intersection 1: " + intersections[0]);
        Debug.Log("Intersection 2: " + intersections[1]);
        SpawnMarker(intersections[0]);
        SpawnMarker(intersections[1]);
        */

       // Vector3 intersection = GetIntersection(initialVelocity, initialCharPosition);
       // Debug.Log("Intersection position: " + intersection);

        /*
        Debug.Log("Y en X=" + 0 + ": " + TestEquation(0, initialVelocity, initialCharPosition));
        */
        // Debug.Log("Y en X=" + 1 + ": " + TestEquation(1, initialVelocity, initialCharPosition));
        
        //Debug.Log("Y en X=" + -4 + ": " + GetY(-4, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(-4, GetY(-4, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + -3 + ": " + GetY(-3, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(-3, GetY(-3, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + -2 + ": " + GetY(-2, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(-2, GetY(-2, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + -1 + ": " + GetY(-1, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(-1, GetY(-1, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 0 + ": " + GetY(0, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(0, GetY(0, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 1 + ": " + GetY(1, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(1, GetY(1, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 2 + ": " + GetY(2, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(2, GetY(2, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 3 + ": " + GetY(3, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(3, GetY(3, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 4 + ": " + GetY(4, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(4, GetY(4, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 5 + ": " + GetY(5, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(5, GetY(5, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 6 + ": " + GetY(6, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(6, GetY(6, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 7 + ": " + GetY(7, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(7, GetY(7, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 8 + ": " + GetY(8, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(8, GetY(8, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 9 + ": " + GetY(9, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(9, GetY(9, initialVelocity, initialPosition)));
        //Debug.Log("Y en X=" + 10 + ": " + GetY(10, initialVelocity, initialCharPosition));
        SpawnMarker(new Vector3(10, GetY(10, initialVelocity, initialPosition)));
        


    }

    //internal float TestEquation(float x, Vector3 initialVelocity, Vector3 testVectorDirection, Vector3 testVectorPosition)

    internal float GetY(float x, Vector3 initialVelocity, Vector3 initialCharPosition)
    {
        float g = 10f;
        float gProd = g / (initialVelocity.x * initialVelocity.x);
        float y = (-0.5f * gProd * ((x - initialCharPosition.x) * (x - initialCharPosition.x))) + (initialVelocity.y * ((x - initialCharPosition.x) / initialVelocity.x)) + initialCharPosition.y;
        /*
        Debug.Log("gProd: " + gProd);
        Debug.Log("FirstTerm: " + (-0.5f * gProd * ((x - initialCharPosition.x) * (x - initialCharPosition.x))));
        Debug.Log("SecondTerm: " + (initialVelocity.y * ((x - initialCharPosition.x) / initialVelocity.x)));
        Debug.Log("ThirdTerm: " + initialCharPosition.y);
        */
        return y;
    }
    internal Vector3[] TestEquation(float x, Vector3 initialVelocity, Vector3 initialCharPosition, Vector3 p1, Vector3 p2)
    {
        float g = 10f;

        //float t = (x / initialVelocity.x);
        //float y = (-0.5f * g * t * t) + (initialVelocity.y * t) + initialCharPosition.y;
        //Debug.Log("x: " + x + " initialCharPosX: " + initialCharPosition.x);
        float gProd = g / (initialVelocity.x * initialVelocity.x);
        float y = (-0.5f * gProd * ((x - initialCharPosition.x) * (x - initialCharPosition.x))) + (initialVelocity.y * ((x-initialCharPosition.x)/initialVelocity.x)) + initialCharPosition.y;
        //Debug.Log("gProd: " + " " + (-0.5f * gProd * ((x - initialCharPosition.x) * (x-initialCharPosition.x))));
        //Debug.Log("2d: " + (initialVelocity.y * ((x - initialCharPosition.x) / initialVelocity.x)));

        //Debug.Log(y);


        float a = ((-0.5f * g)/(initialVelocity.x*initialVelocity.x));
       // float a = (-0.5f * gProd * ((initialCharPosition.x) * ( initialCharPosition.x)));

       // float b = (initialVelocity.y * (initialCharPosition.x / initialVelocity.x)) - (testVectorDirection.y / testVectorDirection.x);
        float b = ((initialVelocity.y / initialVelocity.x) - (initialCharPosition.x*a*2)) -(lineVector.y / lineVector.x);
        //float b = (initialVelocity.y * ((x - initialCharPosition.x) / initialVelocity.x)) - (testVectorDirection.x / testVectorDirection.y);

        float c = ((-0.5f * gProd * ((0 - initialCharPosition.x) * (0 - initialCharPosition.x))) + (initialVelocity.y * ((0 - initialCharPosition.x) / initialVelocity.x)) + initialCharPosition.y) - ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y);
        

       
        Debug.Log("a: " + a);
        Debug.Log("x de parabola: " + ((initialVelocity.y / initialVelocity.x) - (initialCharPosition.x * a * 2)) + " x de linea: " + (lineVector.y / lineVector.x));
        Debug.Log("b: " + b);
        // Debug.Log("c1: " + ((-0.5f * gProd * ((0 - initialCharPosition.x) * (0 - initialCharPosition.x))) + (initialVelocity.y * ((0 - initialCharPosition.x) / initialVelocity.x)) + initialCharPosition.y));
        //Debug.Log("c2: " + ((testVectorDirection.y * ((0 - testVectorPosition.x) / testVectorDirection.x)) + testVectorPosition.y));
        Debug.Log("oO de parabola: " + ((-0.5f * gProd * ((0 - initialCharPosition.x) * (0 - initialCharPosition.x))) + (initialVelocity.y * ((0 - initialCharPosition.x) / initialVelocity.x)) + initialCharPosition.y) + " oO de linea: " + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y));
        Debug.Log("cTotal: " + c);

        float bb4ac = b * b - (4 * a * c);
         Debug.Log("bb4ac: " + bb4ac);
        if (Mathf.Abs(a) < float.Epsilon || bb4ac < 0)
        {
            //  line does not intersect
            Debug.Log("In No Intersection");
            return new Vector3[] { Vector3.zero, Vector3.zero };
        }
        float mu1 = (-b + Mathf.Sqrt(bb4ac)) / (2 * a);
        float mu2 = (-b - Mathf.Sqrt(bb4ac)) / (2 * a);
         Debug.Log("mu1: " + mu1);
         Debug.Log("mu2: " + mu2);

        Vector3[] intersections = new Vector3[2];
        // intersections[0] = new Vector3(mu1, (mu1 + ((testVectorDirection.y * ((0 - testVectorPosition.x) / testVectorDirection.x)) + testVectorPosition.y)));
        intersections[0] = new Vector3(mu1, ((mu1 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));
        // intersections[1] = new Vector3(mu2, (mu2 + ((testVectorDirection.y * ((0 - testVectorPosition.x) / testVectorDirection.x)) + testVectorPosition.y)));
        intersections[1] = new Vector3(mu2, ((mu2 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));

        return intersections;
        /*
        Vector3[] sect = new Vector3[2];
        sect[0] = new Vector3(p1.x + mu1 * (p2.x - p1.x), p1.y + mu1 * (p2.y - p1.y));
        Debug.Log("Sect[0]: " + sect[0]);
        sect[1] = new Vector3(p1.x + mu2 * (p2.x - p1.x), p1.y + mu2 * (p2.y - p1.y));
        Debug.Log("Sect[1]: " + sect[1]);

        return sect;
        */
    }

    internal Vector3 GetIntersection(Vector3 lineVector, Vector3 initialVelocity, Vector3 initialPosition)
    {
        Debug.Log("lineVector: " + lineVector);
        Debug.Log("initialVelocity: " + initialVelocity);
        Debug.Log("initialPosition: " + initialPosition);
        float g = 10f;
        float gProd = g / (initialVelocity.x * initialVelocity.x);
        float a = ((-0.5f * g) / (initialVelocity.x * initialVelocity.x));
        float b = ((initialVelocity.y / initialVelocity.x) - (initialPosition.x * a * 2)) - (lineVector.y / lineVector.x);
        float c = ((-0.5f * gProd * ((0 - initialPosition.x) * (0 - initialPosition.x))) + (initialVelocity.y * ((0 - initialPosition.x) / initialVelocity.x)) + initialPosition.y) - ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y);
        float bb4ac = b * b - (4 * a * c);
        Debug.Log("bb4ac: " + bb4ac);

        if (Mathf.Abs(a) < float.Epsilon || bb4ac < 0)
        {
            return Vector3.zero;
        }
        float mu1 = (-b + Mathf.Sqrt(bb4ac)) / (2 * a);
        float mu2 = (-b - Mathf.Sqrt(bb4ac)) / (2 * a);

        Vector3 intersection = Vector3.zero;

        if(initialVelocity.x > 0f)
        {
            if(mu1 > initialPosition.x)
            {
                intersection = new Vector3(mu1, ((mu1 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));
            }
            else if(mu2 > initialPosition.x)
            {
                intersection = new Vector3(mu2, ((mu2 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));
            }
        }
        else if(initialVelocity.x < 0f)
        {
            if (mu1 < initialPosition.x)
            {
                intersection = new Vector3(mu1, ((mu1 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));
            }
            else if (mu2 < initialPosition.x)
            {
                intersection = new Vector3(mu2, ((mu2 * (lineVector.y / lineVector.x)) + ((lineVector.y * ((0 - testVectorPosition.x) / lineVector.x)) + testVectorPosition.y)));
            }
        }

        SpawnMarker(intersection);
        return intersection;
    }


    public static Vector3 LineLineIntersection(Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
    {
        Vector3 lineVec3 = linePoint2 - linePoint1;
        Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

        //is coplanar, and not parrallel
        if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            Vector3 intersection = linePoint1 + (lineVec1 * s);
            return intersection;
        }
        else
        {
            Vector3 intersection = Vector3.zero;
            return intersection;
        }
    }

    internal void SpawnMarker(Vector3 position)
    {
        GameObject mark = Instantiate(marker, new Vector3(position.x, position.y, -8f), Quaternion.identity);
        Destroy(mark, 500f);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 500f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(lineShader);
        lr.SetColors(color, color);
        lr.SetWidth(0.05f, 0.05f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}



/*
 * internal bool IsPointInLine(Vector3 startPointA, Vector3 endPointB, Vector3 pointP)
    {
        float x1 = startPointA.x;
        float y1 = startPointA.y;
        float z1 = startPointA.z;
        float x2 = endPointB.x;
        float y2 = endPointB.y;
        float z2 = endPointB.z;
        float x = pointP.x;
        float y = pointP.y;
        float z = pointP.z;

        float AB = Mathf.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
        float AP = Mathf.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1) + (z - z1) * (z - z1));
        float PB = Mathf.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y) + (z2 - z) * (z2 - z));
        if (AB == AP + PB)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
*/