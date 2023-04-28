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
    



    //크기지정 필요
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

            //숫자 중복
            int a = rand.Next(0, 32);


            card_renderer[i] = card[i].GetComponent<SpriteRenderer>();
            //스프라이트 렌더러에 있는 스프라이트 이미지를 랜덤으로 정한 이미지로 변경하겠다.
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
            Debug.Log("로티플");
        }
        else if (IF && IS)
        {
            Debug.Log("스트레이트플러쉬");
        }
        else if (PC == 6)
        {
            Debug.Log("포카드");
        }
        else if (PC == 4)
        {
            Debug.Log("풀하우스");
        }
        else if (IF)
        {
            Debug.Log("플러쉬");
        }
        else if (IM)
        {
            Debug.Log("마운트");
        }
        else if (PC == 1)
        {
            Debug.Log("원페어");
        }
        else if (PC == 2)
        {
            Debug.Log("투페어");
        }
        else if (PC == 3)
        {
            Debug.Log("트리플");
        }

    }
}


