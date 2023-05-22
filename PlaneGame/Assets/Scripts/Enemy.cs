using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer;
    float destroy_timer=7;
    int hp = 3;
    int as_hp = 1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cur_timer =cur_timer +Time.deltaTime;

        if (cur_timer>destroy_timer)
        {

            Destroy(gameObject);
            cur_timer = 0;

        }
        
    }

   


    // �浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="PlayerBullet")
        {

            hp = hp - 1;
            Debug.Log("�Ѿ��� �����߽��ϴ�");
            Destroy(collision.gameObject);
           

            if(hp<=0)
            {
                Destroy(gameObject);
            }

        }

        if (collision.transform.tag=="Astroid")
        {
          as_hp=  as_hp - 1;
            Destroy(collision.gameObject);
            if (as_hp<=0)
            {
                Destroy(gameObject);

            }

        }




        
    }

   



}
