using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
	public float jumpingForce;
	public float groundDist;
    public float counter;

	// Use this for initialization
	void Start () {

		groundDist = this.transform.GetComponent<Collider>().bounds.extents.y;

		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
		
	}

    void Movement()
    {
        //move left to right
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        //move front to back
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

		if(Input.GetKey(KeyCode.Space) && CheckGrounded () == true )
		{
			//   Debug.Log("jump");
			this.transform.GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
		}

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * counter;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed / counter;
        }
    }

	public bool CheckGrounded()
	{
		return Physics.Raycast(this.transform.position, -Vector3.up, groundDist + 0.1f);
	}

}
