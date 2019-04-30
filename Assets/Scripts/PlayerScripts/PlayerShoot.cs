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
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No Camera Referenced");
            this.enabled = false;
        }
        // Setup default weapon values
        weapon.UpdateWeapon();
    }

    void Update()
    {
        if (Input.GetButton("FireWeapon") && (Time.time > nextFire))
        {
            nextFire = Time.time + weapon.GetRateOfFire();
            if(weapon.GetID() == 2)
            {
                ShootShotgun();
            }
            else
            {
                Shoot();
            }
        }
        if (Input.GetButtonDown("Weapon1"))
        {
            weapon.SwitchWeapon(1);
        }
        else if (Input.GetButtonDown("Weapon2"))
        {
            weapon.SwitchWeapon(2);
        }
        else if (Input.GetButtonDown("Weapon3"))
        {
            weapon.SwitchWeapon(3);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 targetVector;
        if (weapon.GetAmmo() > 0)
        {
            weapon.UpdateAmmo(weapon.GetID(), -1);
            for (int i = 0; i < 7; ++i)
            {
                targetVector = new Vector3(0, .1f * (i - 3), 0);
                // Start of ray, direction, where to store info, distance, acceptable target types
                if (Physics.Raycast(cam.transform.position, cam.transform.forward + targetVector, out hit, weapon.GetRange(), mask))
                {
                    // We hit something
                    //Debug.DrawRay(cam.transform.position, (cam.transform.forward+targetVector) * weapon.getRange(), Color.red, 15f);
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.collider.SendMessage("takeDamage", weapon.GetDamage());
                        break;
                    }
                }
            }
        }
    }

    void ShootShotgun()
    {
        RaycastHit hit;
        Vector3 heightVector, widthVector;
        int hitFlag = 0;
        if (weapon.GetAmmo() > 0)
        {
            weapon.UpdateAmmo(weapon.GetID(), -1);
            for (int i = 0; i < 7; ++i)
            {
                heightVector = new Vector3(0, .1f * (i - 3), 0);
                for (int j = 0; j < 5; ++j)
                {
                    widthVector = new Vector3(.03f * (j - 2), 0, 0);
                    // Start of ray, direction, where to store info, distance, acceptable target types
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward + heightVector + widthVector, out hit, weapon.GetRange(), mask))
                    {
                        // We hit something
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.collider.SendMessage("takeDamage", weapon.GetDamage());
                            hitFlag = 1;
                        }
                    }
                }
                if (hitFlag == 1)
                {
                    break;
                }
            }
        }
    }

    public float DisplayAmmo()
    {
        return weapon.GetAmmo();
    }

    public void PickupAmmo()
    {
        int weaponID = Random.Range(1, 3);
        int ammo;
        switch (weaponID)
        {
            case 1: ammo = 50; break;
            case 2: ammo = 25; break;
            case 3: ammo = 100; break;
            default: ammo = 0; break;
        }
        // Generates a random weapon to add ammo for
        weapon.UpdateAmmo(weaponID, ammo);
    }
}
