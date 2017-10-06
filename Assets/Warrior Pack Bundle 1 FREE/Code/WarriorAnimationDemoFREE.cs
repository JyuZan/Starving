using UnityEngine;
using System.Collections;

public class WarriorAnimationDemoFREE : MonoBehaviour 
{
	public Animator animator;

	float rotationSpeed = 30;

	Vector3 inputVec;
	Vector3 targetDirection;
	
	//Warrior types
	public enum Warrior{Karate, Ninja, Brute, Sorceress, Knight, Mage, Archer, TwoHanded, Swordsman, Spearman, Hammer, Crossbow};
    public string horizontal_input;
    public string vertical_input;
    public Warrior warrior;
    public float z;
    public float x;
    //private float speed = 1;
	
	void Update()
	{
		//Get input from controls
		z = Input.GetAxisRaw(horizontal_input);
		x = -(Input.GetAxisRaw(vertical_input));
		inputVec = new Vector3(x, 0.0f, z);

		//Apply inputs to animator
		animator.SetFloat("Input X", z);
		animator.SetFloat("Input Z", -(x));
        

		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			animator.SetBool("Moving", true);
			animator.SetBool("Running", true);
		}
		else
		{
			//character is not moving
			animator.SetBool("Moving", false);
			animator.SetBool("Running", false);
		}
		if (animator.GetInteger("HaveFood") > 0)
        {
            animator.speed = 0.8f;
        }
        else
        {
            animator.speed = 1.0f;
        }

        /*if (animator.GetBool("HaveBomb") == true)
        {
            animator.speed = 1.0f;
        }
        else
        {
            animator.speed = 0.8f;
        }*/

        UpdateMovement();  //update character position and facing
	}

	public IEnumerator COStunPause(float pauseTime)
	{
		yield return new WaitForSeconds(pauseTime);
	}

	//converts control input vectors into camera facing vectors
	void TargetDirectionUpdate()
	{  
		

		// Target direction update
		targetDirection = -(inputVec) ;
	}

	//face character along input direction
	void RotateTowardMovementDirection()  
	{
		if (inputVec != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotationSpeed);
		}
	}

	void UpdateMovement()
	{
		//get movement input from controls
		Vector3 motion = inputVec;

		//reduce input for diagonal movement
		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? 0.7f:1;

		RotateTowardMovementDirection();  
		TargetDirectionUpdate();  
	}

}