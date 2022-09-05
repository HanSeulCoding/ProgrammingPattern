using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp_UIGameSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popup_KeySetting;
    public PG_Main main;

    public void OnEnable()
    {
        main = PG_Main.Instance;
        main.isGamePause = true;
    }
    public void OnDisable()
    {
        main.isGamePause = false;
    }
    public void Click_KeySetting()
    {
        popup_KeySetting.SetActive(!popup_KeySetting.activeSelf);
    }
}
