using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public List<GameObject> libsTypes;
    public List<GameObject> LibSlots;

    public GameObject player;
    
    protected bool attackMode = false;
    protected float attackRange;

    public float attackTimer;
    public float attackTime;

    public int maxLibCount;

    public float timer;
    public float checkTime;

    public List<Vector3> positionList;


    // Start is called before the first frame update
    void Start()
    {
        attackTime = 3;

        positionList = new List<Vector3>();
        for (int i = 0; i < maxLibCount; i++)
        {
            positionList.Add(LibSlots[i].transform.position);
        }
        for (int i = 0; i < maxLibCount; i++)
        {
            LibSlots[i] = Instantiate(libsTypes[Random.Range(0, libsTypes.Count)] , gameObject.transform);
            LibSlots[i].transform.position = positionList[i];
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        if (attackTimer > attackTime)
        {
            foreach (var item in LibSlots)
            {
                item.GetComponent<GunArm>().Attack(player.transform.position, true) ;
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
