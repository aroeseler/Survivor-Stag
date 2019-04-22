using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;
    private Collider body;

    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Collider>();
        }
        // Basic enemy type - identifier (Clone) added by Unity when spawned
        if (body.name.ToString() == "Enemy(Clone)")
        {
            health = 100;
        }
        else
        {
            Debug.Log("Error: EnemyHealth - Invalid body.name");
            health = 100;
        }
    }

    void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log(body.name + "'s health is " + health);

        if (health <= 0)
        {
            destroySelf();
        }
    }

    void destroySelf()
    {
        Debug.Log(body.name + " is destroyed");
        Destroy(body.gameObject);
    }

}


