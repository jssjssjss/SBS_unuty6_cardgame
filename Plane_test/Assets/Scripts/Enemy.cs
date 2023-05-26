using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    float st_time = 0;
    float ed_time = 2;
    int hp = 3;

    public GameObject playerobj;
    public Player playercs;

    public GameObject item;
    public Bounceitem bouncecs;

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

        if (collision.gameObject.tag=="Bullet")
        {
            hp = hp-1;

           

            if (hp<=0)
            {

                int rad = Random.Range(0, 10);
                if (rad>5)
                {
                    Instantiate(item, collision.transform.position, collision.transform.rotation);
  

                }
                Destroy(gameObject);
                playercs.score = playercs.score + 100;
                //Debug.Log(playercs.score);
            }


        }
        
    }
}

