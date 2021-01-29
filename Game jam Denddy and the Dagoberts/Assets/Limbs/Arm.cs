using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public float attack;
    public float attackSpeed;
    public float spread;
    public int[] types;
    public int weaponNumber;

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
            weaponNumber = 2;
            Debug.Log(2);
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponNumber = 3;
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponNumber = 4;
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponNumber = 5;
            switchArm();
        }
    }

    void switchArm()
    {
        switch (types[weaponNumber])
        {
            case 1:
                //GunArm gun = gameObject.AddComponent(typeof(GunArm)) as GunArm;
                GunArm gun = GetComponent<GunArm>();
                gun.enabled = true;
                break;
            case 2:
                print("Magic");
                break;
            case 3:
                print("Tentacle");
                break;
            case 4:
                print("Nails");
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
