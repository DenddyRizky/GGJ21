using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{

    public int[] activeTorso;
    public int hp;
    public int torsoNumber;
    public bool equipped;
    public Torso currentTorso;
    public ChitinArmour chitinArmour;
    public TentacleBody tentacleBody;
    public AngelWings angelWings;

    // Start is called before the first frame update
    void Start()
    {
        chitinArmour = GetComponent<ChitinArmour>();
        tentacleBody = GetComponent<TentacleBody>();
        angelWings = GetComponent<AngelWings>();
        activeTorso = new int[3];
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            torsoNumber = 0;
            SwitchTorso();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            torsoNumber = 1;
            SwitchTorso();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            torsoNumber = 2;
            SwitchTorso();
        }
    }

    void SwitchTorso()
    {
        tentacleBody.enabled = false;
        chitinArmour.enabled = false;
        angelWings.enabled = false;

        switch (activeTorso[torsoNumber])
        {
            case 1:
                chitinArmour.enabled = true;
                chitinArmour.equipped = true;
                currentTorso = chitinArmour;
                break;
            case 2:
                tentacleBody.enabled = true;
                tentacleBody.equipped = true;
                currentTorso = tentacleBody;
                break;
            case 3:
                angelWings.enabled = true;
                angelWings.equipped = true;
                currentTorso = angelWings;
                break;
            case 0:
                currentTorso = null;
                break;
        }
    }
}
