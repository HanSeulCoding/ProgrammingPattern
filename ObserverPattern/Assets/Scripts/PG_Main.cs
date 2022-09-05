using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PG_Main : MonoBehaviour
{
    private static PG_Main instance;

    public static PG_Main Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    public PG_UIMain uiMain;
    public PG_Player player;
    public PGInitialState initialState = PGInitialState.World_Offline;
    public bool isGamePause = false;

    private InputHandler _inputHandler;
    public InputHandler InputHandler
    {
        get { return _inputHandler; }
    }
 
    private Command command;
 
    public PG_ActorCamera ActorCamera;
    private void Awake()
    {
        instance = this;
        ActorCamera = PG_ActorCamera.Instance;
    }
    void Start()
    {
        _inputHandler = new InputHandler();
        KeySet();
        uiMain = PG_UIMain.Instance;

        player.Start_Actor();

        if(initialState == PGInitialState.World_Offline)
        {
            uiMain.ChangeUIState(PGUIState.world);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePause)
        {
            player.Update_Actor();
        }
    }

    private void KeySet()
    {
        _inputHandler.SetCommand(CommandsType.UP, KeyCode.W);
        _inputHandler.SetCommand(CommandsType.DOWN, KeyCode.S);
        _inputHandler.SetCommand(CommandsType.RIGHT, KeyCode.D);
        _inputHandler.SetCommand(CommandsType.LEFT, KeyCode.A);
        _inputHandler.SetCommand(CommandsType.ENTER, KeyCode.Return);
        _inputHandler.SetCommand(CommandsType.SPACE, KeyCode.Space);
    }
    private void LateUpdate()
    {
        ActorCamera.LookTarget(player.transform);
    }
}
