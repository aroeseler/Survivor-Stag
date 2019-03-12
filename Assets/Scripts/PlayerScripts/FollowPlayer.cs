using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Rigidbody player;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // Follow the player's movement
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}
