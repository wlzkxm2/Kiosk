using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScaningManager : MonoBehaviour
{
    private List<string> scanning = new List<string>();

    private void OnTriggerEnter2D(Collider2D collider) {
        TextMeshProUGUI scanningText = collider.GetComponentInChildren<TextMeshProUGUI>();
        // Debug.Log(scanningText.text);

        scanning.Add(scanningText.text);

        foreach(string data in scanning){
            Debug.Log(data);
        }
    }

    
}
