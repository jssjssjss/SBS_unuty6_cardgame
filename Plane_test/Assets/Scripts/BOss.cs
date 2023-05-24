using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOss : MonoBehaviour
{


    int hp = 3;
    Rigidbody2D boss_rigid;

    public GameObject bossbullet;


    float st_time = 0;
    float ed_time = 
        .3f;
    float bossbulletspeed = 10;
    public GameObject playerobj;
    public Player playercs;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 5.2f, 0), 2 * Time.deltaTime);



        st_time  =  st_time  + Time.deltaTime;
        //st_time += Time.deltaTime;


        if (st_time>ed_time)
        {
            GameObject bossbullet_copy = Instantiate(bossbullet, transform.position, transform.rotation);
            Rigidbody2D bossbullet_rigid = bossbullet_copy.GetComponent<Rigidbody2D>();
            Debug.Log("¾È³çÇÏ¼Ä´¢");

            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid.AddForce(tg * 10 ,ForceMode2D.Impulse);

            st_time = 0;

        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            
            if (hp<=0)
            {
                Destroy(gameObject);

            }
        }
    }
}
