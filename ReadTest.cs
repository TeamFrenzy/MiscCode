using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTest : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal List<Line> reconList;

    [SerializeField]
    internal GameObject marker;

    [SerializeField]
    internal float marginOfError;

    [SerializeField]
    internal Vector3 testVec11;

    [SerializeField]
    internal Vector3 testVec12;

    [SerializeField]
    internal Vector3 testVec21;

    [SerializeField]
    internal Vector3 testVec22;

    private void Start()
    {
       // Debug.Log("Result: " + SegmentIntersectionTwo(testVec11,testVec12,testVec21,testVec22));
    }

    internal List<Line> Proyect(List<Line> lineList, float xRange, float yRangeUp, float yRangeDown)
    {
        reconList = new List<Line>();
        lineList.ForEach((Line line) =>
        {

            Vector3 tempVec1 = line.vertice1;
            Vector3 tempVec2 = line.vertice2;

            if ((SegmentIntersection(tempVec1, tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(transform.position.x - xRange, transform.position.y), new Vector3(0,1), xRange, yRangeDown, yRangeUp).magnitude != Vector3.zero.magnitude) || 
            (SegmentIntersection(tempVec1, tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(transform.position.x + xRange, transform.position.y), new Vector3(0, 1), xRange, yRangeDown, yRangeUp).magnitude != Vector3.zero.magnitude) || 
            (SegmentIntersection(tempVec1, tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(transform.position.x, transform.position.y + yRangeUp), new Vector3(1, 0), xRange, yRangeDown, yRangeUp).magnitude != Vector3.zero.magnitude) || 
            (SegmentIntersection(tempVec1, tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(transform.position.x, transform.position.y - yRangeDown), new Vector3(1, 0), xRange, yRangeDown, yRangeUp).magnitude != Vector3.zero.magnitude))
            {
               // Debug.Log("Before: A: " + tempVec1 + " B: " + tempVec2);
                if (tempVec1.x > xRange)
                {
                  //  Debug.Log("1");
                   // Debug.Log("Before: A: " + tempVec1);
                    tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(xRange, 0), new Vector3(0, 1));
                   // Debug.Log("After: A: " + tempVec1);
                }
                if (tempVec1.x < -xRange)
                {
                   // Debug.Log("2");
                  //  Debug.Log("Before: A: " + tempVec1);
                    tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(-xRange, 0), new Vector3(0, 1));
                   // Debug.Log("After: A: " + tempVec1);
                }
                if (tempVec1.y > yRangeUp)
                {
                   // Debug.Log("3");
                  //  Debug.Log("Before: A: " + tempVec1);
                    tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeUp), new Vector3(1, 0));
                   // Debug.Log("After: A: " + tempVec1);
                }
                if (tempVec1.y < yRangeDown)
                {
                   //   Debug.Log("4");
                    //  Debug.Log("Before: A: " + tempVec1);
                    tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeDown), new Vector3(1, 0));
                   //   Debug.Log("After: A: " + tempVec1);
                }

                if (tempVec2.x > xRange)
                {
                    //   Debug.Log("5");
                    //   Debug.Log("Before: B: " + tempVec2);
                    tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(xRange, 0), new Vector3(0, 1));
                    //   Debug.Log("After: B: " + tempVec2);
                }
                if (tempVec2.x < -xRange)
                {
                    //   Debug.Log("6");
                    //   Debug.Log("Before: B: " + tempVec2);
                    tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(-xRange, 0), new Vector3(0, 1));
                   //    Debug.Log("After: B: " + tempVec2);
                }
                if (tempVec2.y > yRangeUp)
                {
                   //   Debug.Log("7");
                  //  Debug.Log("A: " + line.vertice2.y + " B: " + yRangeUp);
                   //   Debug.Log("Before: B: " + tempVec2);
                    tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeUp), new Vector3(1, 0));
                   //   Debug.Log("After: B: " + tempVec2);
                }
                if (tempVec2.y < yRangeDown)
                {
                   //   Debug.Log("8");
                   //   Debug.Log("Before: B: " + tempVec2);
                    tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeDown), new Vector3(1, 0));
                   //   Debug.Log("After: B: " + tempVec2);
                }

                reconList.Add(new Line(tempVec1, tempVec2));
                //  Debug.Log("After: A: " + tempVec1 + " B: " + tempVec2);
            }

        });
        // reconList.ForEach((Line line) => Debug.Log("Vertex 1: " + line.vertice1 + " Vertex 2: " + line.vertice2));

        /*
         reconList.ForEach((Line line) =>
         {
             // SpawnMarker(new Vector3( (line.vertice1.x+line.vertice2.x)/2, (line.vertice1.y + line.vertice2.y) / 2));
             SpawnMarker(line.vertice1);
             SpawnMarker(line.vertice2);
         });
        */


        // reconList.ForEach((Line line) => Debug.Log("Vertex 1: " + line.vertice1 + " Vertex 2: " + line.vertice2));
        return reconList;
    }

    /*Vector3 GetIntersection(Vector3 firstPos, Vector3 firstVec, Vector3 secondPos, Vector3 secondVec)
    {
        //{3,0}, {1,1} en -3

        return new Vector3(0, 0, 0);
    }*/
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

    internal Vector3 SegmentIntersection(Vector3 linePoint1, Vector3 linePoint1b, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2, float xRange, float yRangeDown, float yRangeUp)
    {
        Vector3 lineVec3 = linePoint2 - linePoint1;
        Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

        float maxX = Mathf.Max(linePoint1.x, linePoint1b.x); // 9.2
        float minX = Mathf.Min(linePoint1.x, linePoint1b.x); //-9.1
        float maxY = Mathf.Max(linePoint1.y, linePoint1b.y); //-3.4
        float minY = Mathf.Min(linePoint1.y, linePoint1b.y); //-5.0

        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

        //is coplanar, and not parrallel

        if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            Vector3 intersection = linePoint1 + (lineVec1 * s);
            /*
           Debug.Log("Vec1: " + linePoint1.x + " " + linePoint1.y);
           Debug.Log("Vec2: " + linePoint1b.x + " " + linePoint1b.y);
           Debug.Log("Intersection: X: " + intersection.x + " Y: " + intersection.y);
            Debug.Log("Stats: -xRange: " + -xRange + " xRange: " + xRange + " yRangeDown: " + yRangeDown + " yRangeUp: " + yRangeUp);
            Debug.Log("-xRange: " + (intersection.x >= -xRange));
            Debug.Log("xRange: " + intersection.x + " == " + xRange + ": " + (intersection.x <= xRange + 0.00001f));
            Debug.Log("yRangeDown" + (intersection.y >= yRangeDown));
            Debug.Log("yRangeUp" + (intersection.y <= yRangeUp));
            */
            if ( (intersection.x >= -xRange - marginOfError) && (intersection.x <= xRange + marginOfError) && (intersection.y >= yRangeDown - marginOfError) && (intersection.y <= yRangeUp + marginOfError))
            {
                //Debug.Log("InPreIntersection");
                
                 if ((minX < -xRange && maxX > -xRange) || (minX < xRange && maxX > xRange) || (minX > -xRange && maxX < xRange))
                 {
                     //Debug.Log("InX");
                     if ((minY < yRangeDown && maxY > yRangeDown) || (minY < yRangeUp && maxY > yRangeUp) || (minY > yRangeDown && maxY < yRangeUp))
                     {
                         //Debug.Log("In Intersection");
                         return intersection;
                     }
                     else
                     {
                         intersection = Vector3.zero;
                         return intersection;
                     }
                 }
                 else
                 {
                     intersection = Vector3.zero;
                     return intersection;
                 }
                
            }
            else
            {
                intersection = Vector3.zero;
                return intersection;
            }
        }
        else
        {
            Vector3 intersection = Vector3.zero;
            return intersection;
        }
    }

    internal Vector3 SegmentIntersectionTwo(Vector3 line1vertice1, Vector3 line1vertice2, Vector3 line2vertice1, Vector3 line2vertice2)
    {
        Vector3 lineVec1 = new Vector3(line1vertice1.x-line1vertice2.x, line1vertice1.y-line1vertice2.y);
        Vector3 lineVec2 = new Vector3(line2vertice1.x - line2vertice2.x, line2vertice1.y - line2vertice2.y);

        Vector3 lineVec3 = line2vertice1 - line1vertice1;
        Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

        float maxX1 = Mathf.Max(line1vertice1.x, line1vertice2.x); 
        float minX1 = Mathf.Min(line1vertice1.x, line1vertice2.x); 
        float maxY1 = Mathf.Max(line1vertice1.y, line1vertice2.y); 
        float minY1 = Mathf.Min(line1vertice1.y, line1vertice2.y);

        float maxX2 = Mathf.Max(line2vertice1.x, line2vertice2.x);
        float minX2 = Mathf.Min(line2vertice1.x, line2vertice2.x);
        float maxY2 = Mathf.Max(line2vertice1.y, line2vertice2.y);
        float minY2 = Mathf.Min(line2vertice1.y, line2vertice2.y);

        /*
        float maxX3 = Mathf.Max(maxX1, maxX2);
        float minX3 = Mathf.Min(minX1, minX2);
        float maxY3 = Mathf.Max(maxY1, maxY2);
        float minY3 = Mathf.Min(minY1, minY2);
        */

        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

        //is coplanar, and not parrallel

        if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            Vector3 intersection = line1vertice1 + (lineVec1 * s);
            /*
            if((intersection.x >= minX3 - marginOfError) && (intersection.x <= maxX3 + marginOfError) && (intersection.y >= minY3 - marginOfError) && (intersection.y <= maxY3 + marginOfError))
            {
                return intersection;
            }
            */
            if((intersection.x >= minX1 - marginOfError) && (intersection.x >= minX2 - marginOfError) && (intersection.x <= maxX1 + marginOfError) && (intersection.x <= maxX2 + marginOfError) && (intersection.y >= minY1 - marginOfError) && (intersection.y >= minY2 - marginOfError) && (intersection.y <= maxY1 + marginOfError) && (intersection.y <= maxY2 + marginOfError))
            {
                return intersection;
            }
            else
            {
                intersection = Vector3.zero; 
                return intersection;
            }
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

    internal List<Line> GetIntersectedNetwork(List<Line> lineList)
    {
        List<Line> intersectNetwork = new List<Line>();

        lineList.ForEach((Line outerLine) =>
        {
            lineList.ForEach((Line innerLine) =>
            {
                Vector3 intersection = SegmentIntersectionTwo(outerLine.vertice1, outerLine.vertice2, innerLine.vertice1, innerLine.vertice2);
                if (intersection.magnitude != Vector3.zero.magnitude)
                {

                }
                else
                {

                }
            });
        });

        return intersectNetwork;
    }

    internal List<Line> GetPointOfView(List<Line> lineList)
    {
        List<Line> pointOfViewList = new List<Line>();

        lineList.ForEach((Line line) =>
        {
            pointOfViewList.Add(new Line(line.vertice1 - transform.position, line.vertice2 - transform.position));
        });

        return pointOfViewList;
    }

}



