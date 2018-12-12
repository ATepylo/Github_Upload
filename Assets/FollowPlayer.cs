using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    public Transform target;
    public float lerpSpeed = 10;
    public float offSetX = 5;
    public float offSetY = 5;
    public float offSetZ = -5;
    private float zAxis;

   

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = target.position;
        newPosition += offSetX * target.right;
        newPosition += offSetY * target.up;
        newPosition += offSetZ * target.forward;

        transform.position = Vector3.Lerp(transform.position, newPosition, lerpSpeed * Time.deltaTime);

        //transform.position = target.position - offSetZ * target.forward;
        //new Vector3 cameraPosition = transform.position.z - offSet * target.transform.position.z; how i tried, did not work
        
        transform.LookAt(target);

    }

    
}

