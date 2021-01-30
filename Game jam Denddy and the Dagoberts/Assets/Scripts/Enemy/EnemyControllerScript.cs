using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public List<GameObject> libsTypes;
    public List<GameObject> LibSlots;
    public List<Arm> arms; 
    

    public GameObject player;
    
    protected bool attackMode = false;
    protected float attackRange;

    public float attackTimer;
    public float attackTime;

    public int maxLibCount;

    public float timer;
    public float checkTime;

    public List<Vector3> positionList;
    public List<Quaternion> quaternionList;


    // Start is called before the first frame update
    void Start()
    {
        attackTime = 3;
        positionList = new List<Vector3>();
        quaternionList = new List<Quaternion>();
        for (int i = 0; i < maxLibCount; i++)
        {
            positionList.Add(LibSlots[i].transform.position);
            quaternionList.Add(LibSlots[i].transform.rotation);

        }
        for (int i = 0; i < maxLibCount; i++)
        {
            LibSlots[i] = Instantiate(libsTypes[Random.Range(0, libsTypes.Count)] , gameObject.transform);
            LibSlots[i].transform.position = positionList[i];
            LibSlots[i].transform.rotation = quaternionList[i];
        }
     

    }

    // Update is called once per frame
    void Update()
    {

        if (attackTimer > attackTime)
        {
            
            foreach (var item in LibSlots)
            {

                string name = item.name;
                name = name.Substring(0, name.Length - 7);
                switch (name)
                {
                    case "GunArm":
                        item.GetComponent<GunArm>().Attack(player.transform.position, true);
                        break;
                    case "OrbArm":
                        item.GetComponent<MagicOrb>().Attack(player.transform.position, true);
                        break;
                    case "SlappyArm":
                        item.GetComponent<SlappyHand>().Attack(player.transform.position, true);
                        break;
                }
                
            }
            attackTimer = 0;
        }
        attackTimer += Time.deltaTime;
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackMode = true;
        }
    }

    

   

    
}
