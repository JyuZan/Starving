using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldFood : MonoBehaviour {
	public bool f_haveFood = false;
	public bool s_haveFood = false;
	public Material material2;
	public Material material1;
	public Material material0;
	private MeshRenderer my_renderer;
	private GameObject player1;
	private GameObject player2;
	private GameObject Base;
	private Animator anim1;
	private Animator anim2;
	private Vector3 speed;
	private bool touchbase = false;
	private Vector3 baseposition;



	public Rigidbody food;

	// Use this for initialization
	void Start () {
		food = GetComponent <Rigidbody>();
		my_renderer = GetComponent<MeshRenderer>();
		my_renderer.enabled = true;
        player1 = GameObject.FindWithTag("player1");
        anim1 = player1.GetComponent<Animator>();
        player2 = GameObject.FindWithTag("player2");
        anim2 = player2.GetComponent<Animator>();
    }

	

	void OnTriggerEnter(Collider other) 
	{    
		if (other.gameObject.CompareTag ("player1")) 
		{
			
            f_haveFood = true;
			s_haveFood = false;
			speed.x = Mathf.Abs(player1.transform.position.x-transform.position.x)/2;
			speed.y = Mathf.Abs(player1.transform.position.y-(transform.position.y));
			speed.z = Mathf.Abs(player1.transform.position.z-transform.position.z)/2;
			anim1.SetInteger ("HaveFood", anim1.GetInteger("HaveFood") + 1);
			//anim2.SetBool("HaveFood", false);
            if (my_renderer != null ){
				my_renderer.sharedMaterial = material1;
			}
		}
		if (other.gameObject.CompareTag ("player2")) 
		{
			
            s_haveFood = true;
			f_haveFood = false;
			//anim1.SetBool("HaveFood", false);
			speed.x = Mathf.Abs(player2.transform.position.x-transform.position.x)/2;
			speed.y = Mathf.Abs(player2.transform.position.y-(transform.position.y));
			speed.z = Mathf.Abs(player2.transform.position.z-transform.position.z)/2;
			anim2.SetInteger ("HaveFood", anim2.GetInteger("HaveFood") + 1);
            if (my_renderer != null ){
				my_renderer.material = material2;
			}
		}

		if (other.gameObject.CompareTag ("Base")) 
		{
            if (f_haveFood)
            {
				anim1.SetInteger ("HaveFood", anim1.GetInteger("HaveFood") - 1);

            }

			else if (s_haveFood)
            {
				anim2.SetInteger ("HaveFood", anim2.GetInteger("HaveFood") - 1);
		//		anim2.SetInteger ("HaveFood", 0);
            }
            f_haveFood = false;
			s_haveFood = false;
			touchbase = true;
            baseposition.x = Random.Range (other.gameObject.transform.position.x - 4.0f,other.gameObject.transform.position.x + 4.0f);
			baseposition.y = other.gameObject.transform.position.y + 4.0f;
			baseposition.z = Random.Range (other.gameObject.transform.position.z - 4.0f ,other.gameObject.transform.position.z + 4.0f);
		}

		if (other.gameObject.CompareTag ("Bomb")) 
		{
			f_haveFood = false;
			s_haveFood = false;
			//anim1.SetBool("HaveFood", false);
			//anim2.SetBool("HaveFood", false);
			if(my_renderer != null ){
				my_renderer.material = material0;
			}
		}
		if (other.gameObject.CompareTag ("Box")) 
		{
			f_haveFood = false;
			s_haveFood = false;
			//anim1.SetBool("HaveFood", false);
			//anim2.SetBool("HaveFood", false);
			if(my_renderer != null ){
				my_renderer.material = material0;
			}
		}
			
	}
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
			anim1.SetInteger ("HaveFood", anim1.GetInteger("HaveFood") - 1);
			//Debug.Log ("-1 player1");
        }

		if (other.gameObject.CompareTag ("player2")) 
		{
			anim2.SetInteger ("HaveFood", anim2.GetInteger ("HaveFood") - 1);
			//Debug.Log ("-1 player2");
		}
    }

        // Update is called once per frame
        void Update(){
        if (touchbase)
        {
            transform.position = baseposition;
        }
        else if (f_haveFood)
            {
                transform.position = speed +player1.transform.position;
                
            }
        /*else if (!f_haveFood)
            {
            anim1.SetBool("HaveFood", false);
            }*/

        else if (s_haveFood)
            {
                
                transform.position = speed + player2.transform.position;
            }
        /*else if (!s_haveFood)
            {
            anim2.SetBool("HaveFood", false);
        }*/
        

    }

}
	

