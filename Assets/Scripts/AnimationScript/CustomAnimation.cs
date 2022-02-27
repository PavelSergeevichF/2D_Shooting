using System.Collections.Generic;
using UnityEngine;

public class CustomAnimation
{
    public Track Track;
    public List<Sprite> Sprites;
    public bool Loop = false;
    public float Speed = 10;
    public float Counter;
    public bool Sleeps;

    public void Update()
    {
        if (Sleeps)
            return;

        Counter += Time.deltaTime * Speed;

        if (Loop)
        {
            if (Sprites.Count > 0)
            {
                while (Counter > Sprites.Count)
                    Counter -= Sprites.Count;
            }
            else
            {
                Debug.Log("Sprites.Count =0"); 
            }
        }
        else if (Counter > Sprites.Count)
        {
            Counter = Sprites.Count - 1;
            Sleeps = true;
        }
    }
}
