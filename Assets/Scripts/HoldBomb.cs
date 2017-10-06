using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBomb : MonoBehaviour
{
    public bool f_haveBomb = false;
    public bool s_haveBomb = false;
    private GameObject player1;
    private GameObject player2;
    private GameObject Base;
    private Animator anim1;
    private Animator anim2;
    private Vector3 speed;
    private bool touchbase = false;
    private Vector3 baseposition;
    private Vector3 foodposition;
    private bool touchFood = false;

    public GameObject particleBomb;
    public Rigidbody bomb;

    // Use this for initialization
    void Start()
    {
        bomb = GetComponent<Rigidbody>();
        player1 = GameObject.FindWithTag("player1");
        anim1 = player1.GetComponent<Animator>();
        player2 = GameObject.FindWithTag("player2");
        anim2 = player2.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (touchbase)
        {
            transform.position = baseposition;
        }
        else if (f_haveBomb)
        {
            transform.position = speed + player1.transform.position;
        }
        else if (s_haveBomb)
        {
            transform.position = speed + player2.transform.position;
        }
        else if (touchFood)
        {
            transform.position = foodposition;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
            anim1.SetBool("HaveBomb", true);
            f_haveBomb = true;
            s_haveBomb = false;
            speed.x = Mathf.Abs(player1.transform.position.x - transform.position.x);
            speed.y = Mathf.Abs(player1.transform.position.y - (transform.position.y));
            speed.z = Mathf.Abs(player1.transform.position.z - transform.position.z);

        }
        if (other.gameObject.CompareTag("player2"))
        {
            anim2.SetBool("HaveBomb", true);
            s_haveBomb = true;
            f_haveBomb = false;
            speed.x = Mathf.Abs(player2.transform.position.x - transform.position.x);
            speed.y = Mathf.Abs(player2.transform.position.y - (transform.position.y));
            speed.z = Mathf.Abs(player2.transform.position.z - transform.position.z);

        }

        if (other.gameObject.CompareTag("Base"))
        {
            if (f_haveBomb)
            {
                anim1.SetBool("HaveBomb", false);
            }
            else if (s_haveBomb)
            {
                anim2.SetBool("HaveBomb", false);
            }
            f_haveBomb = false;
            s_haveBomb = false;
            touchbase = true;            
            baseposition.x = other.gameObject.transform.position.x;
            baseposition.y = other.gameObject.transform.position.y;
            baseposition.z = other.gameObject.transform.position.z;
            Instantiate(particleBomb, baseposition, Quaternion.identity);
            Destroy(gameObject, 0.5f);
            //Instantiate (particleBomb,gameObject.transform.position, Quaternion.identity);

        }

        if (other.gameObject.CompareTag("Food"))
        {
            f_haveBomb = false;
            s_haveBomb = false;
            touchFood = true;
            float move = Random.Range(4.0f, 8.0f);
            float judge = Random.Range(0, 1.0f);
            if (judge < 0.25f)
            {
                foodposition.x = other.gameObject.transform.position.x + move;
                foodposition.y = other.gameObject.transform.position.y - 4.0f;
                foodposition.z = other.gameObject.transform.position.z + move;
            }
            else if (judge < 0.5f)
            {
                foodposition.x = other.gameObject.transform.position.x - move;
                foodposition.y = other.gameObject.transform.position.y - 4.0f;
                foodposition.z = other.gameObject.transform.position.z - move;
            }
            else if (judge < 0.75f)
            {
                foodposition.x = other.gameObject.transform.position.x + move;
                foodposition.y = other.gameObject.transform.position.y - 4.0f;
                foodposition.z = other.gameObject.transform.position.z - move;
            }
            else
            {
                foodposition.x = other.gameObject.transform.position.x - move;
                foodposition.y = other.gameObject.transform.position.y - 4.0f;
                foodposition.z = other.gameObject.transform.position.z + move;
            }

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player1"))
        {
            anim1.SetBool("HaveBomb", false);
        }
        if (other.gameObject.CompareTag("player2"))
        {
            anim2.SetBool("HaveBomb", false);
        }
    }
}

