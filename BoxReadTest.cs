using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReadTest : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal List<Box> reconBoxList;

    [SerializeField]
    internal GameObject marker;

    [SerializeField]
    internal float marginOfError;

    internal List<Box> Proyect(List<Box> boxList, float xRange, float yRangeUp, float yRangeDown)
    {
        reconBoxList = new List<Box>();
        boxList.ForEach((Box box) =>
        {
            List<Line> lineList = new List<Line>();
            box.lineList.ForEach((Line line) =>
            {
               // Debug.Log("Line");
                Vector3 tempVec1 = line.vertice1;
                Vector3 tempVec2 = line.vertice2;

            if ((SegmentIntersection(tempVec1, tempVec2, new Vector3(tempVec1.x - tempVec2.x, tempVec1.y - tempVec2.y, 0), new Vector3(transform.position.x - xRange, transform.position.y), new Vector3(0, 1), xRange, yRangeDown, yRangeUp).magnitude != Vector3.zero.magnitude) ||
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

                    lineList.Add(new Line(tempVec1, tempVec2));
                //  Debug.Log("After: A: " + tempVec1 + " B: " + tempVec2);
            }
            /*
                Debug.Log("Before Add:");
                Debug.Log("Line1: " + lineList[0].vertice1 + " " + lineList[0].vertice2);
                Debug.Log("Line1: " + lineList[1]);
                Debug.Log("Line1: " + lineList[2]);
                Debug.Log("Line1: " + lineList[3]);
                reconBoxList.Add(new Box(lineList[0], lineList[1], lineList[2], lineList[3], box.referenceBox));
                Debug.Log("After Add");
            */

            });

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
        return reconBoxList;
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
            if ((intersection.x >= -xRange - marginOfError) && (intersection.x <= xRange + marginOfError) && (intersection.y >= yRangeDown - marginOfError) && (intersection.y <= yRangeUp + marginOfError))
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
        Vector3 lineVec1 = new Vector3(line1vertice1.x - line1vertice2.x, line1vertice1.y - line1vertice2.y);
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
            if ((intersection.x >= minX1 - marginOfError) && (intersection.x >= minX2 - marginOfError) && (intersection.x <= maxX1 + marginOfError) && (intersection.x <= maxX2 + marginOfError) && (intersection.y >= minY1 - marginOfError) && (intersection.y >= minY2 - marginOfError) && (intersection.y <= maxY1 + marginOfError) && (intersection.y <= maxY2 + marginOfError))
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

    internal List<Line> GetIntersectedNetworkTwo(List<Box> boxList)
    {
       // Debug.Log("In Two");
        List<Line> intersectNetwork = new List<Line>();
        List<Line> clearedLines = new List<Line>();
        boxList.ForEach((Box outerBox) =>
        {
            //Debug.Log("OBox: " + outerBox.referenceBox);
            outerBox.lineList.ForEach((Line outerLine) =>
            {
               // Debug.Log("OuterLine: " + outerLine.vertice1 + " " + outerLine.vertice2);
                List<Vector3> intersectionList = new List<Vector3>();
                boxList.ForEach((Box innerBox) =>
                {
                    if(innerBox!=outerBox)
                    {
                        innerBox.lineList.ForEach((Line innerLine) =>
                        {
                            //if ((outerLine != innerLine) && (!IsInClearedLines(clearedLines, innerLine)))
                            if (outerLine != innerLine)
                            {
                                //Debug.Log("InFirstFilter: " + innerLine.vertice1 + " " + innerLine.vertice2);
                                Vector3 intersection = SegmentIntersectionTwo(outerLine.vertice1, outerLine.vertice2, innerLine.vertice1, innerLine.vertice2);
                                if ((intersection.magnitude != Vector3.zero.magnitude) && (IsContainedOnlyInTwo(intersection, boxList, outerBox, innerBox)))
                                {
                                   // Debug.Log("Added:" + intersection);
                                    intersectionList.Add(intersection);
                                }
                            }
                        });
                    }
                });
                //Paso 1: Ordenar vertices de mas cercano a mas lejano de vertice1
                Vector3 verticeInicial = outerLine.vertice1;
               // Debug.Log("VerticeInicial: " + verticeInicial + " VerticeFinal: " + outerLine.vertice2);
               // Debug.Log("Before Sort: ");
               /* intersectionList.ForEach((Vector3 intersection) =>
                {
                    Debug.Log(intersection);
                });*/
                intersectionList.Sort((p1, p2) => Vector3.Distance(p1, verticeInicial).CompareTo(Vector3.Distance(p2, verticeInicial)));
                // Debug.Log("After Sort: ");
                // Debug.Log("VerInicial: " + outerLine.vertice1 + " VerFinal: " + outerLine.vertice2);
                //  Debug.Log("Orden: ");
                /*
                  intersectionList.ForEach((Vector3 intersection) =>
                   {
                     Debug.Log(intersection);
                 });
                */

                bool isStart = true;

                if (!IsContained(outerLine.vertice2, boxList, outerBox))
                {
                   // Debug.Log("IsNotContained: " + outerLine.vertice2);
                    intersectionList.Add(outerLine.vertice2);
                }

                if (IsContained(outerLine.vertice1, boxList, outerBox)) 
                {
                    if(intersectionList.Count!=0)
                    {
                        verticeInicial = intersectionList[0];
                    }
                    intersectionList.Remove(verticeInicial);
                }

                intersectionList.ForEach((Vector3 intersection) =>
                {
                    if(isStart)
                    {
                       // Debug.Log("Linea Insertada: A: " + verticeInicial + " B: " + intersection);
                        intersectNetwork.Add(new Line(verticeInicial, intersection));
                        isStart = false;
                    }
                    else
                    {
                        verticeInicial = intersection;
                        isStart = true;
                    }
                });
                clearedLines.Add(outerLine);
                /*
                clearedLines.ForEach((Line line) =>
                {
                    Debug.Log("A: " + line.vertice1 + " B: " + line.vertice2);
                });
                */
            });
        });

        // Debug.Log("Cantidad de lineas: " + intersectNetwork.Count);

        
        intersectNetwork.ForEach((Line line) =>
        {
            //Debug.Log("Linea: A: " + line.vertice1 + " B: " + line.vertice2);
            //aiManagerScript.restTestScript.SpawnMarker(line.vertice1);
            //aiManagerScript.restTestScript.SpawnMarker(line.vertice2);
            aiManagerScript.restTestScript.SpawnMarker(new Vector3((line.vertice1.x + line.vertice2.x) / 2, (line.vertice1.y + line.vertice2.y) / 2));
        });
        

        return intersectNetwork;
    }

    internal bool IsContained(Vector3 vertice, List<Box> boxList, Box includedBox)
    {
        bool isTrue = false;
        boxList.ForEach((Box box) =>
        {
            if(box!=includedBox)
            {
                if (Contains(box.referenceBox.transform, vertice, true))
                {
                  //  Debug.Log("IsContained: " + vertice + " Box: " + box.referenceBox.transform.position);
                    isTrue = true;
                }
            }
        });
        if(isTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool IsContainedOnlyInTwo(Vector3 vertice, List<Box> boxList, Box outerBox, Box innerBox)
    {
        bool isTrue = true;
        boxList.ForEach((Box box) =>
        {
            if ((box != outerBox) && (box!=innerBox))
            {
                if (Contains(box.referenceBox.transform, vertice, true))
                {
                    isTrue = false;
                }
            }
        });

        if (isTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //ColliderContainsPoint
    internal bool Contains(Transform ColliderTransform, Vector3 Point, bool Enabled)
    {
        Vector3 localPos = ColliderTransform.InverseTransformPoint(Point);
        if (Enabled && Mathf.Abs(localPos.x) < 0.5f && Mathf.Abs(localPos.y) < 0.5f && Mathf.Abs(localPos.z) < 0.5f)
            return true;
        else
            return false;
    }

    internal bool IsInClearedLines(List<Line> clearedLines, Line innerLine)
    {
        bool isIn = false;

        clearedLines.ForEach((Line line) =>
        {
            if (innerLine == line)
            {
                isIn = true;
            }
        });
        if(isIn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal List<Line> GetPointOfView(List<Line> lineList)
    {
        List<Line> pointOfViewList = new List<Line>();

        lineList.ForEach((Line line) =>
        {
            pointOfViewList.Add(new Line(line.vertice1 - transform.position, line.vertice2 - transform.position));
        });

        pointOfViewList.ForEach((Line line) =>
        {
            Debug.Log("A: " + line.vertice1 + " B: " + line.vertice2);
        });

        pointOfViewList.ForEach((Line line) =>
        {
            //Debug.Log("Linea: A: " + line.vertice1 + " B: " + line.vertice2);
            //aiManagerScript.restTestScript.SpawnMarker(line.vertice1);
            //aiManagerScript.restTestScript.SpawnMarker(line.vertice2);
            aiManagerScript.restTestScript.SpawnMarker(new Vector3(((line.vertice1.x + transform.position.x) + (line.vertice2.x + transform.position.x)) / 2, ((line.vertice1.y + transform.position.y) + (line.vertice2.y + transform.position.y)) / 2));
        });

        return pointOfViewList;
    }
}