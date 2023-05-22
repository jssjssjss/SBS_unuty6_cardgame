using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{


    Rigidbody2D back_rigid;
    float back_speed = 10;

    float st_time = 0;
    float ed_time = 5;
  
   
    void Start()
    {
        back_rigid = GetComponent<Rigidbody2D>();

      
    }

    
    void Update()
    {

        back_rigid.MovePosition(back_rigid.position + (Vector2.down * back_speed * Time.deltaTime));


      
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="xyz")
        {
            transform.position = new Vector3(0, 30, 0);
            back_rigid.MovePosition(back_rigid.position + (Vector2.down * back_speed * Time.deltaTime));

        }
    }

}
