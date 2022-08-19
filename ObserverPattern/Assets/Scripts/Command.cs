using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Command
{
    public KeyCode keyCode;
    public abstract void Execute(InGame_GameActor gameActor);
    public abstract void EndExecute(InGame_GameActor gameActor);
    public abstract string Print();
}

class Command_Skill : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Skill();
    }
    public override void EndExecute(InGame_GameActor gameActor) { }
   
    public override string Print()
    {
        return "skill";
    }
}

class Command_Attack : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Attack();
    }
    public override void EndExecute(InGame_GameActor gameActor) { }
 
    public override string Print()
    {
        return "Attack";
    }
}

class Command_Move_F : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Move(new Vector2(0,1),CommandsType.UP);
    }
   
    public override string Print()
    {
        return "Forward";
    }

    public override void EndExecute(InGame_GameActor gameActor)
    {
        gameActor.Input_IsPressMoveCommand(CommandsType.UP);
    }
}

class Command_Move_B : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Move(new Vector2(0,-1), CommandsType.DOWN);
    }
    public override string Print()
    {
        return "Back";
    }
    public override void EndExecute(InGame_GameActor gameActor)
    {
        gameActor.Input_IsPressMoveCommand(CommandsType.DOWN);
    }
}

class Command_Move_R : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Move(new Vector2(1,0), CommandsType.RIGHT);
    }
    public override string Print()
    {
        return "Right";
    }
    public override void EndExecute(InGame_GameActor gameActor)
    {
        gameActor.Input_IsPressMoveCommand(CommandsType.RIGHT);
    }
}

class Command_Move_L : Command
{
    public override void Execute(InGame_GameActor gameActor)
    {
        gameActor.Move(new Vector2(-1,0),CommandsType.LEFT);
    }
    public override string Print()
    {
        return "Left";
    }
    public override void EndExecute(InGame_GameActor gameActor)
    {
        gameActor.Input_IsPressMoveCommand(CommandsType.LEFT);
    }
}

public class InputHandler : MonoBehaviour
{
    public Command[] commands = new Command[(int)CommandsType.Count];
    //public Dictionary<KeyCode,Command> commands = new Dictionary<KeyCode, Command>();
    public Command handleInput()
    {
        if(Input.GetKey(commands[(int)CommandsType.UP].keyCode))
        {
            return commands[(int)CommandsType.UP];
        }
        if(Input.GetKey(commands[(int)CommandsType.DOWN].keyCode))
        {
            return commands[(int)CommandsType.DOWN];
        }
        if(Input.GetKey(commands[(int)CommandsType.RIGHT].keyCode))
        {
            return commands[(int)CommandsType.RIGHT];
        }
        if (Input.GetKey(commands[(int)CommandsType.LEFT].keyCode))
        {
            return commands[(int)CommandsType.LEFT];
        }
        if (Input.GetKeyDown(commands[(int)CommandsType.SPACE].keyCode))
        {
            return commands[(int)CommandsType.SPACE];
        }
        if (Input.GetKeyDown(commands[(int)CommandsType.ENTER].keyCode))
        {
            return commands[(int)CommandsType.ENTER];
        }
        return null;
    }
    public void handleInput(InGame_GameActor actor, CommandsType commansType, KeyPressType keyPressType)
    {
        bool isEnabledKey = false;
        bool isUpEnabledKey = false;
        bool[] isPressMoveCommand = new bool[4];

        KeyCode keyCode = commands[(int)commansType].keyCode;
        switch (keyPressType)
        {
            case KeyPressType.DOWN:
                isEnabledKey = Input.GetKeyDown(keyCode);
                break;
            case KeyPressType.PRESS:
                isEnabledKey = Input.GetKey(keyCode);
                break;
            case KeyPressType.UP:
                isUpEnabledKey = Input.GetKeyUp(keyCode);
                break;
            default:
                isEnabledKey = false;
                isUpEnabledKey = false;
                break;
        }

        if(isEnabledKey)
        {
            commands[(int)commansType].Execute(actor);
        }
        if(isUpEnabledKey)
        {
            commands[(int)commansType].EndExecute(actor);
        }
    }
    public void SetCommand()
    {   
        commands[(int)CommandsType.UP] = new Command_Move_F();
        commands[(int)CommandsType.DOWN] = new Command_Move_B();
        commands[(int)CommandsType.RIGHT] = new Command_Move_R();
        commands[(int)CommandsType.LEFT] = new Command_Move_L();
        commands[(int)CommandsType.SPACE] = new Command_Skill();
        commands[(int)CommandsType.ENTER] = new Command_Attack();

        commands[(int)CommandsType.UP].keyCode = KeyCode.W;
        commands[(int)CommandsType.DOWN].keyCode = KeyCode.S;
        commands[(int)CommandsType.RIGHT].keyCode = KeyCode.D;
        commands[(int)CommandsType.LEFT].keyCode = KeyCode.A;
        commands[(int)CommandsType.SPACE].keyCode = KeyCode.Space;
        commands[(int)CommandsType.ENTER].keyCode = KeyCode.KeypadEnter;
    }

    public void KeyCodeChange(CommandsType commandsType, KeyCode changeKeyCode)
    {
        commands[(int)commandsType].keyCode = changeKeyCode;
    }
    
    public void CommandChange(CommandsType aCommand, CommandsType bCommand)
    {

    }
}


