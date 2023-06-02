using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player_spawn_pos;
    public GameObject astroid;
    float sp_speed;

    public GameObject[] spawn_pos;
    float cur_timer = 0;
    float spawn_delay = 1.5f;


    //���ʹ� 
     GameObject astroid_info;
    Rigidbody2D[] astroid_rigid;

    


    Enemy enemycs;
    Player playercs;
    Boss bosscs;


    //�÷��̾�
    public ObjectManager obj_manager_in_gm;
    public GameObject playerobj;
    GameObject player_info;


    //������hp
    Slider boss_hp_slider;
    public GameObject boss_hp_obj;



    //���� ��ȯ
    public GameObject boss_spawn_pos;
    public GameObject bossobj;


    GameObject boss_info;

    bool isbosssp=true;
    bool isbossInst = false;

    float cur_hp=10;
    




    private void Awake()
    {

        player_info=Instantiate(playerobj, player_spawn_pos.transform.position, player_spawn_pos.transform.rotation);
        playercs = player_info.GetComponent<Player>();




        //���⿡ �ִ� obj_manager�� playercs.obj_manager�� �ִ´�.
        playercs.obj_manager= obj_manager_in_gm;


    }

    void Start()
    {


        boss_hp_slider = boss_hp_obj.GetComponent<Slider>();
        
        

        
        
     


    }

    // Update is called once per frame
    void Update()
    {


        

     
        
        



        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer +=Time.deltaTime; // ������


        if ((cur_timer>spawn_delay)&&isbosssp)
        {
            SpawnBoss();
            cur_timer=0;


        }



        if (cur_timer > spawn_delay)
        {
            SpawnEnemy();
            cur_timer = 0;
        }

        if (isbossInst)
        {


            boss_hp_slider.value = bosscs.boss_hp_cur / bosscs.boss_hp_max;
            

        }
            
        
      
    }

  
    void SpawnEnemy()
    {
        int randnum = Random.Range(0, 4);

        GameObject enemy_info = obj_manager_in_gm.SelectObj("Enemy");

        enemy_info.transform.position = spawn_pos[randnum].transform.position;
        enemycs = enemy_info.GetComponent<Enemy>();
        enemycs.hp = 3;
        enemycs.objectManager = obj_manager_in_gm;



        Rigidbody2D astroid_rigid = enemy_info.GetComponent<Rigidbody2D>();

        astroid_rigid.AddForce(Vector2.down * 7, ForceMode2D.Impulse);


    }

    
    

    void SpawnBoss()
    {
         boss_info = Instantiate(bossobj, boss_spawn_pos.transform.position, boss_spawn_pos.transform.rotation);

        bosscs = boss_info.GetComponent<Boss>();
        bosscs.obj_mamager_in_bosscs = obj_manager_in_gm;


        
        isbosssp = false;
        isbossInst = true;

        bosscs.player = player_info;

       

    }






}
