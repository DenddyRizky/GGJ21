using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlotEnemy : EnemyControllerScript
{
    // Start is called before the first frame update
    void Start()
    {
        libsTypes = new List<GameObject>();
        LibSlots = new List<GameObject>();
        maxLibCount = 2;

        for (int i = 0; i < maxLibCount; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
