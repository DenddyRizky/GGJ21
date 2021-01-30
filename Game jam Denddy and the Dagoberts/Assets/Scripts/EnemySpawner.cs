using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public float SpawnTime;
    public GameObject Enemy1;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        SpawnTime = 3;
        Instantiate(Enemy1, new Vector3(0, 0, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > SpawnTime)
        //{
        //    timer = 0;
        //}
    }
}
