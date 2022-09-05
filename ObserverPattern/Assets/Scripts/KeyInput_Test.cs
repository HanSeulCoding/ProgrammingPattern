using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyInput_Test : MonoBehaviour
{
    private static KeyInput_Test _instance;
    public TMP_Text textMesh;
    public static KeyInput_Test Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        textMesh = this.GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    public void ModifyText(string s)
    {
        textMesh.text = "KeyInput : " + s;
    }
}
