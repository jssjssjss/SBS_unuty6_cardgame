using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer;
    float destroy_timer=7;
    public int hp = 10;
    int as_hp = 1;
    public ObjectManager objectManager;

    public Player playercs;

    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cur_timer =cur_timer +Time.deltaTime;

        if (cur_timer>destroy_timer)
        {

            gameObject.SetActive(false);
            cur_timer = 0;

        }
        
    }

   


    // 충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="PlayerBullet")
        {
            hp = hp - 1;
            Debug.Log("총알이 명중했습니다");
            GameObject particle = objectManager.SelectObj("ParticleEffect");
            particle.transform.position = collision.transform.position;

            collision.gameObject.SetActive(false);
           

            if(hp<=0)
            {
                cur_timer = 0;
                playercs.score = playercs.score + 100;
                gameObject.SetActive(false);
            }

        }

      

        
    }

   



}
