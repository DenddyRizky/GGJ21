using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public float attack;
    public int[] types;
    public int weaponNumber;
    private Arm currentArm;

    // Start is called before the first frame update
    void Start()
    {
        types = new int[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponNumber = 0;
            Debug.Log(0);
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponNumber = 1;
            Debug.Log(2);
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponNumber = 2;
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponNumber = 3;
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponNumber = 4;
            switchArm();
        }
    }

    void switchArm()
    {
        MagicOrb magicOrb = GetComponent<MagicOrb>();
        GunArm gun = GetComponent<GunArm>();
        TentacleSlap tentacle = GetComponent<TentacleSlap>();
        LongNails nails = GetComponent<LongNails>();
        SlappyHand slap = GetComponent<SlappyHand>();

        magicOrb.enabled = false;
        gun.enabled = false;
        tentacle.enabled = false;
        nails.enabled = false;
        slap.enabled = true;
        currentArm = slap;

        switch (types[weaponNumber])
        {
            case 1:
                slap.enabled = false;
                gun.enabled = true;
                currentArm = gun;
                break;
            case 2:
                slap.enabled = false;
                magicOrb.enabled = true;
                currentArm = magicOrb;
                break;
            case 3:
                slap.enabled = false;
                tentacle.enabled = true;
                currentArm = tentacle;
                break;
            case 4:
                slap.enabled = false;
                nails.enabled = true;
                currentArm = nails;
                break;
            case 5:
                print("Basic");
                break;
            default:
                Debug.Log("BROKE");
                break;
        }
    }
}
