using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BOss : MonoBehaviour
{


    int hp = 3;
    Rigidbody2D boss_rigid;

    List<Rigidbody2D> bossbullet_rigid = new List<Rigidbody2D>();

    public GameObject bossbullet;
    List<GameObject> bossbullet_copy = new List<GameObject>();

    float st_time = 0;
    float ed_time = .3f;


    float bossbulletspeed = 10;
    public GameObject playerobj;
    public Player playercs;

    // Start is called before the first frame update
    void Start()
    {
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

            if (hp <= 0)
            {
                Destroy(gameObject);

            }
        }
    }

    void BossPatter()
    {
        StartCoroutine(FireCross());
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
                    bullet_dir = new Vector2(1, 0);
                    break;
                case 1:
                    bullet_dir = new Vector2(-1, 0);

                    break;
                case 2:
                    bullet_dir = new Vector2(0, 1);

                    break;
                case 3:
                    bullet_dir = new Vector2(0, -1);

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
        for (int i = 8; i < 12; i++)
        {
            bossbullet_copy.Add(Instantiate(bossbullet, transform.position, transform.rotation));
            bossbullet_rigid.Add(bossbullet_copy[i].GetComponent<Rigidbody2D>());
            Vector2 tg = playerobj.transform.position - transform.position;
            tg = tg.normalized;
            bossbullet_rigid[i].AddForce(tg * 10, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(0.5f);

   

        bossbullet_rigid.Clear();
        bossbullet_copy.Clear();
        


        Invoke("BossPatter", 3);




    }
}
