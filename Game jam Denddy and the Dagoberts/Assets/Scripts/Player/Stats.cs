using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stat variables
    public int hp, maxhp;
    public float spd, atkspd, def;

    private Leg leg;
    private Head head;
    private Torso torso;

    void Start()
    {
        atkspd = 1;
        hp = 10;
        spd = 3;
        leg = GetComponent<Leg>();
        head = GetComponent<Head>();
        torso = GetComponent<Torso>();
    }

    //adjusting all stats based on gained buffs and upgrades
    void Update()
    {
<<<<<<< HEAD
        if (head.headNumber == 1)
            atkspd *= 0.6f;
        else atkspd *= 1f;
        if (torso.currentTorso != null)
            hp = torso.currentTorso.hp;
=======
        //if (torso.currentTorso != null)
        //    hp = torso.currentTorso.hp;

>>>>>>> main
        if (leg.currentLeg != null)
            spd = leg.currentLeg.spd;

    }
}
