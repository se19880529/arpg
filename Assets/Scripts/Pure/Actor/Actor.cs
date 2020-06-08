using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    private ObjectViewBase _view;
    private int hp;
    private Vector3 _targetPos = new Vector3(0, 0);
    private Vector3 _currentPos = new Vector3(0, 0);

    private Vector3 _moveVelocity = new Vector3(0, 0);

    public Actor()
    {
        this._currentPos.Set(0, 0, 0);
        this._targetPos.Set(0, 0, 0);
    }

    private void _TickWalk(float dt)
    {
        /*
        var dist = _targetPos - _currentPos;
        var mag = dist.magnitude;
        if(dist.magnitude < 3)
        {
            _currentPos = _targetPos;
        }
        else
        {
            float amount = dt * 10;
            if(amount > mag)
            {
                amount = mag;
            }
            _currentPos.x = _currentPos.x + dist.x * amount / mag;
            _currentPos.y = _currentPos.y + dist.y * amount / mag;
        }*/
        _currentPos.x = _currentPos.x + dt * _moveVelocity.x;
        _currentPos.y = _currentPos.y + dt * _moveVelocity.y;
        _view.setPosition(_currentPos.x, _currentPos.y);
    }

    public void SetView(ObjectViewBase v)
    {
        if(this._view != null)
        {
            this._view.OnDetach();
        }
        this._view = v;
        if(this._view != null)
        {
            this._view.OnAttach();
        }

    }

    public void MoveTo(float x, float y)
    {
        _targetPos.x = x;
        _targetPos.y = y;
    }

    public void Move(Vector3 vel)
    {
        _moveVelocity = vel;
        var norm = vel.magnitude;
        if(norm < 0.1)
        {
            _moveVelocity.Set(0, 0, 0);
            this._view.SetAnimationState((int)ObjectAnimState.Idle);
        }
        else
        {
            vel.Normalize();
            this._view.setYaw(Mathf.Atan2(vel.y, vel.x));
            this._view.SetAnimationState((int)ObjectAnimState.Walk);
        }
    }

    public void Tick(float dt)
    {
        _TickWalk(dt);
    }
}
