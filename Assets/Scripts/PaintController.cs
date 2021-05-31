using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintController : MonoBehaviour
{
    GridMapHandler parentScript;
    
    private void OnMouseDown() {
        parentScript = transform.parent.parent.GetComponent<GridMapHandler>();
        Vector2Int coordinates = transform.parent.Find("Position").GetComponent<CoordinateLabeler>().coordinates;
        if (parentScript.currentAction == Color.green) {
            parentScript.SetStartingPoint(transform.parent.name, coordinates);
        } else if (parentScript.currentAction == Color.red) {
            parentScript.SetEndingPoint(transform.parent.name, coordinates);
        }
    }
}
