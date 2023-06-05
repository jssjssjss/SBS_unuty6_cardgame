using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
   public Vector2 inputVec;
    public float my_speed = 10;


    float bullet_speed = 8.0f;
    float fire_delay = 0.2f;
    float cur_delay = 0;

    bool hit_leftbox = false;
    bool hit_rightbox = false;
    bool hit_topbox = false;
    bool hit_underbox = false;

    public GameObject bullet;


    public ObjectManager obj_manager;

    public float player_max_hp = 5;
    public float player_cur_hp;




    public float score = 0;


    public bool player_ed = false;

    

  

    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

        player_cur_hp = player_max_hp;
       
        


    }

    // Update is called once per frame
    void Update()
    {
        



        cur_delay = cur_delay + Time.deltaTime;
        //움직이는 키가져오기

        inputVec.x = Input.GetAxisRaw("Horizontal");
        if ((hit_leftbox && inputVec.x == -1) || (hit_rightbox && inputVec.x == 1))
        {
            inputVec.x = 0;
        }

        inputVec.y = Input.GetAxisRaw("Vertical");
      
        if ((hit_topbox && inputVec.y==1)|| (hit_underbox && inputVec.y == -1))
        {
            inputVec.y = 0;

        }

        Fire();



        //움직임  = GetAxixRaw 안미끄러지게 움직임 
        //Input.GetAxix
        //Input.GetAxixRaw
    }

    private void FixedUpdate()
    {

        //대각서은로의 속도가 다르기에쓰는 노멀라이지드
        inputVec=inputVec.normalized*my_speed*Time.fixedDeltaTime;
        my_rigid.MovePosition(my_rigid.position + inputVec);

    



    }


    void Fire()
    {



        if (cur_delay < fire_delay)
            return;


        GameObject bullet_info = obj_manager.SelectObj("PlayerBullet");
        bullet_info.transform.position = gameObject.transform.position;
        Rigidbody2D bullet_rigid = bullet_info.GetComponent<Rigidbody2D>();
        bullet_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);
  
        cur_delay = 0;



    }



  


    // 충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.transform.tag == "Boundary")
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


       if (collision.transform.tag == "Enemy")
        {
            Hit(1);
            collision.gameObject.SetActive(false);
            player_ed = true;

        }
        if (collision.transform.tag=="EnemyBullet")
        {
            Hit(1);
            collision.gameObject.SetActive(false);
            player_ed = true;

        }
    }
    void Hit(float dmg)
    {
        player_cur_hp = player_cur_hp - 1;
        if (player_cur_hp<=0)
        {
            gameObject.SetActive(false);

        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Boundary")
        {
            switch (collision.transform.name)
            {
                case "LeftBoundary":
                    hit_leftbox = false;
                    break;

                case "RightBoundary":
                    hit_rightbox = false;
                    break;

                case "TopBoundary":
                    hit_topbox = false;
                    break;

                case "UnderBoundary":
                    hit_underbox = false;
                    break;

            }
        }
    }



  







}
