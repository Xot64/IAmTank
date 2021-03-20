using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2_Bonus : C1_Actor
{
    public byte[] type;
    //Повышение характеристик
    public Material m_material;
    public Material m_tankSpeed;     //Повышение скорости танка
    public Material m_bulletSpeed;   //Повышение скорости снаряда
    public Material m_shootFreq;     //Повышение частоты выстрелов
    public Material m_bulletPower;   //Повышение мощности снаряда
    public Material m_armor;         //Дополнительный слой брони

    //Дополнительное снаряжение
    public Material m_radar;         //Радар
    public Material m_airBag;        //Воздушная подушка
    public Material m_rod;           //Бронебойный шип
    public Material m_boat;          //Плавучесть
    public Material m_life;          //Дополнительная жизнь
    public Material m_freeze;        //Заморозка

    //Супероружие
    public Material m_megaGun;       //Радар
    public Material m_neonGun;       //Радар
    public Material m_mine;          //Радар

    private Transform me;
    private float t;
    private int c;
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
        me.Rotate(0, 0, 0.7f);
    }
}
