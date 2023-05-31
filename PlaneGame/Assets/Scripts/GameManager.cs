using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player_spawn_pos;
    public GameObject astroid;
    float sp_speed;
    public GameObject[] spawn_pos;
    float cur_timer = 0;
    float spawn_delay = 1.5f;
     GameObject astroid_info;
    Rigidbody2D[] astroid_rigid;

    


    Enemy enemycs;
    Player playercs;

    public ObjectManager obj_manager_in_gm;
    public GameObject playerobj;
    GameObject player_info;

    public GameObject boss_spawn_pos;
    public GameObject boss;




    private void Awake()
    {

        player_info=Instantiate(playerobj, player_spawn_pos.transform.position, player_spawn_pos.transform.rotation);
        playercs = player_info.GetComponent<Player>();

        //여기에 있는 obj_manager를 playercs.obj_manager에 넣는다.
        playercs.obj_manager= obj_manager_in_gm;


        


    }

    void Start()
    {


        
     


    }

    // Update is called once per frame
    void Update()
    {


        SpawnBoss();
        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer +=Time.deltaTime; // 같은거

     
            if (cur_timer > spawn_delay)
            {
               SpawnEnemy();
                cur_timer = 0;
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
        GameObject boss_info = Instantiate(boss, boss_spawn_pos.transform.position, boss_spawn_pos.transform.rotation);
        Rigidbody2D boss_rigid=boss_info.GetComponent<Rigidbody2D>();


    }






}
