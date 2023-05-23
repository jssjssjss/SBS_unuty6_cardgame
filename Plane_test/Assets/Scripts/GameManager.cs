using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    float st_time = 0;
    float ed_time = 0.2f;

    public GameObject Enemy;
   public GameObject[] sp_pos;
    public GameObject enemy_obj;
    Enemy enemycs;

    public GameObject playerobj;
    Player playercs;



    void Start()
    {
        playercs=playerobj.GetComponent<Player>();
        enemycs=enemy_obj.GetComponent<Enemy>();
        
    }

    // Update is called once per frame
    void Update()
    {





        st_time = st_time +Time.deltaTime;
        if (st_time > ed_time)
        {

            int random = Random.Range(0, 12);

            GameObject Enemy_copy = Instantiate(Enemy, sp_pos[random].transform.position, sp_pos[random].transform.rotation);
            Rigidbody2D enemy_rigid = Enemy.GetComponent<Rigidbody2D>();

            //enemycs�� �ִ� playerobj�� PlayerŬ�������� ������ �޾� ���ӸŴ����� player cs�� �����Ѱ��� enemycs�� ����
            //enemyobj�� �ִ� playerobj�� PlayerŬ�������� ������ �޾� ���ӸŴ����� player obj�� �����Ѱ��� enemyobj�� ����

            
            enemycs.playercs = playercs;




            
            enemy_rigid.AddForce(Vector2.down , ForceMode2D.Impulse);

            st_time = 0;
        }

        
    }
}
