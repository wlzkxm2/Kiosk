using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInputText : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button confirmBtn;

    // Start is called before the first frame update
    void Start()
    {
        confirmBtn.onClick.AddListener(() => getInputText());
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(inputField.text);
    }

    private void getInputText(){
        Debug.Log(inputField.text);
    }
}
