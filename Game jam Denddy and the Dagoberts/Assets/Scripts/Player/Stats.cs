using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stat variables
    public int hp, maxhp;
    public float spd, atk, def;
    private Leg leg;
    private Head head;

    void Start()
    {
        leg = GetComponent<Leg>();
        head = GetComponent<Head>();
    }

    //adjusting all stats based on gained buffs and upgrades
    void Update()
    {
        if (head.headNumber == 1)
            atk *= 1.2f;
        else atk *= 1f;
        if (leg.currentLeg != null)
            spd = leg.currentLeg.spd;
        else spd = 3;
    }
}
