using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{
    private bool _isUp;
    public Animator animator;

    private void AnimatorUp()
    {
        animator.SetTrigger("yukarı");
        _isUp = true;
    }
    
    private void AnimatorDown()
    {
        animator.SetTrigger("assa");
        _isUp = false;
    }

    public void ButtonTask()
    {
        if(_isUp)
            AnimatorDown();
        else
        {
            AnimatorUp();
        }
    }
    
}
