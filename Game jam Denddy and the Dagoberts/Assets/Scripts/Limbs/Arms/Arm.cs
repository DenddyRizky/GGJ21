using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    protected float attack;
    public float attackRate;
    protected int[] types;
    protected int weaponNumber;
    public bool attackCD;
    public float cooldownTime;
    public float cooldown;
    public Arm currentArm;
    protected Stats stat;
    protected Animator anim;
    public Transform attackPoint;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        stat = gameObject.GetComponent<Stats>();
        types = new int[5];
        types[0] = 1;
        types[1] = 2;
        types[2] = 3;
        types[3] = 4;
        types[4] = 5;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        moveAttackpoint();
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponNumber = 4;
            Debug.Log(0);
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponNumber = 0;
            Debug.Log(2);
            switchArm();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponNumber = 1;
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
        anim.SetInteger("Arms", weaponNumber);
    }

    void moveAttackpoint()
    {
        var worldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = (Vector2)(worldMousePos - transform.position);

        mouseDir.Normalize();
        attackPoint.position = (Vector2)transform.position + mouseDir;
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
    public void CheckAttackCD()
    {
        if (attackCD && cooldown >= 0)
        {
            cooldown -= (Time.deltaTime);
            Debug.Log(cooldown);
            if (cooldown <= 0)
            {
                attackCD = false;
                cooldown = cooldownTime - attackRate;
            }
        }
    }
}
