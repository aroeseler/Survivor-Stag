using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Allows private variables to be seen in the Unity Engine
    //[SerializeField]
    public Camera cam;
    public LayerMask mask;
    public PlayerWeapon weapon;
    private float nextFire = 0.0f;

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
        if (Input.GetButton("FireWeapon") && (Time.time > nextFire))
        {
            nextFire = Time.time + weapon.getRateOfFire();
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
        RaycastHit hit;
        Vector3 targetVector;
        for (int i = 0; i < 7; ++i)
        {
            targetVector = new Vector3(0, .1f * (i-3), 0);
            // Start of ray, direction, where to store info, distance, acceptable target types
            if (Physics.Raycast(cam.transform.position, cam.transform.forward + targetVector, out hit, weapon.getRange(), mask))
            {
                Debug.DrawRay(transform.position, (cam.transform.forward + targetVector) * hit.distance, Color.red, 10f);
                // We hit something
                if (hit.transform.tag == "Enemy")
                {
                    Debug.Log("We hit " + hit.collider.name);
                    hit.collider.SendMessage("takeDamage", weapon.getDamage());
                    break;
                }
            }
        }
    }
}
