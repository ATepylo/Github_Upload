using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRotation : MonoBehaviour {

    public Transform player;
    public float rotationVertical = 5;
    public float maxAngleUp = 45;
    public float maxAngleDown = -20;

    private float currentAngle = 0;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        rotate();
	}

    void rotate() // to chance which way char is facing, only rotate horizontal
    {
        float deltaRotation = Input.GetAxis("Mouse Y") * rotationVertical * Time.deltaTime; //math f to change to radians
        currentAngle += deltaRotation;
        currentAngle = Mathf.Clamp(currentAngle, maxAngleDown, maxAngleUp);

        float andleInRadians = currentAngle * Mathf.Deg2Rad;
        //Vector3 newLookAtPoint = transform.position + transform.forward + deltaRotation * transform.up;
        Vector3 newLookAtPoint = transform.position + Mathf.Cos(andleInRadians) * player.forward + Mathf.Sin(andleInRadians) * player.up;
        transform.LookAt(newLookAtPoint);
    }

}
