using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Achivement(AchivementType achivementType);
public delegate void keySettingClick(CommandsType commandsType);
public delegate void AnimEndDelegate();
static public class PG_Global
{
    // Start is called before the first frame update

    public static keySettingClick KeySettingClick;
    public static AnimEndDelegate[] _animEndDelegate = new AnimEndDelegate[(int)AnimEndState.COUNT];
    public static Achivement[] _achiveMentDelgate = new Achivement[(int)AchivementType.Count];

}
