using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    public float spd;
    public int[] activeLegs;
    public int legNumber;
    public Leg currentLeg;
    public Rollerskates rollerskates;
    public Sneakers sneakers;
    public SpikeBoots spikeBoots;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rollerskates = GetComponent<Rollerskates>();
        sneakers = GetComponent<Sneakers>();
        spikeBoots = GetComponent<SpikeBoots>();
        activeLegs = new int[4];
        spd = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs only work if particular parts are unlocked in Movement.cs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            legNumber = 1;
            SwitchLeg();
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            legNumber = 2;
            SwitchLeg();
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            legNumber = 3;
            SwitchLeg();
        }
        anim.SetInteger("Leg", legNumber);
    }

    void SwitchLeg()
    {
        sneakers.enabled = false;
        rollerskates.enabled = false;
        spikeBoots.enabled = false;

        switch (activeLegs[legNumber])
        {
            case 1:
                sneakers.enabled = true;
                currentLeg = sneakers;
                break;
            case 2:
                rollerskates.enabled = true;
                currentLeg = rollerskates;
                break;
            case 3:
                spikeBoots.enabled = true;
                currentLeg = spikeBoots;
                break;
            case 0:
                currentLeg = null;
                break;
        }
    }
}
