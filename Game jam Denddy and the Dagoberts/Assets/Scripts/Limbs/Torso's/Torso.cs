using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{

    public int[] activeTorso;
    public int hp;
    public int torsoNumber;
    public Torso currentTorso;
    public ChitinArmour chitinArmour;
    public TentacleBody tentacleBody;
    public AngelWings angelWings;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        chitinArmour = GetComponent<ChitinArmour>();
        tentacleBody = GetComponent<TentacleBody>();
        angelWings = GetComponent<AngelWings>();
        anim = GetComponent<Animator>();
        activeTorso = new int[4];
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            torsoNumber = 1;
            
            SwitchTorso();
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            torsoNumber = 2;
            SwitchTorso();
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            torsoNumber = 3;
            SwitchTorso();
        }
        anim.SetInteger("Armour", torsoNumber);
    }

    void SwitchTorso()
    {
        

        switch (activeTorso[torsoNumber])
        {
            case 1:
                
                chitinArmour.enabled = true;
                chitinArmour.equipped = true;
                currentTorso = chitinArmour;
                
                break;
            case 2:
                tentacleBody.enabled = true;
                currentTorso = tentacleBody;
                break;
            case 3:
                angelWings.enabled = true;
                currentTorso = angelWings;
                break;
            case 0:
                currentTorso = null;
                break;
        }
    }
}
