using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorViewImp : ObjectViewBase
{
    private GameObject _go;
    private Animator _anim;
    private int _state;

    public ActorViewImp(GameObject go)
    {
        _go = go;
        _anim = _go.GetComponent<Animator>();
    }

    public override void OnAttach()
    {
        base.OnAttach();
    }
    public override void OnDetach()
    {
        base.OnDetach();
    }
    public override void SetAnimationState(int state)
    {
        if(_state != state)
        {
            _state = state;
            Debug.LogFormat("state change to {0}", state);
            base.SetAnimationState(state);
            _anim.SetInteger("state", state);
        }
    }
    public override void setPosition(float x, float y)
    {
        _go.transform.localPosition = new Vector3(x, 0, y);
    }
    public override void setYaw(float angle)
    {
        _go.transform.localRotation = Quaternion.Euler(0, 360 - (angle * 180 / Mathf.PI - 90), 0);
    }
}
