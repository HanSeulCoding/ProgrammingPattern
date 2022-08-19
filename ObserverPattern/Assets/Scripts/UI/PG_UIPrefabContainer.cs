using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PG_UIPrefabContainer : MonoBehaviour
{
    public GameObject pannel_World;
    public GameObject popup_Setting;
    public GameObject popup_KeySetting;

    private static PG_UIPrefabContainer instance;
    public static PG_UIPrefabContainer Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
  
}
