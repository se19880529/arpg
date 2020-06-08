using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectAnimState
{
    Idle,
    Walk,
    Run,
    CustomState
}

public class ObjectViewBase
{
    public virtual void OnAttach()
    {

    }
    public virtual void OnDetach()
    {

    }
    public virtual void SetAnimationState(int state)
    {
        
    }
	public virtual void setPosition(float x, float y)
    {
    }
    public virtual void setYaw(float angle)
    {

    }
}
