using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_World : MonoBehaviour
{
    public GameObject Bonus;
    public GameObject Tank;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
            Instantiate(Bonus, transform.position.normalized, Quaternion.identity);
    }
}
