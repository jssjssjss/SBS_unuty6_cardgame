using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;








public class Boss : MonoBehaviour
{


    Rigidbody2D boss_rigid;
    float boss_rotation = 10000;

    public ObjectManager obj_mamager_in_bosscs;

    float st_time=0;
    float ed_time = .7f;

    public GameObject baller;
    //º¸½º ÃÑ¾Ë
   

    // Start is called before the first frame update
    void Start()
    {



        boss_rigid = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {



       // transform.Rotate(Vector3.forward, boss_rotation * Time.deltaTime);


        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 4, 0), 0.5f * Time.deltaTime);

        st_time = st_time + Time.deltaTime;
        if (st_time>ed_time)
        {

            GameObject bossbullet = obj_mamager_in_bosscs.SelectObj("BossBullet");

            bossbullet.transform.position = baller.transform.position;
            Rigidbody2D bossbullet_rigid=bossbullet.GetComponent<Rigidbody2D>();

            bossbullet_rigid.AddForce(Vector2.down*2,ForceMode2D.Impulse);

            st_time = 0;

        }


    }

 
}


