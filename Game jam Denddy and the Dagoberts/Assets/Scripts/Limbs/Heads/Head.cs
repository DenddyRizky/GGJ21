using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public int[] ActiveHeads;
    public int headNumber;
    public Head currentHead;
    public Stats stats;
    private int heal;
    // Start is called before the first frame update
    void Start()
    {
        ActiveHeads = new int[4];
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        heal = stats.maxhp / 2;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            headNumber = 1;
            switchHead();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            headNumber = 2;
            switchHead();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            headNumber = 3;
            switchHead();
        }

//        if (receive deathsignal)
//        {
//            if (headNumber == 3)
//            {
//                stats.hp += heal ;
//            }
//        }
        
    }

    void switchHead()
    {
        switch (ActiveHeads[headNumber])
        {
            case 1:
                Debug.Log("SHARINGAN");
                break;
            case 2:
                Debug.Log("SCARY FACE");
                break;
            case 3:
                Debug.Log("BIG FACE");
                break;
            case 0:
                currentHead = null;
                break;
        }
    }
}
