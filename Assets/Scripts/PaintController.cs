using UnityEngine;

public class PaintController : MonoBehaviour {
    GridMapHandler parentScript;
    
    // Reconhece o Clique do Mouse para alterar os pontos de Início e Chegada
    private void OnMouseDown() {
        parentScript = transform.parent.parent.GetComponent<GridMapHandler>();
        Vector2Int coordinates = transform.parent.Find("Position").GetComponent<CoordinateLabeler>().coordinates;

        if (parentScript.currentAction == parentScript.greenTile) {
            parentScript.SetStartingPoint(transform.parent.name, coordinates);
        } else if (parentScript.currentAction == parentScript.redTile) {
            parentScript.SetEndingPoint(transform.parent.name, coordinates);
        }
    }
}
