using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VARS
{
    public static int doneCount = 0;
    public static int points = 0;

    public static readonly int anim_speed = Animator.StringToHash("speed");
    public static readonly int anim_isFalling = Animator.StringToHash("isFalling");
    public static readonly int anim_isJumping = Animator.StringToHash("isJumping");

    public enum GENDER
    {
        MALE,
        FEMALE
    }
}
