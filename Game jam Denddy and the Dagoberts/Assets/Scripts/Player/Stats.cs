using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stat variables
    public int hp;
    public float spd, atk, def;

    private Leg leg;
    private Torso torso;

    void Start()
    {
        hp = 10;
        spd = 3;
        leg = GetComponent<Leg>();
        torso = GetComponent<Torso>();
    }

    //adjusting all stats based on gained buffs and upgrades
    void Update()
    {
        //if (torso.currentTorso != null)
        //    hp = torso.currentTorso.hp;

        if (leg.currentLeg != null)
            spd = leg.currentLeg.spd;

    }
}
