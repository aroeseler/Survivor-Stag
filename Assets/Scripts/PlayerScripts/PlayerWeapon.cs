using UnityEngine;

// Lets Unity know how to load and use this class
[System.Serializable]
public class PlayerWeapon 
{
    int weaponID = 1;

    private string name;

    private float damage;
    private float range;


    public void updateWeapon()
    {
        // Switch is c's version of case statements
        // We need the break command at the end of the line to signal the end of the case code
        switch (weaponID) {
            case 1: name = "pistol"; damage = 10f; range = 200f; break;
            case 2: name = "shotgun"; damage = 50f; range = 100f; break;
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
}
