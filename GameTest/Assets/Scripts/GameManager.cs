using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    public GameObject[] card;
    public Sprite[] my_sprites;

    public GameObject button;

   




    //크기지정 필요
    SpriteRenderer[] card_renderer = new SpriteRenderer[5];



    List<String> list = new List<String>();
    List<int> num = new List<int>();
    List<String> sh = new List<String>();
    List<int> Rand_List = new List<int>();


    public Text ChangeText;

    bool IF = false;
    bool IM = false;
    bool IS = false;




    // Start is called before the first frame update
    void Start()
    {

       

        ChangeText.text = "게임을 시작합니다.";

        






        for (int i = 0; i < 10;)
        {
            int RandNum = UnityEngine.Random.Range(0, 32);
            if (Rand_List.Contains(RandNum))
            {
                RandNum = UnityEngine.Random.Range(0, 32);

            }
            else
            {
                Rand_List.Add(RandNum);
                i++;
            }



        }
        


        for (int i = 0; i < 5; i++)
        {






            card_renderer[i] = card[i].GetComponent<SpriteRenderer>();
            //스프라이트 렌더러에 있는 스프라이트 이미지를 랜덤으로 정한 이미지로 변경하겠다.
            card_renderer[i].sprite = my_sprites[Rand_List[i]];




            list.Add(card_renderer[i].sprite.name);
            num.Add(int.Parse(card_renderer[i].sprite.name.Substring(0, 2)));
            sh.Add(card_renderer[i].sprite.name.Substring(2, 1));

            //Debug.Log(num[i] + " " + sh[i]);
            //Debug.Log(list[i]);

        }







    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Batting()
    {
        num.Sort();
        sh.Sort();
        int PC = 0;

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
            ChangeText.text = ("로티플");
        }
        else if (IF && IS)
        {
            ChangeText.text = ("스트레이트플러쉬");
        }
        else if (PC == 6)
        {
            ChangeText.text = ("포카드");
        }
        else if (PC == 4)
        {
            ChangeText.text = ("풀하우스");
        }
        else if (IF)
        {
            ChangeText.text = ("플러쉬");
        }
        else if (IM)
        {
            ChangeText.text = ("마운트");
        }
        else if (PC == 1)
        {
            ChangeText.text = ("원페어");
        }
        else if (PC == 2)
        {
            ChangeText.text = ("투페어");
        }
        else if (PC == 3)
        {
            ChangeText.text = ("트리플");
        }

    }

    public void Changcard()
    {
        button.SetActive(true);
        
        Debug.Log("체인지카드함수가눌렸어요");
        card_renderer[0].sprite = my_sprites[Rand_List[5]];
        card_renderer[1].sprite = my_sprites[Rand_List[6]];
        card_renderer[2].sprite = my_sprites[Rand_List[7]];
        card_renderer[3].sprite = my_sprites[Rand_List[8]];
        card_renderer[4].sprite = my_sprites[Rand_List[9]];

    }





}



