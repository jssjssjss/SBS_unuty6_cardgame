using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
    SpriteRenderer my_SR;

    public List<GameObject> enemy_arr=new List<GameObject>();
    Rigidbody2D enemy_rigid;

    public Vector2 inputvec;
    public Vector2 next_vec;

    Animator my_animator;


    float my_speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_animator = GetComponent<Animator>();
        my_SR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        inputvec.x = Input.GetAxisRaw("Horizontal");
        inputvec.y = Input.GetAxisRaw("Vertical");

        next_vec = inputvec.normalized;

        


  
        
        if (enemy_arr.Count !=0)
        {

            for (int i = 0; i < enemy_arr.Count; i++)
            {
                Debug.DrawRay(transform.position, enemy_arr[i].transform.position-transform.position,Color.red);

            }

            Vector2 dir = enemy_arr[0].transform.position - transform.position;

            Mathf.Sqrt(dir.x*dir.x+dir.y*dir.y);

            Vector2.Distance(transform.position, enemy_arr[0].transform.position);
        }


        for (int i = 0; i < enemy_arr.Count; i++)
        {
           
            float test= Vector2.Distance(transform.position, enemy_arr[0].transform.position);
            float max = 0;
            float min = 0;

            if (max<test)
            {
                max= test;

            }

            min= test;

            if (min>test)
            {
                min = test;
                


            }



            Debug.Log("max"+max);
            Debug.Log("min"+min);

        }

        



    }



    private void FixedUpdate()
    {
        my_rigid.MovePosition(my_rigid.position+next_vec*4 * Time.fixedDeltaTime);

        my_animator.SetFloat("speed",next_vec.magnitude);

        if (next_vec.x <= 0)
        {
            my_SR.flipX = true;
        }

        else if(next_vec.x > 0)
        {
            my_SR.flipX = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("a¸Â´Ù");
        }
    }
}

