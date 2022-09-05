using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUp_UIKeySetting : MonoBehaviour
{
    private static PopUp_UIKeySetting _instance;
    public static PopUp_UIKeySetting Instance
    {
        get
        {
            return _instance;
        }
    }
    public List<TMP_Text> keyInputFields;
    public List<UI_KeySetting_KeyClickBtn> keyClickBtn;
    private PG_Main main;
    private InputHandler inputHandler;
    Command[] commands;
    private CommandsType currentCommandsType;
    private CommandsType clickCommandsType = CommandsType.Count;
    private bool isClick;
    public void Start()
    {
        main = PG_Main.Instance;

        PG_Global.KeySettingClick += KeySwap;
        InitKeyInputFields();
        InitKeyButton();
    }
    void InitKeyInputFields() //초기 CommandType에 대한 KeyCode를 출력해준다. 
    {
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;
        for (int i = 0; i < keyInputFields.Count; ++i)
        {
            keyInputFields[i].text = commands[i].keyCode.ToString();
        }
       
    }
    void InitKeyButton() //초기 CommandType 에 대한 Command 정보를 출력해준다. 
    {
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;
        for (int i = 0; i < keyClickBtn.Count; ++i)
        {
            keyClickBtn[i].text.text = commands[i].Print();
        }
    }

    public void ReallocateKeyCode(KeyCode keyCode) //InputField 및 키코드 교환
    {
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;
        for (int i = 0; i < commands.Length; ++i) //중복 키 막기
        {
            if (commands[i].keyCode == keyCode)
               return;

        }
        commands[(int)currentCommandsType].keyCode = keyCode;
        keyInputFields[(int)currentCommandsType].text = keyCode.ToString();
    }
    private void KeySwap(CommandsType inputCommandsType)
    {
        if (clickCommandsType == CommandsType.Count) //처음 입력받았을 시, 스왑되면 안된다.
        {
            clickCommandsType = inputCommandsType;
            return;
        }
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;

        if (inputCommandsType == clickCommandsType)
        {
            return;
        }
        //KeyCode Swap
        KeyCode k_temp = commands[(int)inputCommandsType].keyCode;
        commands[(int)inputCommandsType].keyCode = commands[(int)clickCommandsType].keyCode;
        commands[(int)clickCommandsType].keyCode = k_temp;

        Command temp = commands[(int)inputCommandsType];
        commands[(int)inputCommandsType] = commands[(int)clickCommandsType];
        commands[(int)clickCommandsType] = temp;

        clickCommandsType = CommandsType.Count;
        InitKeyButton();
        InitKeyInputFields();
    }
    public void ClickInputFieldBtn(int n)
    {
        currentCommandsType = (CommandsType)n;
    }
    public void ClickReturnBtn()
    {
        gameObject.SetActive(false);
    }
    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey && keyEvent.keyCode != KeyCode.None)
        {
            ReallocateKeyCode(keyEvent.keyCode);
        }
    }
}
