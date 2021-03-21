using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AC2_Tank : AC1_Actor
{
    //Рассчетые параметры
    private const float k_speed = 3.0f;     //Коэффициент настройки скорости
    private const float k_rotation = 1f;  //Коэффициент скорости вращения
    private float angle;                    //Угол поворота танка
    private float delta;                    //Смещение от направления танка


    //Параметры 
    public int direction;  // Направление: 0 - Вправо, 1 - Вниз, 2 - Влево, 3 - Вверх 
    public C2_Bullet bullet;

    //Регулируются бонусами 1 уровня
    public int speed;          //Скорость движения 1-4
    public int power;          //Мощность снаряда 1-3
    public int bulletSpeed;    //Скорость снаряда 1-3
    public int shootFrequency; //Частота выстрелов 1-6 (1/3 ... 2)
    public int armor;          //Толщина брони 1-3
    public int lives;          //Жизни

    //Пределы параметров
    private const int speedMin = 1;
    private const int speedMax = 4;

    private const int powerMin = 1;
    private const int powerMax = 3;

    private const int bulletSpeedMin = 1;
    private const int bulletSpeedMax = 3;

    private const int shootFrequencyMin = 1;
    private const int shootFrequencyMax = 6;

    private const int armorMin = 1;
    private const int armorMax = 3;


    //Бонусы 2 (Гаджеты)
    public bool[] gadget = new bool[4];      //0 - Радар; 1 - Воздушная подушка; 2 - Плавучесть; 3 - Заморозка;

    //Бонусы 3 (Доп Оружие) 
    //public bool[] superWeapon = new bool[4]; //0(Мортира); 1(Неонная пушка); 2(Мина); 3(Шип)
    public bool[] extraGun = new bool[4]; //0(Мортира); 1(Неонная пушка); 2(Мина); 3(Шип)




    private GameObject Tank;
    private Transform me;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        me = GetComponent<Transform>();
        Tank = gameObject;
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
        if (Mathf.Abs(delta) < 0.1f)
            me.rotation = Quaternion.Euler(0, direction * 90.0f, 0);
        else
            me.Rotate(0, delta * k_rotation * speed, 0);
    }

    public void move()
    {
        float d = direction % 4;
        float speedX = ((d == 0) || (d == 2)) ? (speed * k_speed * Mathf.Abs(Mathf.Cos(C_MF.G2R(angle)))) : 0;
        float speedY = ((d == 1) || (d == 3)) ? (speed * k_speed * Mathf.Abs(Mathf.Sin(C_MF.G2R(angle)))) : 0;
        Tank.GetComponent<Rigidbody>().velocity = new Vector3(speedX * (1 - d), 0, speedY * (d - 2));
    }
    public void stop()
    {
        Tank.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void add(ref int name, int max)
    {
        name += (name < max) ? 1 : 0;
    }
    public void addSpeed() { add(ref speed, speedMax); }
    public void addPower() { add(ref power, powerMax); }
    public void addBulletSpeed() { add(ref bulletSpeed, bulletSpeedMax); }
    public void addShootFrequency() { add(ref shootFrequency, shootFrequencyMax); }
    public void addArmor() { add(ref armor, armorMax); }
    public void addLife() { add(ref lives, 100); }
    public void Death()
    {
        if (lives < 2) Destroy(gameObject);
        else
        {
            lives--;
            Tank.SetActive(false);
            me.position = new Vector3(X, 0, Y);
            Tank.SetActive(true);
        }
    }

    



    public override void OnTriggerEnter(Collider other)
    {
         
        base.OnTriggerEnter(other);
        if ((Tank.tag == "Player") || ((Tank.tag == "Enemy") && (Tank.GetComponent<C3_Enemy>().CanTakeBonus)))
        {
            switch (other.tag)
            {
                case "Bonus":
                    int type = other.GetComponent<C2_Bonus>().getType();
                    switch (type)
                    {
                        case 0:
                            addSpeed();
                            break;
                        case 1:
                            addBulletSpeed();
                            break;
                        case 2:
                            addShootFrequency();
                            break;
                        case 3:
                            addPower();
                            break;
                        case 4:
                            addArmor();
                            break;
                        case 5:
                            gadget[0] = true;
                            break;
                        case 6:
                            gadget[1] = true;
                            break;
                        case 7:
                            gadget[2] = true;
                            break;
                        case 8:
                            gadget[3] = true;
                            break;
                        case 9:
                            extraGun[0] = true;
                            extraGun[1] = false;
                            extraGun[2] = false;
                            break;
                        case 10:
                            extraGun[0] = false;
                            extraGun[1] = true;
                            extraGun[2] = false;
                            break;
                        case 11:
                            extraGun[0] = false;
                            extraGun[1] = false;
                            extraGun[2] = true;
                            break;
                        case 12:
                            extraGun[3] = true;
                            break;
                        case 13:
                            if (Tank.tag == "Player") addLife();
                            break;
                    }
                    if ((type < 14) || (Tank.tag == "Player"))
                    {
                        Destroy(other.gameObject);
                    }
                    break;
                case "Bullet":
                    Death();
                    break;
            }
        }
    }
}
