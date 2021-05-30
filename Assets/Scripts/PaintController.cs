using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintController : MonoBehaviour
{
    GridMapHandler parentScript;
    
    private void OnMouseDown() {
        parentScript = transform.parent.parent.GetComponent<GridMapHandler>();
        if (parentScript.currentAction == Color.green) {
            parentScript.SetStartingPoint(transform.parent.name);
        } else if (parentScript.currentAction == Color.red) {
            parentScript.SetEndingPoint(transform.parent.name);
        }
    }
}
