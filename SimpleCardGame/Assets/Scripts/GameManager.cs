using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    
    
    public GameObject[] card;
    public Sprite[] my_sprites;
    



    //ũ������ �ʿ�
    SpriteRenderer[] card_renderer = new SpriteRenderer[5];

    Random rand = new Random();

    List<String> list = new List<String>();
    List<int> num = new List<int>();
    List<String> sh = new List<String>();


    bool IF=false;
    bool IM = false;
    bool IS = false;

    int PC = 0;


    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < 5; i++)
        {

            //���� �ߺ�
            int a = rand.Next(0, 32);


            card_renderer[i] = card[i].GetComponent<SpriteRenderer>();
            //��������Ʈ �������� �ִ� ��������Ʈ �̹����� �������� ���� �̹����� �����ϰڴ�.
            card_renderer[i].sprite = my_sprites[a];
           



            list.Add(card_renderer[i].sprite.name);
            num.Add(int.Parse(card_renderer[i].sprite.name.Substring(0, 2)));
            sh.Add(card_renderer[i].sprite.name.Substring(2, 1));

            Debug.Log(num[i] + " " + sh[i]);
            Debug.Log(list[i]);

        }

        

        

        Batting();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Batting()
    {
        num.Sort();
        sh.Sort();

        //Flush==================================================================================          
        if (sh[0] == sh[sh.Count - 1])
            IF = true;
        //Mount============================================================================================
        if ((num[0] == 6) && (num[1] == 10) && (num[2] == 11) && (num[3] == 12) && (num[4] == 13))
            IM = true;
        //Straight=======================================================================================
        for (int i = 0; i < num.Count - 1; i++)
        {

            if (num[i + 1] - num[i] == 1)
            {
                IS = true;
            }
            else
            {

                break;

            }
        }
        //Pair==============================================================
        for (int i = 0; i < num.Count - 1; i++)
        {
            for (int j = i + 1; j < num.Count; j++)
            {
                if (num[i] == num[j])
                {
                    PC++;
                }

            }

        }
        if (IF && IM)
        {
            Debug.Log("��Ƽ��");
        }
        else if (IF && IS)
        {
            Debug.Log("��Ʈ����Ʈ�÷���");
        }
        else if (PC == 6)
        {
            Debug.Log("��ī��");
        }
        else if (PC == 4)
        {
            Debug.Log("Ǯ�Ͽ콺");
        }
        else if (IF)
        {
            Debug.Log("�÷���");
        }
        else if (IM)
        {
            Debug.Log("����Ʈ");
        }
        else if (PC == 1)
        {
            Debug.Log("�����");
        }
        else if (PC == 2)
        {
            Debug.Log("�����");
        }
        else if (PC == 3)
        {
            Debug.Log("Ʈ����");
        }

    }
}


