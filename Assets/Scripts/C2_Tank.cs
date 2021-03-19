using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class C2_Tank : C1_Actor
{
    //Движение
    public byte direction;
    public byte speed;

    //Стрельба
    public byte power;
    public byte bulletSpeed;
    public byte shootFrequency;
    public C2_Bullet bullet;
    public bool antiArmor;

    //Другое
    public byte armor;
    public byte superWeapon; //1(Мортира); 2(Неонная пушка); 3(Мина)

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }
}
