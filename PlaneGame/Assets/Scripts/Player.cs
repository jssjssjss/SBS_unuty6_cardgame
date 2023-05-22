using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
   public Vector2 inputVec;
    public float my_speed = 10;


    float bullet_speed = 6.0f;
    float fire_delay = 0.2f;
    float cur_delay = 0;

    bool hit_leftbox = false;
    bool hit_rightbox = false;
    bool hit_topbox = false;
    bool hit_underbox = false;

    public GameObject bullet;

    int hp = 3;
   

    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
        cur_delay = cur_delay + Time.deltaTime;
        //�����̴� Ű��������
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if ((hit_leftbox && inputVec.x == 1) || (hit_rightbox && inputVec.x == -1))
        {
            inputVec.x = 0;
        }

        inputVec.y = Input.GetAxisRaw("Vertical");

       

      
        if ((hit_topbox && inputVec.y==-1)|| (hit_underbox && inputVec.y == 1))
        {
            inputVec.y = 0;

        }

        Fire();



        //������  = GetAxixRaw �ȹ̲������� ������ 
        //Input.GetAxix
        //Input.GetAxixRaw
    }

    private void FixedUpdate()
    {

        //�밢�������� �ӵ��� �ٸ��⿡���� ��ֶ�������
        inputVec=inputVec.normalized*my_speed*Time.fixedDeltaTime;
        my_rigid.MovePosition(my_rigid.position + inputVec);

    



    }


    void Fire()
    {



        if (cur_delay < fire_delay)
            return;


             GameObject bullet_info = Instantiate(bullet, transform.position, transform.rotation);
             Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();
             bullet_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);
  
             cur_delay = 0;



    }




    // �浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="Boundary")
        {
            if (collision.transform.name == "LeftBoundary") 
            {
                hit_leftbox = true;
            }
            else if (collision.transform.name == "RightBoundary")
            {
                hit_rightbox = true;
            }

           else if (collision.transform.name == "TopBoundary")
            {
                hit_topbox = true;

            }
            else if (collision.transform.name == "UnderBoundary")
            {
                hit_underbox = true;

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Boundary")
        {
            if (collision.transform.name == "LeftBoundary")
            {
                hit_leftbox = false;
            }
            else if (collision.transform.name == "RightBoundary")
            {
                hit_rightbox = false;
            }

            else if (collision.transform.name == "TopBoundary")
            {
                hit_topbox = false;

            }
            else if (collision.transform.name == "UnderBoundary")
            {
                hit_underbox = false;

            }

        }
        else if(collision.transform.tag=="Astroid")
        {
            hp = hp - 1;

            Destroy(collision.gameObject);
            if (hp<=0)
            {
                Destroy(gameObject);   

            }
        }

    }
    



   



}
