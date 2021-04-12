using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManagerScript : MonoBehaviour
{
    [SerializeField]
    internal AIScript aiScript;

    [SerializeField]
    internal GetMapScript getMapScript;

    [SerializeField]
    internal GetMapScriptBox getMapScriptBox;

    [SerializeField]
    internal ReadTest restTestScript;

    [SerializeField]
    internal BoxReadTest boxReadTestScript;

    [SerializeField]
    internal float xRange;

    [SerializeField]
    internal float yUpRange;

    [SerializeField]
    internal float yDownRange;

    [SerializeField]
    internal List<Vector3> overNetwork;

    [SerializeField]
    internal Rigidbody aiRb;

    [SerializeField]
    internal Vector3 startVer;

    [SerializeField]
    internal Vector3 testVer1;

    [SerializeField]
    internal Vector3 testVer2;

    [SerializeField]
    internal Vector3 testVer3;

    [SerializeField]
    internal Vector3 testVer4;

    [SerializeField]
    internal Vector3 testVer5;

    [SerializeField]
    internal GameObject markerBall;

    [SerializeField]
    internal List<BoxCollider> testBoxList;

    [SerializeField]
    internal BoxCollider testIncludedBox;

    [SerializeField]
    internal Transform testTransform;

    public Shader lineShader;

    public float lineZdistance;

    bool block;

    private void Start()
    {
        /*
        bool isitContained = boxReadTestScript.Contains(testTransform, markerBall.transform.position, true);
        if(isitContained)
        {
            Debug.Log("Contained");
        }
        else
        {
            Debug.Log("Not Contained");
        }
        */

        /*
        List<Vector3> intersectionList = new List<Vector3>();
        intersectionList.    Add(testVer1);
        intersectionList.Add(testVer2);
        intersectionList.Add(testVer3);
        intersectionList.Add(testVer4);
        intersectionList.Add(testVer5);
        intersectionList.Sort((p1, p2) => Vector3.Distance(p1, startVer).CompareTo(Vector3.Distance(p2, startVer)));

        intersectionList.ForEach((Vector3 intersection) =>
        {
            Debug.Log("X: " + intersection.x +" Y: " + intersection.y);
        });
        */

       // Debug.Log(IsCBetweenAB(new Vector3(-1, -1), new Vector3(1, 1), new Vector3(0.25f, 0.25f)));
       // Debug.Log(IsCBetweenAB(new Vector3(0, 3), new Vector3(0, -3), new Vector3(10, 2.99f)));
       // Debug.Log(IsCBetweenAB(new Vector3(0, 3), new Vector3(0, -3), new Vector3(10, 3)));
        overNetwork = new List<Vector3>();
        //aiRb = GetComponent<Rigidbody>();
        DrawLine(new Vector3(transform.position.x - xRange, transform.position.y+yUpRange, lineZdistance), new Vector3(transform.position.x + xRange, transform.position.y + yUpRange, lineZdistance), Color.red);
        DrawLine(new Vector3(transform.position.x - xRange, transform.position.y + yUpRange, lineZdistance), new Vector3(transform.position.x - xRange, transform.position.y + yDownRange, lineZdistance), Color.red);
        DrawLine(new Vector3(transform.position.x + xRange, transform.position.y + yUpRange, lineZdistance), new Vector3(transform.position.x + xRange, transform.position.y + yDownRange, lineZdistance), Color.red);
        DrawLine(new Vector3(transform.position.x - xRange, transform.position.y + yDownRange, lineZdistance), new Vector3(transform.position.x + xRange, transform.position.y + yDownRange, lineZdistance), Color.red);

        block = false;
    }

    private void Update()
    {
        if(!block)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                getMapScriptBox.GetMap();
                List<Line> intersectedNetworkList = boxReadTestScript.GetIntersectedNetworkTwo(getMapScriptBox.boxList);
                List<Line> pointOfViewList = boxReadTestScript.GetPointOfView(intersectedNetworkList);
                //boxReadTestScript.reconBoxList = boxReadTestScript.Proyect(getMapScriptBox.boxList, xRange, yUpRange, yDownRange);
                //getMapScript.GetMap();
                //restTestScript.reconList = restTestScript.Proyect(getMapScript.lineList, xRange, yUpRange, yDownRange);
                //overNetwork = restTestScript.GetOverlapNetwork(restTestScript.reconList);
                block = true;
            }
        }
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

    bool IsCBetweenAB(Vector3 A, Vector3 B, Vector3 C)
    {
        return Vector3.Dot((B - A).normalized, (C - B).normalized) < 0f && Vector3.Dot((A - B).normalized, (C - A).normalized) < 0f;
    }
}
