using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeySetting_KeyClickBtn : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }
    
    public void KeyClickBtn(int n)
    {
        PG_Global.KeySettingClick((CommandsType)n);
    }
}
