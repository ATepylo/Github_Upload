using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour {

    private Transform target;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

   
    // Use this for initialization
    void Start () {

     target = target1;
}
	
	// Update is called once per frame
	void Update () {

        if(Vector3.Distance(transform.position, target1.position) <= 1)
        {
            target = target2;
        }
        else if (Vector3.Distance(transform.position, target2.position) <= 1)
        {
            target = target3;
        }
        else if (Vector3.Distance(transform.position, target3.position) <= 1)
        {
            target = target4;
        }
        else if (Vector3.Distance(transform.position, target4.position) <= 1)
        {
            target = target1;
        }

        GetComponent<NavMeshAgent>().SetDestination(target.position);
	}

    public void EnemyDeath()
    {
        Destroy(this.gameObject);
    }

    
}
