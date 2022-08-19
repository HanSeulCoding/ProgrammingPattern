using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click_UIInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click_Button_Setting()
    {
        PG_UIMain uiMain = PG_UIMain.Instance;
        PopUp_UIGameSetting uiGameSetting = uiMain.popup_UIGameSetting;

        if(uiGameSetting == null)
        {
            uiGameSetting = uiMain.SpawnUIObjectNonScale(PG_UIPrefabContainer.Instance.popup_Setting, uiMain.transform).GetComponent<PopUp_UIGameSetting>();
            uiMain.popup_UIGameSetting = uiGameSetting;

            RectTransform rect = uiGameSetting.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(Screen.width*0.5f - rect.sizeDelta.x*0.5f, -(Screen.height * 0.5f) + rect.sizeDelta.y * 0.5f);
        }
        else
        {
            uiGameSetting.gameObject.SetActive(!uiGameSetting.gameObject.activeSelf);
        }
        
    }
}
