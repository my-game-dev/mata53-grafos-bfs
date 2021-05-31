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
    string startX = "-1";
    string startY = "-2";
    string endPos = "(5, -2)";
    string endX = "5";
    string endY = "-2";
    Dictionary<(string, string), Node> nodes = new Dictionary<(string, string), Node>();
    IEnumerator search;

    public Color currentAction;

    void Start() {
        for(int x = -5; x <= 8; x++) {
            for(int y = -8; y <= 5; y++) {
                nodes[(x.ToString(), y.ToString())] = new Node(x.ToString(), y.ToString());
            }
        }
        currentAction = Color.green;
        SetStartingPoint(startPos, new Vector2Int(Int32.Parse(startX), Int32.Parse(startY)));
        SetEndingPoint(endPos, new Vector2Int(Int32.Parse(endX), Int32.Parse(endY)));
        search = Search(nodes, (startX, startY), (endX, endY));
        /*foreach(KeyValuePair<(string, string), Node> node in nodes) {
            Debug.Log("X => "+ node.Value.x+" Y => "+node.Value.y);
            foreach((string, string) neighbor in node.Value.getNeighbors()) {
                Debug.Log("Neighbors => "+neighbor.Item1+" and "+neighbor.Item2);
            }
        }*/
    }

    IEnumerator Search(
        Dictionary<(string, string), Node> graph,
        (string, string) start,
        (string, string) goal
    ) {
        var frontier = new Queue<(string, string)>();
        frontier.Enqueue(start);

        var reached = new HashSet<(string, string)>();
        reached.Add(start);
        var flag = 0;

        while (frontier.Count > 0 && flag == 0)
        {
            var current = frontier.Dequeue();

            foreach ((string, string) next in graph[current].getNeighbors()) {
                if (!reached.Contains(next)) {
                    frontier.Enqueue(next);
                    reached.Add(next);
                    if(next == goal) {
                        ChangeColor("("+next.Item1+", "+next.Item2+")", Color.magenta);
                        flag = 1;
                        break;
                    }
                    ChangeColor("("+next.Item1+", "+next.Item2+")", Color.blue);
                    yield return new WaitForSeconds(0.2f);
                }
            }
            
        }
    }

    public void OnStartSearchClick() {
        OnClearClick();
        search = Search(nodes, (startX, startY), (endX, endY));
        StartCoroutine(search);
    }

    public void OnStopClick() {
        Debug.Log("Hello");
        StopCoroutine(search);
    }

    public void OnClearClick() {
        OnStopClick();
        foreach(KeyValuePair<(string, string), Node> node in nodes) {
            ChangeColor("("+node.Key.Item1+", "+node.Key.Item2+")", Color.white);
        }
        SetStartingPoint(startPos, new Vector2Int(Int32.Parse(startX), Int32.Parse(startY)));
        SetEndingPoint(endPos, new Vector2Int(Int32.Parse(endX), Int32.Parse(endY)));
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
    public void SetStartingPoint(string name, Vector2Int coordinates) {
        if(startPos != name && startPos != "") {
            ChangeColor(startPos, Color.white);
        }
        ChangeColor(name, Color.green);
        startPos = name;
        startX = coordinates.x.ToString();
        startY = coordinates.y.ToString();
    }

     public void SetEndingPoint(string name, Vector2Int coordinates) {
        if(endPos != name && endPos != "") {
            ChangeColor(endPos, Color.white);
        }
        ChangeColor(name, Color.red);
        endPos = name;
        endX = coordinates.x.ToString();
        endY = coordinates.y.ToString();
    }

    public void ChangeColor(string pos, Color color) {
        var child = transform.Find(pos);
        var childMesh = child.transform.Find("Quad").gameObject.GetComponent<MeshRenderer>();
        childMesh.material.color = color;
    }
}
