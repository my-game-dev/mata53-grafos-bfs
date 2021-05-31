using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour {
    TextMeshPro label;
    public Vector2Int coordinates = new Vector2Int();

    void Awake() {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    void Update() {
       if (!Application.isPlaying) {
           DisplayCoordinates();
           UpdateObjectName();
       } 
    }

    void DisplayCoordinates() {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.y / 10);
        label.text = "";
    }

    void UpdateObjectName() {
        transform.parent.name = coordinates.ToString();
    }
}
