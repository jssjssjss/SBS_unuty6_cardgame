using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI; //ui 불러오기

public class GameManager : MonoBehaviour
{

    List<string> player0 = new List<string>();
    List<string> computer0 = new List<string>();
    List<string> computer1 = new List<string>();
    List<string> computer2 = new List<string>();
    public List<string> card_list = new List<string>();
    public List<int> player_card_value=new List<int>();  
    SpriteRenderer[] spriteRenderer = new SpriteRenderer[8];

    List<string> ddang = new List<string>() { "aA", "bB","cC","dD","eE","fF","gG","hH","iI","jJ" };      //땡
    List<string> ddang_kill = new List<string>() { "cg", "cG", "Cg", "CG" };                             //떙잡이
    List<string> ggang = new List<string>() { "AC", "AH" };                                              //광
    List<string> ggang_kill = new List<string>() { "DG" };                                               //광잡이 .암행어사
    List<string> player_card_name = new List<string>();


    public GameObject[] card;
    public GameObject[] target;
    public Sprite[] my_sprite = new Sprite[21];
    public Sprite[] text_sprite= new Sprite[21];

    public Text info_text;
    public Text info_text2;
    public Text info_text3;
    public Text info_text4;
    public Text info_text5;
    public Text info_text6;

    float timer = 0;
    float test_timer = 0;

