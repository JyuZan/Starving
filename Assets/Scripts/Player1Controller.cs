using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class Player1Controller : MonoBehaviour {

    public Animator animator;
	public float speed;
	public float jumpheight;

	private Rigidbody rb;
	private bool grounded;
    Vector3 movement;

    void Start ()
	{
		rb = GetComponent<Rigidbody>();
        

	}

	void Update()
	{
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        animator.SetFloat("Input X", moveHorizontal);
        animator.SetFloat("Input Y", moveVertical);
        if(moveHorizontal!=0 || moveVertical != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Running", true);
        }
        //Jump
        if (Input.GetKeyDown ("space") && grounded) 
		{
			Vector3 jump = new Vector3 (0.0f, jumpheight, 0.0f);
			rb.AddForce (jump);
			grounded = false;
		}

	}

	void FixedUpdate ()
	{
		

		

		
	}

	//check if ball is on the ground
	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

}


