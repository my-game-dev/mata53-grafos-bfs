using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node {
    public string x;
    public string y;
    List<(string, string)> neighbors = new List<(string, string)>();

    public Node(string x, string y) {
        this.x = x;
        this.y = y;
    }

    public List<(string, string)> getNeighbors() {
        if(ToInt(x) < 8) neighbors.Add(((ToInt(x)+1).ToString(), y));
        if(ToInt(x) > -5) neighbors.Add(((ToInt(x)-1).ToString(), y));
        if(ToInt(y) < 5) neighbors.Add((x, (ToInt(y)+1).ToString()));
        if(ToInt(y) > -8) neighbors.Add((x, (ToInt(y)-1).ToString()));
        return neighbors;
    }

    public int ToInt(string val) {
        return Int32.Parse(val);
    }
}
public class GridMapHandler : MonoBehaviour
{
    string startPos = "(-1, -2)";
    string endPos = "(5, -2)";
    List<Node> allNodes = new List<Node>();
    Dictionary<(string, string), Node> blaNodes = new Dictionary<(string, string), Node>();

    public Color currentAction;

    void Start() {
        for(int x = -5; x <= 8; x++) {
            for(int y = -8; y <= 5; y++) {
                //allNodes.Add(new Node(x.ToString(), y.ToString()));
                blaNodes[(x.ToString(), y.ToString())] = new Node(x.ToString(), y.ToString());
            }
        }
        currentAction = Color.green;
        SetStartingPoint(startPos);
        SetEndingPoint(endPos);
        /*foreach(Node node in allNodes) {
            Debug.Log("X => "+ node.x+" Y => "+node.y);
            foreach((string, string) neighbor in node.getNeighbors()) {
                Debug.Log("Neighbors => "+neighbor.Item1+" and "+neighbor.Item2);
            }
        }*/
        foreach(KeyValuePair<(string, string), Node> node in blaNodes) {
            Debug.Log("X => "+ node.Value.x+" Y => "+node.Value.y);
            foreach((string, string) neighbor in node.Value.getNeighbors()) {
                Debug.Log("Neighbors => "+neighbor.Item1+" and "+neighbor.Item2);
            }
        }
    }

    public void SetCurrentAction(int index) {
        Debug.Log("Eita: "+index.ToString());
        switch(index) {
            case 0:
                this.currentAction = Color.green;
                break;
            case 1:
                this.currentAction = Color.red;
                break;
        }
    }
    public void SetStartingPoint(string name) {
        if(startPos != name && startPos != "") {
            ChangeColor(startPos, Color.white);
        }
        ChangeColor(name, Color.green);
        startPos = name;
    }

     public void SetEndingPoint(string name) {
        if(endPos != name && endPos != "") {
            ChangeColor(endPos, Color.white);
        }
        ChangeColor(name, Color.red);
        endPos = name;
    }

    public void ChangeColor(string pos, Color color) {
        var child = transform.Find(pos);
        var childMesh = child.transform.Find("Quad").gameObject.GetComponent<MeshRenderer>();
        childMesh.material.color = color;
    }
}
