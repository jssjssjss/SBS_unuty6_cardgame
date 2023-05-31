using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject playerBullet;
    public GameObject particleEffect;


    GameObject[] enemy_arr;
    GameObject[] playerBullet_arr;
    GameObject[] particle_arr;




    GameObject[] obj_arr;
    void Start()
    {

        enemy_arr = new GameObject[30];
        playerBullet_arr = new GameObject[32];
        particle_arr=new GameObject[32];
        InitObj();
       

    }


   


    void InitObj()
    {
        for (int i = 0; i < enemy_arr.Length; i++)
        {
            enemy_arr[i]=Instantiate(enemy);

            //������Ʈ�� off�Ѵ�
            enemy_arr[i].SetActive(false);

        }

        for (int i = 0; i < playerBullet_arr.Length; i++)
        {
            playerBullet_arr[i] = Instantiate(playerBullet);
            playerBullet_arr[i].SetActive(false);

        }
        for (int i = 0; i < particle_arr.Length; i++)
        {
            particle_arr[i] = Instantiate(particleEffect);
            particle_arr[i].SetActive(false);

        }
        
    }


    public GameObject SelectObj(string name)
    {

        switch(name)
        {
            case "Enemy":
                obj_arr = enemy_arr;
                break;

            case "PlayerBullet":
                obj_arr = playerBullet_arr;

                break;
            case "ParticleEffect":
                obj_arr=particle_arr;
                break;
        }


        for (int i = 0; i < obj_arr.Length; i++)
        {
            //������Ʈ�� Ȱ��ȭ �������� Ʈ�� (!) �ݴ� �� ������Ʈ�� Ȱ��ȭ�ݴ� ���������� ����ȴ�.
            if (!obj_arr[i].activeSelf)
            {
                obj_arr[i].SetActive(true);
                return obj_arr[i];

            }

        }
        return null;
    }








    



    // Update is called once per frame
    void Update()
    {
        
    }
}
