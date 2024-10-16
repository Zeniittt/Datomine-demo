using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mostar_AnimationTriggers : Hero_AnimationTriggers
{
    Mostar hero => GetComponentInParent<Mostar>();

    private void Relocate() => hero.TeleportToPosition();
}
