using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AnimEnd();
public static class PG_ActorUtility
{
    public static IEnumerator CheckAnimationState(Animator animator, string animName, LayerType layerType, AnimEndState state)
    {
        while (!animator.GetCurrentAnimatorStateInfo((int)layerType).IsName(animName))
        {
            yield return null;
        }
        while (animator.GetCurrentAnimatorStateInfo((int)layerType).normalizedTime < 0.8f)
        {
            yield return null;
        }

        PG_Global._animEndDelegate[(int)state]();
    }
}
