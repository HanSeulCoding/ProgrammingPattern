using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AnimEnd();
public class PG_ActorUtility : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator CheckAnimationState(Animator anim, string animName)
    {
        while(!anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            yield return null;
        }
        while(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
        {
            yield return null;
        }
    }
    //AnimEnd();

}
