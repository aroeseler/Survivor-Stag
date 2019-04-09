using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 100;
    private Collider body;

    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Collider>();
        }
    }

    void takeDamage(int damage)
    {
        Debug.Log(body.name + " was hit");
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


