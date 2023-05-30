using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOss : MonoBehaviour
{

    public GameObject[] barrels;



    int patten_select = -1;

   public float max_boss_hp =50;
    public float cur_boss_hp;
    Rigidbody2D boss_rigid;

    List<Rigidbody2D> bossbullet_rigid = new List<Rigidbody2D>();

    public GameObject bossbullet;
    List<GameObject> bossbullet_copy = new List<GameObject>();

    float st_time = 0;
    float ed_time = .3f;


    float bossbulletspeed = 10;
    public GameObject playerobj;
    public Player playercs;

   public bool isbossDead = false;
    // Start is called before the first frame update
    void Start()
    {
        cur_boss_hp = max_boss_hp;
        Invoke("BossPatter", 3);

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 5.2f, 0), 2 * Time.deltaTime);







    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {


            cur_boss_hp = cur_boss_hp-1;
            Debug.Log(cur_boss_hp);
            if (cur_boss_hp<=0)
            {
                isbossDead = true;
                Destroy(gameObject);
                
            }

           
        }
    }

    void BossPatter()
    {
        
        patten_select += 1;
        if (patten_select>=4)
        {
            patten_select = 0;
        
        }


        switch(patten_select)
        {
            case 0:
                StartCoroutine(FireCross());
                break;
            case 1:
                StartCoroutine(FireX());
                break;
            case 2:
                StartCoroutine(FireCircle());
                break;
            case 3:
                StartCoroutine(FireSin());
                break;


        }




    }

    IEnumerator FireCross()
    {




        for (int i = 0; i < 4; i++)
        {
            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());
            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid[i].AddForce(tg * 10, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);

             int index = 0;
        Vector2 bullet_dir=new Vector2(1, 0);

        for (int i = 0; i < 4; i++)
        {
           switch(index)
            {
                case 0:
                    bullet_dir = new Vector2(1, 1);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, -1);

                    break;
                case 2:
                    bullet_dir = new Vector2(-1, 1);

                    break;
                case 3:
                    bullet_dir = new Vector2(1, -1);

                    break;  
            }

            bossbullet_rigid[i].velocity = Vector2.zero;
            bossbullet_rigid[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);
            index++;

        }

        for (int i = 4; i < 8; i++)
        {
            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());
            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid[i].AddForce(tg * 10, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        index = 0;

        for (int i = 4; i < 8; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(1, 1);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, -1);

                    break;
                case 2:
                    bullet_dir = new Vector2(-1, 1);

                    break;
                case 3:
                    bullet_dir = new Vector2(1, -1);

                    break;
            }

            bossbullet_rigid[i].velocity = Vector2.zero;
            bossbullet_rigid[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);
            index++;

        }
        
        for (int i = 8; i < 12; i++)
        {
            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());
            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid[i].AddForce(tg * 10, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);
        index = 0;
        for (int i = 8; i < 12; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(1, 1);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, -1);

                    break;
                case 2:
                    bullet_dir = new Vector2(-1, 1);

                    break;
                case 3:
                    bullet_dir = new Vector2(1, -1);

                    break;
            }

            bossbullet_rigid[i].velocity = Vector2.zero;
            bossbullet_rigid[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);
            index++;

        }


        bossbullet_rigid.Clear();
        bossbullet_copy.Clear();



        Invoke("BossPatter", 3);
        yield return null;





    }

    IEnumerator FireX()
    {
        for (int i = 0; i < 4; i++)
        {
            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());
            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid[i].AddForce(tg * 10, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);

        int index = 0;
        Vector2 bullet_dir = new Vector2(1, 0);

        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(1, 1);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, -1);

                    break;
                case 2:
                    bullet_dir = new Vector2(-1, 1);

                    break;
                case 3:
                    bullet_dir = new Vector2(1, -1);

                    break;
            }

            bossbullet_rigid[i].velocity = Vector2.zero;
            bossbullet_rigid[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);
            index++;

        }




        bossbullet_rigid.Clear();
        bossbullet_copy.Clear();



        Invoke("BossPatter", 3);
        yield return null;
     
    }

    IEnumerator FireCircle()
    {
        for (int i = 0; i < 30; i++)
        {

            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());

            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            
            bossbullet_rigid[i].AddForce(tg * 5, ForceMode2D.Impulse);
     
        }


        yield return new WaitForSeconds(1f);


        for (int i = 0; i < 30; i++)
        {
            Vector2 tg = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / 30), Mathf.Sin(Mathf.PI * 2 * i / 30));
            bossbullet_rigid[i].velocity = Vector2.zero;
            bossbullet_rigid[i].AddForce(tg.normalized * 10, ForceMode2D.Impulse);
        }


        bossbullet_rigid.Clear();
        bossbullet_copy.Clear();



        Invoke("BossPatter", 3);
        yield return null;
    }

    IEnumerator FireSin()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject bullet1_info = Instantiate(bossbullet, barrels[0].transform.position, barrels[0].transform.rotation);
            GameObject bullet2_info = Instantiate(bossbullet, barrels[1].transform.position, barrels[1].transform.rotation);

         Rigidbody2D bullet_rigid1 = bullet1_info.GetComponent<Rigidbody2D>();
         Rigidbody2D bullet_rigid2= bullet2_info.GetComponent<Rigidbody2D>();

            Vector2 bullet_dir1 = new Vector2(Mathf.Sin(Mathf.PI*3 *i/30), -1);
            Vector2 bullet_dir2= new Vector2(Mathf.Sin(Mathf.PI *3*i/30), -1);

            bullet_rigid1.AddForce(bullet_dir1.normalized * 5, ForceMode2D.Impulse);
            bullet_rigid2.AddForce(bullet_dir2.normalized * 5, ForceMode2D.Impulse);


            yield return new WaitForSeconds(0.3f);
           

        }


        bossbullet_rigid.Clear();
        bossbullet_copy.Clear();



        Invoke("BossPatter", 3);
        yield return null;
    }


}
