using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Transform body;
    public float pickupRadius;

    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Transform>();
        }
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(body.position, pickupRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "Player")
            {
                nearbyObject.SendMessage("PickupAmmo");
                Destroy(body.gameObject);
            }
        }
    }
}
