using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapons {

    // Use this for initialization

    public float range = 100;
    public GameObject hitEffect;
    public GameObject bulletTrail;
    

    public override void LaunchProjectile() //still runs whats in the 
    {
        base.LaunchProjectile();
        RaycastHit hit;

        

        GameObject trail = Instantiate(bulletTrail, bulletSpawn.position, Quaternion.identity);
        trail.transform.rotation = bulletSpawn.rotation;
        
        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, range) )
        {
            //also where damage script will go
            Instantiate(hitEffect, hit.point, Quaternion.identity);

            float distance = Vector3.Distance(bulletSpawn.position, hit.point);
            trail.transform.localScale = new Vector3(1, 1, distance);
            
            
            if (hit.rigidbody.gameObject.GetComponent<EnemyControl>())
            {
                GameObject enemy = hit.rigidbody.gameObject;
                enemy.GetComponent<EnemyControl>().EnemyDeath();
            }

        }
        else
        {
            trail.transform.localScale = new Vector3(1, 1, range);
        }
    }



}
