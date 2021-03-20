using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AC2_Tank : AC1_Actor
{
    //Движение
    public byte direction;
    public byte speed;
    private const float k_speed = 1.0f;
    private const float k_rotation = 1.5f;
    private float angle;
    private float delta;


    //Стрельба
    public byte power;
    public byte bulletSpeed;
    public byte shootFrequency;
    public C2_Bullet bullet;
    public bool antiArmor;

    //Другое
    public byte armor;
    public byte superWeapon; //1(Мортира); 2(Неонная пушка); 3(Мина)
    
    private Transform me;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        me = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        rotator();
    }

    public void rotator()
    {
        angle = (me.eulerAngles.y);
        delta = C_MF.round(C_MF.toRotation(angle, direction * 90.0f), 2) / 90;
        if (delta == 0) 
            me.rotation = Quaternion.Euler(0, direction * 90.0f, 0);
        else
            me.Rotate(0,delta*k_rotation,0);
    }

    public void move()
    {
        float d = direction % 4;
        float speedX = ((d == 0) || (d == 2)) ? (speed * k_speed * Mathf.Abs(Mathf.Cos(C_MF.G2R(angle)))) : 0;
        float speedY = ((d == 1) || (d == 3)) ? (speed * k_speed * Mathf.Abs(Mathf.Sin(C_MF.G2R(angle)))) : 0;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speedX * (1 - d), 0, speedY*(d - 2));
    }
    public void stop()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
