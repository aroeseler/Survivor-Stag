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
        weapon.updateWeapon();
    }

    void Update()
    {
        if (Input.GetButton("FireWeapon") && (Time.time > nextFire))
        {
            nextFire = Time.time + weapon.getRateOfFire();
            if(weapon.getID() == 2)
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
        if (weapon.getAmmo() > 0)
        {
            weapon.updateAmmo(-1);
            for (int i = 0; i < 7; ++i)
            {
                targetVector = new Vector3(0, .1f * (i - 3), 0);
                // Start of ray, direction, where to store info, distance, acceptable target types
                if (Physics.Raycast(cam.transform.position, cam.transform.forward + targetVector, out hit, weapon.getRange(), mask))
                {
                    // We hit something
                    //Debug.DrawRay(cam.transform.position, (cam.transform.forward+targetVector) * weapon.getRange(), Color.red, 15f);
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.collider.SendMessage("takeDamage", weapon.getDamage());
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
        if (weapon.getAmmo() > 0)
        {
            weapon.updateAmmo(-1);
            for (int i = 0; i < 7; ++i)
            {
                heightVector = new Vector3(0, .1f * (i - 3), 0);
                for (int j = 0; j < 5; ++j)
                {
                    widthVector = new Vector3(.03f * (j - 2), 0, 0);
                    // Start of ray, direction, where to store info, distance, acceptable target types
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward + heightVector + widthVector, out hit, weapon.getRange(), mask))
                    {
                        // We hit something
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.collider.SendMessage("takeDamage", weapon.getDamage());
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

    public float displayAmmo()
    {
        return weapon.getAmmo();
    }
}
