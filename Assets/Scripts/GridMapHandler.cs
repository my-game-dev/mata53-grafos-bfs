using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class GridMapHandler : MonoBehaviour {
    string startPos = "(-1, -2)";
    string startX = "-1";
    string startY = "-2";
    string endPos = "(5, -2)";
    string endX = "5";
    string endY = "-2";
    Dictionary<(string, string), Node> nodes = new Dictionary<(string, string), Node>();
    IEnumerator search;
    public float speed = 1f;
    public Slider slider;
    public Color currentAction;
    public Color greenTile;
    public Color whiteTile;
    public Color redTile;
    public Color pinkTile;
    public Color blueTile;
    private bool coroutineRunning = false;

    void Start() {
        coroutineRunning = false;
        speed = 1f;
        for(int x = -5; x <= 8; x++) {
            for(int y = -8; y <= 5; y++) {
                nodes[(x.ToString(), y.ToString())] = new Node(x.ToString(), y.ToString());
                ChangeColor("("+x.ToString()+", "+y.ToString()+")", whiteTile);
            }
        }
        slider.onValueChanged.AddListener(delegate { OnSpeedChange(); });
        currentAction = greenTile;
        SetStartingPoint(startPos, new Vector2Int(Int32.Parse(startX), Int32.Parse(startY)));
        SetEndingPoint(endPos, new Vector2Int(Int32.Parse(endX), Int32.Parse(endY)));
        search = Search(nodes, (startX, startY), (endX, endY));
    }

    private void resetNodes() {
        foreach(KeyValuePair<(string, string), Node> node in nodes) {
            var pos = "("+node.Key.Item1.ToString()+", "+node.Key.Item2.ToString()+")";
            if(pos != startPos && pos != endPos) {
                ChangeColor(pos, whiteTile);
            }
            if(pos == endPos) {
                ChangeColor(pos, redTile);
            }
        }
    }

    IEnumerator Search(
        Dictionary<(string, string), Node> graph,
        (string, string) start,
        (string, string) goal
    ) {
        coroutineRunning = true;
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
                        ChangeColor("("+next.Item1+", "+next.Item2+")", pinkTile);
                        flag = 1;
                        break;
                    }
                    ChangeColor("("+next.Item1+", "+next.Item2+")", blueTile);
                    yield return new WaitForSeconds(0.2f * speed);
                }
            }
        }
        coroutineRunning = false;
    }

    public void OnStartSearchClick() {
        OnClearClick();
        search = Search(nodes, (startX, startY), (endX, endY));
        StartCoroutine(search);
    }

    public void OnStopClick() {
        StopCoroutine(search);
        coroutineRunning = false;
    }

    public void OnClearClick() {
        OnStopClick();
        resetNodes();
        SetStartingPoint(startPos, new Vector2Int(Int32.Parse(startX), Int32.Parse(startY)));
        SetEndingPoint(endPos, new Vector2Int(Int32.Parse(endX), Int32.Parse(endY)));
    }

    public void OnSpeedChange() {
        int factor = (int)Math.Pow(2,slider.value-1);
        this.speed = 0.25f * factor;
    }

    public void SetCurrentAction(int index) {
        switch(index) {
            case 0:
                this.currentAction = greenTile;
                break;
            case 1:
                this.currentAction = redTile;
                break;
        }
    }

    public void SetStartingPoint(string name, Vector2Int coordinates) {
        if(name != endPos && coroutineRunning == false) {
            resetNodes();
            if(startPos != name && startPos != "") {
                ChangeColor(startPos, whiteTile);
            }
            ChangeColor(name, greenTile);
            startPos = name;
            startX = coordinates.x.ToString();
            startY = coordinates.y.ToString();
        }        
    }

    public void SetEndingPoint(string name, Vector2Int coordinates) {
        if(name != startPos && coroutineRunning == false) {
            resetNodes();
            if(endPos != name && endPos != "") {
                ChangeColor(endPos, whiteTile);
            }
            ChangeColor(name, redTile);
            endPos = name;
            endX = coordinates.x.ToString();
            endY = coordinates.y.ToString();
        }
    }

    public void ChangeColor(string pos, Color color) {
        var child = transform.Find(pos);
        var childMesh = child.transform.Find("Quad").gameObject.GetComponent<MeshRenderer>();
        childMesh.material.color = color;
    }
}
