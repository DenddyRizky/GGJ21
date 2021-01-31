using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChitinArmour : Torso
{
    public int armourHp;
    // Start is called before the first frame update
    void Start()
    {
        equipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped)
        {
            hp += armourHp;
        }
    }
}
