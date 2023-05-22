using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    float st_time = 0;
    float ed_time = 2;
    int hp = 3;

    int score = 0;



  
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {




        st_time += Time.deltaTime;
        if (st_time>ed_time)
        {
            Destroy(gameObject);
            st_time = 0;

        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag=="Bullet")
        {
            hp = hp-1;
            if (hp<=0)
            {
                Destroy (gameObject);
                score += 100;
            }


        }
        
    }
}

