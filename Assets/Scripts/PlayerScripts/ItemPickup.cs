using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Collider body;
    public Collider player;

    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Collider>();
        }
    }

    void Update()
    {
        if (body.bounds.Intersects(player.bounds))
        {
            player.SendMessage("PickupAmmo", 50);
            Destroy(body.gameObject);
        }
    }
}