//El resultado tiene que ser un algoritmo que GENERE LINEAS.


//{-6.4,-1.5} {-1.6, -1.5}
//X: Mayor o igual que -6.4 y menor o igual que -1.6
//Y: Mayor o igual que -1.5 y menor o igual que -1.5
//Entre medio de esos dos puntos hay UNA FUNCION.
//Esa funcion podria ser lineal o no o podria ser cualquier cosa.
//Los puntos determinan los limites de la funcion.
//Un Vector3 ya es una funcion lineal.
//La linea empieza y termina en un punto.
//La linea de trayectoria va a tener el mismo tipo de dato.

//En el caso de {5.0 , 5.0} {-5.0,-5.0}
//La funcion lineal seria de y=x entre x=5,x-5, y=5, y=-5
//Primero, como determinas cual seria la funcion lineal en base a los vertices?
//En el caso de los vectores esto es facil: el vector3 entre vectores es la diferencia de ambos.
//Como se reconocerian, por ejemplo, funciones cuadraticas? Pero eso DESPUES.
//POR ENDE, un elemento tendria, por ejemplo, los vertices {5.0 , 7.0} {-5.0,-3.0} y la funcion x=y incluida.
//Segundo, como la insertas en el engine?
//Desde el punto de vista central {3,6}, el vector pasa a tener los siguientes atributos:
//{2,1}{-8,-9}, y=x
//Para averiguar la ordenada al origen, simplemente se puede determinar la distancia del vector con el punto de origen en el eje de absisas. En este caso, cuando x=0, y=-1 Por ende:
//{2,1}{-8,-9}, y=x-1
//Pero como alimentarle esto al engine? Como hacer que lo use para hacer comparaciones????
//Primero, va a checkear todas las lineas del mapa mas alla de si entran en el rango o no. Entonces se va a cruzar con
//la linea anterior, {2,1}{-8,-9}, y va a determinar que su funcion es y=x-1.
//Entonces, en base a esa funcion se van a establecer los nuevos vertices por donde pasa la linea.
//Los resultados, en este caso, serian {1,0} y {-2,-3}
//Los limites de la linea son x=2,x=-8,y=1,y=-9.
//Los limites de percepcion son x=2, x=-2, y=0, y=-5
//Primero, se tiene que ingresar la funcion y=x-1 al algoritmo.
//Entonces: Si x>xL1 entonces x = xL1, si x<xL2 entonces x=xL2

