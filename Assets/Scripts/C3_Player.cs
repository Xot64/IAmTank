using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_Player : AC2_Tank
{
    public bool[] but = new bool[4];
    public byte[] dir = new byte[4];
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        control();
    }

    private void control()
    {
        but[0] = Input.GetButton("Right");
        but[1] = Input.GetButton("Down");
        but[2] = Input.GetButton("Left");
        but[3] = Input.GetButton("Up");

        if (Input.GetButtonDown("Right")) redir(0);
        if (Input.GetButtonDown("Down"))  redir(1);
        if (Input.GetButtonDown("Left"))  redir(2);
        if (Input.GetButtonDown("Up"))    redir(3);

        byte mv = 0;
        byte d = 0;
        bool push = false;
        for (byte i = 0; i < 4; i++)
        {
            if (but[i]) push = true;
            if (mv < dir[i] && but[i])
            {
                mv = dir[i];
                d = i;
            }
        }
        if (push)
        {
            direction = d;
            move();
        }
        else
        {
            stop();
        }
    }

    private void redir (byte d)
    {
        if (dir[d] == 3) return;
        for (byte i = 0; i < 4; i++)
        {
            if (but[i])
                if (i == d)
                {
                    dir[i] = 3;
                }
                else
                {
                    if (dir[i] > 0) dir[i]--;
                }
            else
            {
                dir[i] = 0;
            }
        }
    }
}
