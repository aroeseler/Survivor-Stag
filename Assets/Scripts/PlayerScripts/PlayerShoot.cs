using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Allows private variables to be seen in the Unity Engine
    //[SerializeField]
    public Camera cam;
    public LayerMask mask;
    public PlayerWeapon weapon;

    void Start()
    {
         
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No Camera Referenced");
            this.enabled = false;
        }
        // Setup default weapon values
        weapon.updateWeapon();
    }

    void Update()
    {
        if (Input.GetButtonDown("FireWeapon"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Weapon1"))
        {
            weapon.switchWeapon(1);
        }
        else if (Input.GetButtonDown("Weapon2"))
        {
            weapon.switchWeapon(2);
        }
    }

    void Shoot()
    {
        // Test for target penetration
        /*RaycastHit[] hit = Physics.RaycastAll(cam.transform.position, cam.transform.forward, weapon.range);

        for (int i = 0; i < hit.Length; ++i)
        {
            Debug.Log("We hit " + hit[i].collider.name);
            if (hit[i].collider.tag == "Wall")
            {
                h
            }
        }*/
        // Sends out a ray and stores information about the object hit
        RaycastHit hit;
        // Start of ray, direction, where to store info, distance, acceptable target types
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.getRange(), mask))
        {
            // We hit something
            Debug.Log("We hit " + hit.collider.name);
            hit.collider.SendMessage("takeDamage", weapon.getDamage());
        }

    }

}
