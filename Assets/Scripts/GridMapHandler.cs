using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapHandler : MonoBehaviour
{
    string startPos = "(-1, -2)";
    string endPos = "(5, -2)";
    public Color currentAction;

    void Start() {
        currentAction = Color.green;
        SetStartingPoint(startPos);
        SetEndingPoint(endPos);
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
