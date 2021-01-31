using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleBody : Torso
{
    public LayerMask enemyLayers;
    Vector2 pos, tentaclePos;
    private bool onCooldown;
    public float cooldownTime;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        onCooldown = false;
        equipped = false;
        cooldown = cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (onCooldown && cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
            Debug.Log(cooldown);
            if (cooldown <= 0)
            {
                onCooldown = false;
                cooldown = cooldownTime;
            }
        }

        if (equipped &! onCooldown)
        {
            TentacleAura();
        }
    }

    void TentacleAura()
    {
        onCooldown = true;
        pos = this.transform.position;
        //decide on the spawn by choosing from a 360 radius
        Vector2 dir = Random.insideUnitCircle.normalized;

        Debug.DrawRay(pos, dir, Color.green);

        //position of the tentacle = player.pos + (dir * length)
        tentaclePos = pos + (dir * 2);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(tentaclePos, 1, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(tentaclePos, 1);//TentacleSlap hitbox
    }
}
