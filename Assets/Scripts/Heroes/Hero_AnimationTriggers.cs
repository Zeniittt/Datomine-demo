using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_AnimationTriggers : MonoBehaviour
{
    private Hero hero => GetComponentInParent<Hero>();

    private void AnimationFinishTrigger()
    {
        hero.AnimationFinishTrigger();
    }
}
