using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTransition : MonoBehaviour
{
    public Animator Transition;

    public void CallTransition()
    {
        Transition.Play("FirstTransitionClose");
    }
}
