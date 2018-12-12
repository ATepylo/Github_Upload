using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {


    public float forwardSpeed = 5;
    public float sideSpeed = 3;
    public float jumpForce = 10;
    public float rotationSpeed = 10;
    public RaycastWeapon castWeapon;
    public ProjectileWeapon projWeapon;

    private Rigidbody rb;

    private bool isGrounded = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        jump();
        rotate();
        Shoot();
	}

    private void FixedUpdate()
    {
        Move();
        
    }


    void Move()
    {

        //if (Input.GetKey(KeyCode.UpArrow)) //move forwards
        //{
        //    transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow)) //move backward
        //{
        //    transform.position += Vector3.back * sideSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.LeftArrow)) //move left
        //{
        //    transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow)) //move left
        //{
        //    transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        //}

        //how was done in class
        Vector3 horizontal = Input.GetAxis("Horizontal") * sideSpeed * transform.right * Time.fixedDeltaTime;
        Vector3 forwards = Input.GetAxis("Vertical") * forwardSpeed * transform.forward * Time.fixedDeltaTime;

        //transform.position += horizontal + forwards;

        rb.AddForce(horizontal + forwards);

    }

    
    

    void jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            //GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    void rotate() // to chance which way char is facing, only rotate horizontal
    {
        float deltaRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        Vector3 newLookAtPoint = transform.position + transform.forward + deltaRotation * transform.right;
        transform.LookAt(newLookAtPoint);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) //sets on collion with ground only
        {
            isGrounded = true;
            //jumpCount = 0;
            //anim.SetBool("Jump", false);
        }
    }

    private void Shoot()
    {
        castWeapon.shoot(Input.GetButton("Fire1"));
        projWeapon.shoot(Input.GetButton("Fire2"));
    }
}
