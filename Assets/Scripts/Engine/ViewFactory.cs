using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFactory : MonoBehaviour, IViewFactory
{
    public GameObject actorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ObjectViewBase CreateActorView()
    {
        var go = Instantiate(actorPrefab);
        var ret = new ActorViewImp(go);
        go.transform.parent = this.transform;
        return ret;
    }
}
