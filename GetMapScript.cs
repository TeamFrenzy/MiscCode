using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMapScript : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal GameObject[] mapObjects;

    [SerializeField]
    internal List<Line> lineList;

    //La funcion de este script es la de generar un array de lineas que represente con precision al mapa. Para esto, toma las coordenadas de los puntos que estan al extremo de cada linea y los guarda en el mismo vector.

    internal void GetMap()
    {
        lineList = new List<Line>();
        for (int i = 0; i < mapObjects.Length; i++)
        {
            BoxCollider collider = mapObjects[i].GetComponent<BoxCollider>();
            var trans = collider.transform;
            var min = (collider.center - collider.size * 0.5f);
            var max = (collider.center + collider.size * 0.5f);

            Vector3[] verticeArray = { trans.TransformPoint(new Vector3(min.x, min.y, 0f)) - transform.position, trans.TransformPoint(new Vector3(min.x, max.y, 0f)) - transform.position, trans.TransformPoint(new Vector3(max.x, min.y, 0f)) - transform.position, trans.TransformPoint(new Vector3(max.x, max.y, 0f)) - transform.position };

            /*
            for (int f =0;f<verticeArray.Length;f++)
            {
                Debug.Log(verticeArray[f]);
            }
            */

            for (int j = 0; j < verticeArray.Length; j++)
            {
                for (int k = 1; k < verticeArray.Length - j; k++)
                {
                   // Debug.Log("Ver1: " + verticeArray[j] + " Ver2: " + verticeArray[k + j]);

                    if (Mathf.Max(collider.transform.localScale.x, collider.transform.localScale.y) + 0.001f > Mathf.Sqrt(((verticeArray[j].x - verticeArray[k + j].x) * (verticeArray[j].x - verticeArray[k + j].x)) + ((verticeArray[j].y - verticeArray[k + j].y) * (verticeArray[j].y - verticeArray[k + j].y))))
                    {
                       // Debug.Log("In Add");
                        lineList.Add(new Line(verticeArray[j], verticeArray[k + j]));
                    }
                }
            }
        }
        
        /*
        lineList.ForEach((Line line) =>
        {
            aiManagerScript.restTestScript.SpawnMarker(new Vector3((line.vertice1.x + line.vertice2.x) / 2, (line.vertice1.y + line.vertice2.y) / 2));
        });
        */
        

        /*
        lineList.ForEach((Line line) =>
        {
            Debug.Log("A: " + line.vertice1 + " B: " + line.vertice2);
        });
        */
    }


}
