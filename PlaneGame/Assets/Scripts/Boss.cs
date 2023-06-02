using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;








public class Boss : MonoBehaviour
{


    Rigidbody2D boss_rigid;
    float boss_rotation = 10000;

    public ObjectManager obj_mamager_in_bosscs;
    public GameObject baller;
    public GameObject player;


    List<Rigidbody2D> rigid_arr = new List<Rigidbody2D>();
    List<GameObject> bullet_arr =new List<GameObject> ();
    


    float st_time =0;
    float ed_time = .7f;
    int patten_select = -1;


   public float boss_hp_max = 100;
    public float boss_hp_cur;
   

    //º¸½º ÃÑ¾Ë
   

    // Start is called before the first frame update
    void Start()
    {

        boss_hp_cur = boss_hp_max;


        boss_rigid = GetComponent<Rigidbody2D>();
        Invoke("Patten", 3);


    }

    // Update is called once per frame
    void Update()
    {



        // transform.Rotate(Vector3.forward, boss_rotation * Time.deltaTime);


        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 4, 0), 0.5f * Time.deltaTime);


    }


    void Patten()
    {
        patten_select = patten_select+ 1;
        if (patten_select>=2)
        {
            patten_select = 0;

        }


        switch (patten_select)
        {
            case 0:
                StartCoroutine(FireX());
                break;

            case 1:
                StartCoroutine(FireCircle());
                break;
        }

    }


    


    IEnumerator FireX()
    {


        for (int i = 0; i < 4; i++)
        {
            bullet_arr.Add(obj_mamager_in_bosscs.SelectObj("BossBullet"));
            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());
            bullet_arr[i].transform.position = baller.transform.position;


            Vector2 bossbullet_dir = player.transform.position - baller.transform.position;
            bossbullet_dir = bossbullet_dir.normalized;

            rigid_arr[i].AddForce(bossbullet_dir * 4, ForceMode2D.Impulse);


        }

        yield return new WaitForSeconds(0.5f);

        int index = 0;
        Vector2 bullet_dir = new Vector2(0, 0);


        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(1, 1);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, 1);
                    break;
                case 2:
                    bullet_dir = new Vector2(1, -1);
                    break;
                case 3:
                    bullet_dir = new Vector2(-1, -1);
                    break;

            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir * 3, ForceMode2D.Impulse);

            index++;
        }


        rigid_arr.Clear();
        bullet_arr.Clear();

        Invoke("Patten", 1);



    }

    IEnumerator FireCircle()
    {

        for (int i = 0; i < 30; i++)
        {
            bullet_arr.Add(obj_mamager_in_bosscs.SelectObj("BossBullet"));
            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());
            bullet_arr[i].transform.position = baller.transform.position;

            Vector2 bossbullet_dir = player.transform.position - baller.transform.position;
            bossbullet_dir = bossbullet_dir.normalized;

            rigid_arr[i].AddForce(bossbullet_dir*5,ForceMode2D.Impulse);

        }

     

       

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 30; i++)
        {
            Vector2 bullet_dir=new Vector2(Mathf.Cos(Mathf.PI*2*i/30),Mathf.Sin(Mathf.PI*2*i/30));
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);

        }

        bullet_arr.Clear();
        rigid_arr.Clear();

        Invoke("Patten", 1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag=="PlayerBullet")
        {
            boss_hp_cur = boss_hp_cur - 1;

            if (boss_hp_cur==0)
            {
                Destroy(gameObject);

            }


        }
    }



}


