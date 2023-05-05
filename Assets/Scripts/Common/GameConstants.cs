using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterAnimParams
{    
    public static int X_Axis => Animator.StringToHash("X");
    public static int Y_Axis => Animator.StringToHash("Y");
    public static int Defeated => Animator.StringToHash("Defeated");
    public static string IdleLayer => "Idle";
    public static string WalkLayer => "Walk";
}
public static class GameTags
{
    public static string Player => "Player";
}