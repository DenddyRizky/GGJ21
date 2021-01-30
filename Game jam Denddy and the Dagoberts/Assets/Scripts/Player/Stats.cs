using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stat variables
    public int hp, maxhp;
    public float spd, atk, def;

    private Leg leg;
<<<<<<< HEAD
    private Head head;
=======
    private Torso torso;
>>>>>>> main

    void Start()
    {
        hp = 10;
        spd = 3;
        leg = GetComponent<Leg>();
<<<<<<< HEAD
        head = GetComponent<Head>();
=======
        torso = GetComponent<Torso>();
>>>>>>> main
    }

    //adjusting all stats based on gained buffs and upgrades
    void Update()
    {
<<<<<<< HEAD
        if (head.headNumber == 1)
            atk *= 1.2f;
        else atk *= 1f;
=======
        if (torso.currentTorso != null)
            hp = torso.currentTorso.hp;

>>>>>>> main
        if (leg.currentLeg != null)
            spd = leg.currentLeg.spd;

    }
}
