using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stat variables
    public int hp;
    public float spd, atk, def;
    private Leg leg;

    void Start()
    {
        leg = GetComponent<Leg>();
    }

    //adjusting all stats based on gained buffs and upgrades
    void Update()
    {
        if (leg.currentLeg != null)
            spd = leg.currentLeg.spd;
        else spd = 3;
    }
}
