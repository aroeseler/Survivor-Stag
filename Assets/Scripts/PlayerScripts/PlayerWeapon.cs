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
    private float[] ammo = { 1010, 50 };


    public void updateWeapon()
    {
        // Switch is c's version of case statements
        // We need the break command at the end of the line to signal the end of the case code
        switch (weaponID)
        {
            case 1: name = "pistol"; damage = 25f; range = 200f; rateOfFire = .45f; break;
            case 2: name = "shotgun"; damage = 20f; range = 100f; rateOfFire = 1.15f; break;
            default: Debug.Log("Error: PlayerWeapon.cs: Undefined WeaponID"); break;
        }
        Debug.Log("Weapon is " + name);
    }

    public void switchWeapon(int number)
    {
        weaponID = number;
        updateWeapon();
    }

    public string getName()
    {
        return name;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getRange()
    {
        return range;
    }

    public float getRateOfFire()
    {
        return rateOfFire;
    }

    public float getAmmo()
    {
        return ammo[weaponID - 1];
    }

    public void updateAmmo(int ammount)
    {
        ammo[weaponID - 1] += ammount;
    }

    public int getID()
    {
        return weaponID;
    }
}

