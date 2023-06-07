using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player_spawn_pos;
    public GameObject astroid;
    float sp_speed;

    public GameObject[] spawn_pos;
    float cur_timer = 0;
    float spawn_delay = 1.5f;


    //에너미 
     GameObject astroid_info;
    Rigidbody2D[] astroid_rigid;



    //텍스트
    public Text score_text;
    public GameObject gameover_obj;
    public Text gameover_text;

    public GameObject game_win_obj;
    public Text game_win_text;


    Enemy enemycs;
    Player player_in_gm;
    Player playercs;
    Boss bosscs;


    //플레이어
    public ObjectManager obj_manager_in_gm;
    public GameObject playerobj;
    GameObject player_info;


    //보스불hp
    Slider boss_hp_slider;
    public GameObject boss_hp_obj;

    //플레이어 hp
    Slider player_hp_slider;
    public GameObject player_hp_obj;



    //보스 소환
    public GameObject boss_spawn_pos;
    public GameObject bossobj;



    
    GameObject boss_info;


    bool isbosssp=true;
    bool isbossInst = false;

    float cur_hp=10;
    




    private void Awake()
    {

        player_info=Instantiate(playerobj, player_spawn_pos.transform.position, player_spawn_pos.transform.rotation);
        player_in_gm = player_info.GetComponent<Player>();
        //여기에 있는 obj_manager를 playercs.obj_manager에 넣는다.
        player_in_gm.obj_manager= obj_manager_in_gm;


        player_hp_slider = player_hp_obj.GetComponent<Slider>();



    }

    void Start()
    {


        Time.timeScale = 1;

        boss_hp_slider = boss_hp_obj.GetComponent<Slider>();




    }

    // Update is called once per frame
    void Update()
    {



        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer +=Time.deltaTime; // 같은거


        if (player_in_gm.player_cur_hp<=0)
        {

            gameover_obj.SetActive(true);

            gameover_text.text = "!!!!GAME OVER!!!!!";
            
           
        }

        if (isbossInst)
        {
            if (bosscs.boss_hp_cur <= 0)
            {
                game_win_obj.SetActive(true);
                game_win_text.text = "GAME WIn";
                isbossInst = false;
                Invoke("StopTime", 1);


            }

        }

        


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

            
        
      
    }

    private void LateUpdate()
    {
        score_text.text = player_in_gm.score.ToString();


        if (isbossInst)
        {


            boss_hp_slider.value = bosscs.boss_hp_cur / bosscs.boss_hp_max;


        }

        
        
            player_hp_slider.value = player_in_gm.player_cur_hp / player_in_gm.player_max_hp;

        
    }



    void SpawnEnemy()
    {
        int randnum = Random.Range(0, 4);

        GameObject enemy_info = obj_manager_in_gm.SelectObj("Enemy");

        enemy_info.transform.position = spawn_pos[randnum].transform.position;
        enemycs = enemy_info.GetComponent<Enemy>();
        enemycs.hp = 3;
        enemycs.objectManager = obj_manager_in_gm;

        enemycs.playercs = player_in_gm;



        Rigidbody2D astroid_rigid = enemy_info.GetComponent<Rigidbody2D>();

        astroid_rigid.AddForce(Vector2.down * 4, ForceMode2D.Impulse);


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

    public void ReStrart()
    {
        SceneManager.LoadScene("Stage1");
        //SceneManager.LoadScene(0);

    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    void StopTime()
    {
        Time.timeScale = 0;
    }


}
