using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private Game _game = new Game();
    private Actor _player = new Actor();
    // Start is called before the first frame update
    void Start()
    {
        _game.SetViewFactory(GetComponent<ViewFactory>());
        this._player = _game.AddActor(new Actor());
        this._player.MoveTo(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        _game.Tick(Time.deltaTime);

        Vector3 speed = default;
        byte dirMask = 0;
        if(Input.GetKey(KeyCode.W))
        {
            dirMask |= 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            dirMask |= 2;
        }
        if(Input.GetKey(KeyCode.A))
        {
            dirMask |= 4;
        }
        if(Input.GetKey(KeyCode.D))
        {
            dirMask |= 8;
        }
        if(dirMask == 1)
        {
            speed.Set(0, 1, 0);
        }
        else if(dirMask == 2)
        {
            speed.Set(0, -1, 0);
        }
        else if(dirMask == 4)
        {
            speed.Set(-1, 0, 0);
        }
        else if(dirMask == 8)
        {
            speed.Set(1, 0, 0);
        }

        this._player.Move(speed * 2);
    }  
}
