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
    public InGame_Player player;
    public PGInitialState initialState = PGInitialState.World_Offline;
    bool isGamePause = false;

    private InputHandler _inputHandler;
    public InputHandler InputHandler
    {
        get { return _inputHandler; }
    }
 
    private Command command;
 
    public InGame_ActorCamera ActorCamera;
    private void Awake()
    {
        instance = this;
        ActorCamera = InGame_ActorCamera.Instance;
    }
    void Start()
    {
        _inputHandler = new InputHandler();
        _inputHandler.SetCommand();
        uiMain = PG_UIMain.Instance;

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
            player.PlayerControl();
            player.Move_End();
        }
    }

    private void LateUpdate()
    {
        ActorCamera.LookTarget(player.transform);
    }
}