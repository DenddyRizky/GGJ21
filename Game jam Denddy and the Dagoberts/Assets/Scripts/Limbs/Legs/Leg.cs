﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    public float spd;
    public int[] ActiveLegs;
    public int legNumber;
    public Leg currentLeg;
    public Rollerskates rollerskates;
    public Sneakers sneakers;
    public SpikeBoots spikeBoots;
    // Start is called before the first frame update
    void Start()
    {   
        rollerskates = GetComponent<Rollerskates>();
        sneakers = GetComponent<Sneakers>();
        spikeBoots = GetComponent<SpikeBoots>();
        ActiveLegs = new int[4];
        spd = 3;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void SwitchLeg()
    {
        sneakers.enabled = false;
        rollerskates.enabled = false;
        spikeBoots.enabled = false;

        switch (ActiveLegs[legNumber])
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