using UnityEngine;

// Lets Unity know how to load and use this class
[System.Serializable]
public class PlayerWeapon
{
    int weaponID = 1;

    private string name;

    private float damage;
    private float range;
    private float rateOfFire;
    // Default starting ammo amounts
    private float[] ammo = { 200, 50, 1000};


    public void UpdateWeapon()
    {
        // Switch is c's version of case statements
        // We need the break command at the end of the line to signal the end of the case code
        switch (weaponID)
        {
            case 1: name = "pistol"; damage = 25f; range = 200f; rateOfFire = .35f; break;
            case 2: name = "shotgun"; damage = 20f; range = 100f; rateOfFire = 1f; break;
            case 3: name = "smg"; damage = 10f; range = 200; rateOfFire = .05f; break;
            default: Debug.Log("Error: PlayerWeapon.cs: Undefined WeaponID"); break;
        }
        Debug.Log("Weapon is " + name);
    }

    public void SwitchWeapon(int number)
    {
        weaponID = number;
        UpdateWeapon();
    }

    public string GetName()
    {
        return name;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetRange()
    {
        return range;
    }

    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public float GetAmmo()
    {
        return ammo[weaponID - 1];
    }

    public void UpdateAmmo(int ID, int ammount)
    {
        ammo[ID - 1] += ammount;
    }

    public int GetID()
    {
        return weaponID;
    }
}

