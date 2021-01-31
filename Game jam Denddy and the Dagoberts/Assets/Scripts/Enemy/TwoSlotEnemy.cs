using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlotEnemy : EnemyControllerScript
{
    // Start is called before the first frame update
    void Start()
    {
        limbsTypes = new List<GameObject>();
        LimbSlots = new List<GameObject>();
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
