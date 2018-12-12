using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapons {

    
    public GameObject projectile;

    
    public override void LaunchProjectile() //still runs whats in the 
    {
        base.LaunchProjectile();

        GameObject spawnprojectile = Instantiate(projectile, bulletSpawn.transform.position, Quaternion.identity);
        spawnprojectile.transform.rotation = bulletSpawn.transform.rotation;
        spawnprojectile.GetComponent<Projectile>().GiveIntialVelocity();
       
    }

}
