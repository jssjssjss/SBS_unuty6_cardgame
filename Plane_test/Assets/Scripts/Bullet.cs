using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float ed_time = 3;
    float st_time = 0;
    int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        st_time+=Time.deltaTime;

        if (st_time > ed_time)
        {
            Destroy(gameObject);
            st_time=0;
        }
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Enemy")
        {
            hp = hp - 1;
                if (hp==0)
            {
                Destroy (gameObject);


            }


        }
        
    }
}