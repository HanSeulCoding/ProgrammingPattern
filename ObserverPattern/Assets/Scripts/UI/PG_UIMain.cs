using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PG_UIMain : MonoBehaviour
{
    // Start is called before the first frame update
    private static PG_UIMain instance;

    public static PG_UIMain Instance
    {
        get
        {
            return instance;
        }
    }
    [NonSerialized] public PGUIState uiState = PGUIState.None;
    [NonSerialized] public PopUp_UIGameSetting popup_UIGameSetting;
    [NonSerialized] public Panel_UIWorld panel_UIWorld;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnUIObject(GameObject uiPrefab)
    {
        GameObject goUIPrefab = Instantiate(uiPrefab);
        goUIPrefab.transform.SetParent(transform);
        (goUIPrefab.transform as RectTransform).offsetMin = Vector2.zero;
        (goUIPrefab.transform as RectTransform).offsetMax = Vector2.zero;
        goUIPrefab.transform.localScale = Vector3.one;
        return goUIPrefab;
    }

    public GameObject SpawnUIObject(GameObject uiPrefab, Transform parentTR)
    {
        GameObject goUIPrefab = Instantiate(uiPrefab);
        goUIPrefab.transform.SetParent(parentTR);
        (goUIPrefab.transform as RectTransform).offsetMin = Vector2.zero;
        (goUIPrefab.transform as RectTransform).offsetMax = Vector2.zero;
        goUIPrefab.transform.localScale = Vector3.one;
        return goUIPrefab;
    }

    public GameObject SpawnUIObjectNonScale(GameObject uiPrefab)
    {
        GameObject goUIPrefab = Instantiate(uiPrefab);
        goUIPrefab.transform.SetParent(transform);
        goUIPrefab.transform.localScale = Vector3.one;
        (goUIPrefab.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
        return goUIPrefab;
    }

    public GameObject SpawnUIObjectNonScale(GameObject uiPrefab, Transform parentTR)
    {
        GameObject goUIPrefab = Instantiate(uiPrefab);
        goUIPrefab.transform.SetParent(parentTR);
        goUIPrefab.transform.localScale = Vector3.one;
        (goUIPrefab.transform as RectTransform).anchoredPosition = new Vector2(0, 0);
        return goUIPrefab;
    }

    public void ChangeUIState(PGUIState state)
    {
        if (state == uiState)
            return;
        PG_UIPrefabContainer uIPrefabContainer = PG_UIPrefabContainer.Instance;
        //삭제
        if(uiState == PGUIState.Loading)
        {
            
        }
        else if(uiState == PGUIState.Lobby)
        {

        }
        else if(uiState == PGUIState.world)
        {
            if(panel_UIWorld != null)
            {
                Destroy(panel_UIWorld);
            }
        }

        uiState = state;

        //생성
        if (uiState == PGUIState.Loading)
        {

        }
        else if (uiState == PGUIState.Lobby)
        {

        }
        else if (uiState == PGUIState.world)
        {
            panel_UIWorld = SpawnUIObject(uIPrefabContainer.pannel_World).GetComponent<Panel_UIWorld>();
        }


    }
}
