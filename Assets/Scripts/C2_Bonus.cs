using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2_Bonus : AC1_Actor
{
    
    public Material[] m_Material = new Material[14];
    //-----Повышение характеристик-----
    //0 - Повышение скорости танка
    //1 - Повышение скорости снаряда
    //2 - Повышение частоты выстрелов
    //3 - Повышение мощности снаряда
    //4 - Дополнительный слой брони

    //-----Дополнительное снаряжение----
    //5 - Радар
    //6 - Воздушная подушка
    //7 - Плавучесть
    //8 - Заморозка

    //-----Супероружие------
    //9 - Мортира
    //10 - Неонная пушка
    //11 - Мина
    //12 - Шип

    //13 - Жизнь

    //Дополнительная жизнь

    public int type;
    private Transform me;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        me = GetComponent<Transform>();
        me.position = new Vector3(Random.Range(-16.0f, 16.0f), 0, Random.Range(-8.0f, 8.0f));
        me.rotation = Quaternion.Euler(0,90,0);
        int chance = Random.Range(0, 41);
        if (chance < 20) type = Mathf.FloorToInt(chance / 4);
        else if (chance < 32) type = Mathf.FloorToInt((chance - 20) / 3) + 5;
        else if (chance < 40) type = Mathf.FloorToInt((chance - 32) / 2) + 9;
        if (chance == 40) type = 13;
        GetComponent<Renderer>().material = m_Material[type];
        me.eulerAngles = Vector3.zero;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        me.Rotate(0, 0, 0.7f);
        if (Input.GetButtonDown("Fire2"))
            Destroy(gameObject);
    }

    public int getType ()
    {
        return type;
    }
}
