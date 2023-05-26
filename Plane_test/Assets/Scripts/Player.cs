using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;
    float my_speed = 10;
    Vector2 inputVec;
    public GameObject bullet;
    float st_time = 0;
    float ed_time = 0.2f;
    float bullet_speed = 5;
    public float score;
    public Text score_text;
    public Text score_num;

    Enemy enemy;

    
   

   
    int hp = 3;



    void Start()
    {
        
        my_rigid = GetComponent<Rigidbody2D>();
        score_text.text = "SCORE";
        score_num.text = score.ToString();
        

    }

    // Update is called once per frame
    void Update()
    {

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");




        st_time = st_time+Time.deltaTime;
        if (st_time > ed_time)
        {
           
            
            GameObject bullet_copy = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D bullet_rigid = bullet_copy.GetComponent<Rigidbody2D>();
            bullet_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);

            st_time = 0;
        }

        score_num.text = score.ToString();




    }



    private void FixedUpdate()
    {

        inputVec = inputVec.normalized * my_speed * Time.fixedDeltaTime;


        transform.position = my_rigid.position + inputVec;


        float clampX = Mathf.Clamp(transform.position.x, -7, 7);
        float clampY = Mathf.Clamp(transform.position.y, -7, 7);

        transform.position=new Vector2 (clampX, clampY);    


        

    }

    




    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag=="item")
        {
            Destroy(collision.gameObject);
        }
       
        
    }

    


   

}
