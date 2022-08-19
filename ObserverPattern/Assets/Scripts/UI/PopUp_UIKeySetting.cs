using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopUp_UIKeySetting : MonoBehaviour
{
    public List<TMP_Text> keyInputFields;

    private PG_Main main;
    private InputHandler inputHandler;
    private CommandsType currentCommandsType;

    private bool isClick;
    public void Start()
    {
        main = PG_Main.Instance;
        InitKeyInputFields();
    }
    void InitKeyInputFields()
    {
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;
        for (int i = 0; i < keyInputFields.Count; ++i)
        {
            keyInputFields[i].text = commands[i].keyCode.ToString();
        }
    }
    string ConvertToString(KeyCode keyCode)
    {
        string s;
        s = keyCode.ToString();

        return s;
    }

    public void ClickInputKeyBtn(int commandsType)
    {
        currentCommandsType = (CommandsType)commandsType;
    }
    public void ReallocateKeyCode(KeyCode keyCode)
    {
        inputHandler = main.InputHandler;
        Command[] commands = inputHandler.commands;
        commands[(int)currentCommandsType].keyCode = keyCode;
        keyInputFields[(int)currentCommandsType].text = keyCode.ToString();
    }
    public void ClickReturnBtn()
    {
        gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey)
        {
            ReallocateKeyCode(keyEvent.keyCode);
        }
    }
}
