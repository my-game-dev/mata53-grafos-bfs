using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public GameObject gridMap;

    void Start()
    {
        var m_Dropdown = transform.GetComponent<TMP_Dropdown>();
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(TMP_Dropdown change)
    {
        Debug.Log("new drop: "+change.value.ToString());
        var handler = gridMap.GetComponent<GridMapHandler>();
        switch(change.value) {
            case 0:
                handler.currentAction = Color.green;
                break;
            case 1:
                handler.currentAction = Color.red;
                break;
        }
    }
}
