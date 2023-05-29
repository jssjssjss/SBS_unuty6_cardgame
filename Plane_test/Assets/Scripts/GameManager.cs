using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    
    


    public GameObject boss_hpbar_obj;

    public GameObject bounobh;
    Bounceitem bouncs;
    

    public GameObject camobj;
    Movecamera camcs;

    float st_time = 0;
    float ed_time = 0.2f;

    public GameObject Enemy;
   public GameObject[] sp_pos;

    public GameObject enemy_obj;
    Enemy enemycs;

    public GameObject playerobj;
    Player playercs;

    
    BOss bosscs;

    public GameObject player_sp;
    GameObject player_info;

    public Text player_socore;
    public Text player_text;

    public GameObject boss_obj;
    public GameObject boss_sp;
    public GameObject boss_tg;

    Rigidbody2D boss_rigid;
    bool isboss_sp = true;

    float boss_speed = 10;

    float max_hp = 100;
    float cur_hp = 100;

    Slider boss_hp_slider;

    void Start()
    {
        boss_rigid=GetComponent<Rigidbody2D>();



        GameObject player = Instantiate(playerobj, player_sp.transform.position, player_sp.transform.rotation);


        playercs =player.GetComponent<Player>();
        enemycs=enemy_obj.GetComponent<Enemy>();


        bosscs = boss_obj.GetComponent<BOss>();
        bosscs.playerobj = player;
       

        playercs.score_text = player_text;
        playercs.score_num = player_socore;

       
        camcs=camobj.GetComponent<Movecamera>();
        camcs.target = player;


        bouncs = bounobh.GetComponent<Bounceitem>();
        boss_hp_slider=boss_hpbar_obj.GetComponent<Slider>();


        bosscs = boss_obj.GetComponent<BOss>();
       

       


    }

    // Update is called once per frame
    void Update()
    {


        

        st_time = st_time + Time.deltaTime;
        if (st_time > ed_time)
        {

            boss_hp_slider.value = 0;
            spenemy();
        }

     

      


      




        BossSP();





    }


    void BossSP()
    {
        if (playercs.score >= 0 && isboss_sp)
        {


            GameObject boss = Instantiate(boss_obj, boss_sp.transform.position, boss_sp.transform.rotation);

            

            isboss_sp = false;

            boss.transform.Rotate(Vector3.back * 180);



        }
    }


    void spenemy()
    {


        int random = Random.Range(0, 12);

        GameObject Enemy_copy = Instantiate(Enemy, sp_pos[random].transform.position, sp_pos[random].transform.rotation);
        Rigidbody2D enemy_rigid = Enemy.GetComponent<Rigidbody2D>();



        //enemycs에 있는 playerobj에 Player클래스에서 정보를 받아 게임매니저에 player cs에 저장한것을 enemycs에 저장
        //enemyobj에 있는 playerobj에 Player클래스에서 정보를 받아 게임매니저에 player obj에 저장한것을 enemyobj에 저장


        enemycs.playercs = playercs;


        enemy_rigid.AddForce(Vector2.down, ForceMode2D.Impulse);

        st_time = 0;

    }
}
