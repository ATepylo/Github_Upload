using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float initialSpeedForward;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.gameObject);

        if (collision.rigidbody.gameObject.GetComponent<EnemyControl>()) //check to see if the unit hit has the enemy control script 
        {
            GameObject enemy = collision.rigidbody.gameObject;
            enemy.GetComponent<EnemyControl>().EnemyDeath();

        }
    }

    public void GiveIntialVelocity()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * initialSpeedForward, ForceMode.Impulse); //sets direction on spawn
    }

}
