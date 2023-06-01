using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    float st_time = 0;
    float ed_time = 3;
    float back_speed = 0.5f;



    Rigidbody2D back_rigid;


    // Start is called before the first frame update
    void Start()
    {
        back_rigid = GetComponent<Rigidbody2D>();



        
    }

    // Update is called once per frame
    void Update()
    {
        back_rigid.MovePosition(back_rigid.position + (Vector2.down * back_speed * Time.deltaTime));



    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Back")
        {
            transform.position = new Vector3(0,15,0);
            back_rigid.MovePosition(back_rigid.position + (Vector2.down * back_speed * Time.deltaTime));

        }
    }
}