/*
 * if ((line.vertice1.x < xRange) && (line.vertice1.x > -xRange) && (line.vertice1.y < yRangeUp) && (line.vertice1.y > yRangeDown) || (line.vertice2.x < xRange) && (line.vertice2.x > -xRange) && (line.vertice2.y < yRangeUp) && (line.vertice2.y > yRangeDown))
    {

    }*/



/*
            float maxX = Mathf.Max(line.vertice1.x, line.vertice2.x); // 9.2
            float minX = Mathf.Min(line.vertice1.x, line.vertice2.x); //-9.1
            float maxY = Mathf.Max(line.vertice1.y, line.vertice2.y); //-3.4
            float minY = Mathf.Min(line.vertice1.y, line.vertice2.y); //-5.0

            if ((minX < -xRange && maxX > -xRange) || (minX<xRange && maxX>xRange) || (minX>-xRange && maxX<xRange))
            {
                if ((minY < yRangeDown && maxY > yRangeDown) || (minY < yRangeUp && maxY > yRangeUp) || (minY > yRangeDown && maxY < yRangeUp))
                {
                    Vector3 tempVec1 = line.vertice1;
                    Vector3 tempVec2 = line.vertice2;
                    Debug.Log("Before: A: " + tempVec1 + " B: " + tempVec2);
                    if (line.vertice1.x > xRange)
                    {
                        Debug.Log("1");
                        Debug.Log("Before: A: " + tempVec1);
                        tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x-tempVec2.x, tempVec1.y-tempVec2.y,0), new Vector3(xRange, 0), new Vector3(0,1));
                        Debug.Log("After: A: " + tempVec1);
                    }
                    if (line.vertice1.x < -xRange)
                    {
                        Debug.Log("2");
                        Debug.Log("Before: A: " + tempVec1);
                        tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(-xRange, 0), new Vector3(0, 1));
                        Debug.Log("After: A: " + tempVec1);
                    }
                    if (line.vertice1.y > yRangeUp)
                    {
                        Debug.Log("3");
                        Debug.Log("Before: A: " + tempVec1);
                        tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeUp), new Vector3(1, 0));
                        Debug.Log("After: A: " + tempVec1);
                    }
                    if (line.vertice1.y < yRangeDown)
                    {
                        Debug.Log("4");
                        Debug.Log("Before: A: " + tempVec1);
                        tempVec1 = LineLineIntersection(tempVec1, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeDown), new Vector3(1, 0));
                        Debug.Log("After: A: " + tempVec1);
                    }

                    if (line.vertice2.x > xRange)
                    {
                        Debug.Log("5");
                        Debug.Log("Before: B: " + tempVec2);
                        tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(xRange, 0), new Vector3(0, 1));
                        Debug.Log("After: B: " + tempVec2);
                    }
                    if (line.vertice2.x < -xRange)
                    {
                        Debug.Log("6");
                        Debug.Log("Before: B: " + tempVec2);
                        tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(-xRange, 0), new Vector3(0, 1));
                        Debug.Log("After: B: " + tempVec2);
                    }
                    if (line.vertice2.y > yRangeUp)
                    {
                        Debug.Log("7");
                        Debug.Log("Before: B: " + tempVec2);
                        tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeUp), new Vector3(1, 0));
                        Debug.Log("After: B: " + tempVec2);
                    }
                    if (line.vertice2.y < yRangeDown)
                    {
                        Debug.Log("8");
                        Debug.Log("Before: B: " + tempVec2);
                        tempVec2 = LineLineIntersection(tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(0, yRangeDown), new Vector3(1, 0));
                        Debug.Log("After: B: " + tempVec2);
                    }

                    reconList.Add(new Line(tempVec1, tempVec2));
                    Debug.Log("After: A: " + tempVec1 + " B: " + tempVec2);
                }
            }
            */