    bool isbatting = true;
    bool isstart = true;
    bool isDDang = false;
    bool isDDang_kill = false;
    bool isGGang = false;
    bool isGGang_kill = false;

   
    string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};

    int max = 0;
    int max_index = 0;


    Dictionary<string, int> jokbo = new Dictionary<string, int>()
            {   //dictionary에 10땡 까지 추가하기
            { "CH",999},               //38광땡
            { "AC",400},{ "AH",400},   //13,18 광떙
            { "aA", 200 },{ "bB", 220 },{ "cC", 240 },{ "dD", 260 },{ "eE", 280 },{ "fF", 300 },{ "gG", 320 },{ "hH", 340 },{ "iI", 360 },{ "jJ", 380 }, //떙
            { "ab",180},{ "aB",180},{ "Ab",180},{ "AB",180}, //알리  1,2
            { "ad",160},{ "aD",160},{ "Ad",160},{ "AD",160}, //독사  1,4
            { "ai",140},{ "aI",140},{ "Ai",140},{ "AI",140}, //구삥  1,9
            { "aj",120},{ "aJ",120},{ "Aj",120},{ "AJ",120}, //장삥  1,10
            { "di",100},{ "dI",100},{ "Di",100},{ "DI",100}, //장사  4,10
            { "df",80},{ "dF",80},{ "Df",80},{ "DF",80}, //세륙
            { "cg",1},{ "cG",1},{ "Cg",1},{ "CG",1},  //떙잡이
            {"DG",0 }                                 //광잡이

     };
    Dictionary<string, int> non_jokbo = new Dictionary<string, int>()
     {
            {"a",1 },{"A",1 },{"b",2 },{"B",2 },{"c",3 },{"C",3 },{"d",4 },{"D",4 },{"e",5 },{"E",5 },
            {"f",6 },{"F",6 },{"g",7 },{"G",7 },{"h",8 },{"H",8 },{"i",9 },{"I",9 },{"j",10 },{"J",10 },
     };
    Dictionary<string, string> jokbo_name = new Dictionary<string, string>()
    {
          { "CH","38광떙"},               //38광땡
            { "AC","13광떙"},{ "AH","18광떙"},   //13,18 광떙
        {"aA","1땡" },{ "bB", "2땡" },{ "cC", "3땡" },{ "dD", "4땡" },{ "eE", "5떙" },{ "fF", "6땡" },{ "gG", "7땡" },{ "hH", "8떙" },{ "iI", "9땡" },{ "jJ", "10땡" },

            { "ab","알리"},{ "aB","알리"},{ "Ab","알리"},{ "AB","알리"}, //알리  1,2
            { "ad","독사"},{ "aD","독사"},{ "Ad","독사"},{ "AD","독사"}, //독사  1,4
            { "ai","구삥"},{ "aI","구삥"},{ "Ai","구삥"},{ "AI","구삥"}, //구삥  1,9
            { "aj","장삥"},{ "aJ","장삥"},{ "Aj","장삥"},{ "AJ","장삥"}, //장삥  1,10
            { "di","장사"},{ "dI","장사"},{ "Di","장사"},{ "DI","장사"}, //장사  4,10
            { "df","세륙"},{ "dF","세륙"},{ "Df","세륙"},{ "DF","세륙"}, //세륙
            { "cg","떙잡이"},{ "cG","떙잡이"},{ "Cg","떙잡이"},{ "CG","떙잡이"},  //떙잡이
            {"DG","광잡이"}                                 //광잡이

    };

    Dictionary<int, string> non_jokbo_name = new Dictionary<int, string>()
    {
        {0,"망통" },{1,"일끗"},{2,"이끗"},{3,"세끗"},{4,"네끗"},{5,"다섯끗"},{6,"여섯끗"},{7,"일곱끗"},{8,"여덟끗"},{9,"갑오"},

    };



    void Start()
    {

        info_text.text = "게임을 시작하시겠습니까?";
        //for (int i = 0; i < card.Length; i++)
        //{
        //    spriteRenderer[i] = card[i].GetComponent<SpriteRenderer>();
        //    spriteRenderer[i].sprite=my_sprite[i];
        //
        //}





        for (int i = 0; i < card.Length; i++)
        {
            spriteRenderer[i] = card[i].GetComponent<SpriteRenderer>();

           



        }

        text_sprite[0] = my_sprite[11];
        text_sprite[1] = my_sprite[1];

        text_sprite[2] = my_sprite[2];
        text_sprite[3] = my_sprite[6];

        text_sprite[4] = my_sprite[13];
        text_sprite[5] = my_sprite[16];

        text_sprite[6] = my_sprite[12];
        text_sprite[7] = my_sprite[10];

        spriteRenderer[3].sprite = my_sprite[6];
        spriteRenderer[5].sprite = my_sprite[16];
        spriteRenderer[7].sprite = my_sprite[10];


      

        //spriteRenderer[0].sprite = my_sprite[11];
        //spriteRenderer[1].sprite = my_sprite[1];

        //spriteRenderer[2].sprite = my_sprite[2];
        //spriteRenderer[3].sprite = my_sprite[20];

        //spriteRenderer[4].sprite = my_sprite[13];
        //spriteRenderer[5].sprite = my_sprite[20];

        //spriteRenderer[6].sprite = my_sprite[12];
        //spriteRenderer[7].sprite = my_sprite[20];

       

    }






    public void GameStart()
    {
        if (isstart)
        {
            info_text.text = "배팅을 하시겠습니까?";

            player0.Add(spriteRenderer[0].sprite.name);
            player0.Add(spriteRenderer[1].sprite.name);
            player0.Sort();
            card_list.Add(player0[0] + player0[1]);
            if (jokbo.ContainsKey(card_list[0]))
            {
                player_card_value.Add(jokbo[card_list[0]]);

            }
            else
            {
                player_card_value.Add((non_jokbo[card_list[0][0].ToString()] + non_jokbo[card_list[0][1].ToString()]) % 10);
            }

            isstart = false;

            if (jokbo_name.ContainsKey(card_list[0]))
            {
                info_text2.text = jokbo_name[card_list[0]];
            }
            else
            {
                info_text2.text = non_jokbo_name[player_card_value[0]];

            }

            if (jokbo_name.ContainsKey(card_list[0]))
            {
                player_card_name.Add(jokbo_name[card_list[0]]);
            }
           else if (non_jokbo_name.ContainsKey(player_card_value[0]))
            {
                player_card_name.Add(non_jokbo_name[player_card_value[0]]);
                
            }

            for (int i = 0; i < card.Length; i++)
            {
                StartCoroutine(RotateCard(card[i], target[i]));

            }

            for (int i = 0; i < card.Length; i++)
            {
                StartCoroutine(MoveCard(card[i], target[i]));

            }



            for (int i = 0; i < card.Length; i++)
            {



                card[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                if (i >= 2)
                {
                    card[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

                }
                if (i >= 4)
                {
                    card[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

                }
                if (i >= 6)
                {
                    card[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 360));

                }

            }

           

        }
       
    }

    public void CardRotate()
    {
        //card[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        //card[1].transform.Rotate(Vector3.back * 90);


    }
    public void Batting()
    {
        if (isbatting)
        {



            spriteRenderer[2].sprite = my_sprite[2];
            spriteRenderer[4].sprite = my_sprite[13];
            spriteRenderer[6].sprite = my_sprite[12];
            isbatting =false;

           
           


            computer0.Add(spriteRenderer[2].sprite.name);
            computer0.Add(spriteRenderer[3].sprite.name);
            computer0.Sort();

            computer1.Add(spriteRenderer[4].sprite.name);
            computer1.Add(spriteRenderer[5].sprite.name);
            computer1.Sort();

            computer2.Add(spriteRenderer[6].sprite.name);
            computer2.Add(spriteRenderer[7].sprite.name);
            computer2.Sort();



            card_list.Add(computer0[0] + computer0[1]);
            card_list.Add(computer1[0] + computer1[1]);
            card_list.Add(computer2[0] + computer2[1]);

            for (int i = 1; i < card_list.Count; i++)
            {
                if (jokbo.ContainsKey(card_list[i]))
                {
                    player_card_value.Add(jokbo[card_list[i]]);

                }
                else
                {
                    player_card_value.Add((non_jokbo[card_list[i][0].ToString()] + non_jokbo[card_list[i][1].ToString()]) % 10);
                }


            }


            //  =====================================================떙
            for (int i = 0; i < player_card_value.Count; i++)
            {
                if (ddang.Contains(card_list[i]))
                {
                    isDDang= true;
                    Debug.Log("떙이 존재합니다.");
                    break;
                    

                }

            }
            //=============================================================떙 잡이
            if (isDDang)
            {
                for (int i = 0; i < player_card_value.Count; i++)
                {
                    if (ddang_kill.Contains(card_list[i]))
                    {
                        isDDang_kill= true;
                        Debug.Log("떙잡이가 존재합니다.");
                        player_card_value[i] = 370;
                        break;

                    }

                }
                

            }

            //=====================================================광
            for (int i = 0; i < player_card_value.Count; i++)
            {
                if (ggang.Contains(card_list[i]))
                {
                    isGGang = true;
                    Debug.Log("광이 존재합니다.");
                    break;

                }

            }

            //====================================================광잡이
            if (isGGang)
            {
                for (int i = 0; i < player_card_value.Count; i++)
                {
                    if (ggang_kill.Contains(card_list[i]))
                    {
                        isGGang_kill=true;
                        Debug.Log("광잡이가 존재합니다.");
                        player_card_value[i] = 980;
                        break;
                        

                    }

                }

            }

            for (int i = 1; i < card_list.Count; i++)
            {
                if (jokbo_name.ContainsKey(card_list[i]))
                {
                    player_card_name.Add(jokbo_name[card_list[i]]);
                }
                else if (non_jokbo_name.ContainsKey(player_card_value[i]))
                {
                    player_card_name.Add(non_jokbo_name[player_card_value[i]]);

                }


            }

            for (int i = 0; i < player_card_value.Count; i++)
            {
                if (max < player_card_value[i])
                {
                    max = player_card_value[i];
                    max_index = i;
                }

            }


            Debug.Log("최대값 :" + max);
            Debug.Log(max_index + "번째 플레이어");

        }
        info_text.text = "승자" + player_card_name[max_index] + max_index + "번쨰 플레이어";

      
      
        if (jokbo_name.ContainsKey(card_list[1]))
        {
            info_text4.text = jokbo_name[card_list[1]];
        }
        else
        {
            info_text4.text = non_jokbo_name[player_card_value[1]];

        }


        if (jokbo_name.ContainsKey(card_list[2]))
        {
            info_text5.text = jokbo_name[card_list[2]];
        }
        else
        {
            info_text5.text = non_jokbo_name[player_card_value[2]];

        }

        if (jokbo_name.ContainsKey(card_list[3]))
        {
            info_text6.text = jokbo_name[card_list[3]];
        }
        else
        {
            info_text6.text = non_jokbo_name[player_card_value[3]];

        }
     






    }

    // Update is called once per frame

    // 업데이트는 한프레임마다 계속 작동된다
    // cororutine 
    // yield= 조건만 실행하고 그 시스템을 돌려준다 , 즉 업데이트 안에서 작동을 멈춘다

    void Update()
    {
      
   
    }



    // timer 시간동안 안에있는 조건을 실행한다 

    //    GameObject로 my_card, goal 이라는 빈공간을 만든다   *****+*+*+*+*+*+ 
    //   값이 비어진 로직을 만들어서 원하는 값을 넣고 원할떄 사용할수 있도록 만든것
        // MoveCard(GameObject my_card, GameObject goal)
        IEnumerator MoveCard(GameObject my_card, GameObject goal)
    {
        while (timer <= 15)
        {
            
            timer = timer + Time.deltaTime;
            my_card.transform.position = Vector3.MoveTowards(my_card.transform.position, goal.transform.position, 5* Time.deltaTime);

            // yield=비동기 ,돌려준다
            yield return null;

            Debug.Log("코르틴 종료");
        }

    }

    IEnumerator RotateCard(GameObject me_card, GameObject me_goal)
    {
        while(test_timer <=15)
        {
            test_timer = test_timer + Time.deltaTime;
            me_card.transform.Rotate(new Vector3(0, 0, 90));

            yield return null;  

        }    

    }

    

}
