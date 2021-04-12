using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMapScriptBox : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal GameObject[] mapObjects;

    [SerializeField]
    internal List<Box> boxList;

    //La funcion de este script es la de generar un array de lineas que represente con precision al mapa. Para esto, toma las coordenadas de los puntos que estan al extremo de cada linea y los guarda en el mismo vector.

    internal void GetMap()
    {
        boxList = new List<Box>();
        for (int i = 0; i < mapObjects.Length; i++)
        {
            BoxCollider collider = mapObjects[i].GetComponent<BoxCollider>();
            var trans = collider.transform;
            var min = (collider.center - collider.size * 0.5f);
            var max = (collider.center + collider.size * 0.5f);

            //Vector3[] verticeArray = { trans.TransformPoint(new Vector3(min.x, min.y, 0f)), trans.TransformPoint(new Vector3(min.x, max.y, 0f)), trans.TransformPoint(new Vector3(max.x, min.y, 0f)), trans.TransformPoint(new Vector3(max.x, max.y, 0f)) };

            Vector3[] verticeArray = { trans.TransformPoint(new Vector3(min.x, min.y, 0f)), trans.TransformPoint(new Vector3(min.x, max.y, 0f)), trans.TransformPoint(new Vector3(max.x, min.y, 0f)), trans.TransformPoint(new Vector3(max.x, max.y, 0f)) };

            /*
            for (int f =0;f<verticeArray.Length;f++)
            {
                Debug.Log(verticeArray[f]);
            }
            */


            List<Line> lineList = new List<Line>();
            for (int j = 0; j < verticeArray.Length; j++)
            {
                for (int k = 1; k < verticeArray.Length - j; k++)
                {
                    // Debug.Log("Ver1: " + verticeArray[j] + " Ver2: " + verticeArray[k + j]);

                    if (Mathf.Max(collider.transform.localScale.x, collider.transform.localScale.y) + 0.001f > Mathf.Sqrt(((verticeArray[j].x - verticeArray[k + j].x) * (verticeArray[j].x - verticeArray[k + j].x)) + ((verticeArray[j].y - verticeArray[k + j].y) * (verticeArray[j].y - verticeArray[k + j].y))))
                    {
                        //Debug.Log("In Add: A: " + verticeArray[j] + " B: " + verticeArray[k + j]);
                        lineList.Add(new Line(verticeArray[j], verticeArray[k + j]));
                    }
                }
            }
            //boxList.Add(new Box(new Line(lineArray[0].vertice1, lineArray[0].vertice2), new Line(lineArray[1].vertice1, lineArray[1].vertice2), new Line(lineArray[2].vertice1, lineArray[2].vertice2), new Line(lineArray[3].vertice1, lineArray[3].vertice2)));
            boxList.Add(new Box(lineList[0], lineList[1], lineList[2], lineList[3], collider));
            //Debug.Log("Contains: " + collider.bounds.Contains(lineList[0].vertice1));

        }
        /*

        Debug.Log("Line 1: Vertices: A: " + boxList[0].lineList[0].vertice1 + " B: " + lineList[0].vertice2);
        Debug.Log("Line 2: Vertices: A: " + lineList[1].vertice1 + " B: " + lineList[1].vertice2);
        Vector3 tempIntersection = aiManagerScript.boxReadTestScript.SegmentIntersectionTwo(lineList[0].vertice1, lineList[0].vertice2, lineList[1].vertice1, lineList[1].vertice1);
        Debug.Log("Intesection: " + tempIntersection);
        Debug.Log("Moving along to one side: " + ((lineList[0].vertice1 - lineList[0].vertice2).normalized) * 0.5f + tempIntersection);
        Debug.Log("Moving along to the other side: " + ((lineList[0].vertice2 - lineList[0].vertice1).normalized) * 0.5f + tempIntersection);

        */

        /*
        Debug.Log("Length: " + boxList.Count);

        boxList.ForEach((Box box) =>
        {
            box.lineList.ForEach((Line line) =>
            {
                Debug.Log("A: " + line.vertice1 + " B: " + line.vertice2);
            });
        });
        */

        /*
        boxList.ForEach((Box box) =>
        {
            box.lineList.ForEach((Line line) =>
            {
                Debug.Log("A: " + line.vertice1 + " B: " + line.vertice2);
                aiManagerScript.restTestScript.SpawnMarker(new Vector3((line.vertice1.x + line.vertice2.x) / 2, (line.vertice1.y + line.vertice2.y) / 2));
            });
        });
        */
        

    }
}
