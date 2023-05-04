using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterAnimParams
{    
    public static int X_Axis => Animator.StringToHash("X");
    public static int Y_Axis => Animator.StringToHash("Y");
    public static string LayerIdle => "Idle";
    public static string LayerWalk => "Walk";
}
