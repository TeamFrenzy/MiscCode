using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrajectoryMap : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal TrajectoryPrediction trajectoryPredictionScript;


    //Tiene que funcionar para todo tipo de Skill.
    //Ejemplos: Dash, radial, Jump, etc.
    //Paso 1: Walk.
    //Paso 2: Jump.


    internal List<Line> GetTrajectoryMapMethod(List<Line> intersectNetwork, Vector3 initialVelocity, Vector3 initialPosition, float range)
    {
        List<Line> optionsMap = new List<Line>();

        intersectNetwork.ForEach((Line line) =>
        {
            Vector3 tempVec1 = line.vertice1;
            Vector3 tempVec2 = line.vertice2;

            float maxX = Mathf.Max(line.vertice1.x, line.vertice2.x);
            float minX = Mathf.Min(line.vertice1.x, line.vertice2.x);
            float maxY = Mathf.Max(line.vertice1.y, line.vertice2.y);
            float minY = Mathf.Min(line.vertice1.y, line.vertice2.y);

            Vector3 intersectionLanding = trajectoryPredictionScript.GetIntersection(new Vector3(line.vertice1.x - line.vertice2.x, line.vertice1.y - line.vertice2.y), initialVelocity, new Vector3(initialPosition.x, initialPosition.y));
            Vector3 intersectionPlus = trajectoryPredictionScript.GetIntersection(new Vector3(line.vertice1.x - line.vertice2.x, line.vertice1.y - line.vertice2.y), initialVelocity, new Vector3(initialPosition.x + range, initialPosition.y));
            Vector3 intersectionMinus = trajectoryPredictionScript.GetIntersection(new Vector3(line.vertice1.x - line.vertice2.x, line.vertice1.y - line.vertice2.y), initialVelocity, new Vector3(initialPosition.x - range, initialPosition.y));

            //Cuatro casos:
            //Hay una interseccion.
            //La curva cae en frente de la linea.
            //La curva cae detras de la linea.
            //No hay una interseccion.
            if (intersectionPlus != Vector3.zero)
            {
                if(maxX>intersectionPlus.x && minX<intersectionPlus.x)
                {
                    if(tempVec1.x>intersectionPlus.x)
                    {
                        tempVec1 = intersectionPlus;
                    }
                    if(tempVec2.x>intersectionPlus.x)
                    {
                        tempVec2 = intersectionPlus;
                    }
                }
            }

            optionsMap.Add(new Line(tempVec1, tempVec2));
        });

        return optionsMap;
    }
}
