using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private List<Actor> _allActors = new List<Actor>();
    private IViewFactory _viewFactory;

    public void SetViewFactory(IViewFactory f)
    {
        this._viewFactory = f;
    }
    public Actor AddActor(Actor actor)
    {
        actor.SetView(this._viewFactory.CreateActorView());
        this._allActors.Add(actor);
        return actor;
    }

    public void Tick(float dt)
    {
        var iter = _allActors.GetEnumerator();
        while(iter.MoveNext())
        {
            iter.Current.Tick(dt);
        }
    }
}
