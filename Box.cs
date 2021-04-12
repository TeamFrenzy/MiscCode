using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Box
{
    public List<Line> lineList;
    public BoxCollider referenceBox;
    public Box(Line line1, Line line2, Line line3, Line line4, BoxCollider referenceBox)
    {
        //this.line1 = new Line(line1.vertice1, line1.vertice2);
        //this.line2 = new Line(line2.vertice1, line2.vertice2);
        //this.line3 = new Line(line3.vertice1, line3.vertice2);
        //this.line4 = new Line(line4.vertice1, line4.vertice2);
        this.lineList = new List<Line>();
        this.lineList.Add(line1);
        this.lineList.Add(line2);
        this.lineList.Add(line3);
        this.lineList.Add(line4);
        this.referenceBox = referenceBox;
    }
}