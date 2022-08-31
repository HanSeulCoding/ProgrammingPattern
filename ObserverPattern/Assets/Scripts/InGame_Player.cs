using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_Player : InGame_GameActor
{
    // Start is called before the first frame update
    void Start()
    {
        InitActor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerControl()
    {
        InputHandler inputHandler = PG_Main.Instance.InputHandler;

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.PRESS);

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.DOWN);

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.UP);
    }

}
