using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer;
    float destroy_timer=7;

    int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer += Time.deltaTime;

        if(cur_timer> destroy_timer) 
        {

            Destroy(gameObject);
            cur_timer= 0;
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="PlayerBullet")
        {
            hp = hp - 1;
            Debug.Log("ÃÑ¾ËÀÌ ´ê¾Ò½À´Ï´Ù.");

            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                Destroy(gameObject);
                
            }
            
        }
    
        
    }


}
