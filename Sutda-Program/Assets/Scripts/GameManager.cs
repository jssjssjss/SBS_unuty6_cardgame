using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    List<string> player0 = new List<string>();
    List<string> computer0 = new List<string>();
    List<string> computer1 = new List<string>();
    List<string> computer2 = new List<string>();
    public List<string> card_list = new List<string>();
    public List<int> player_card_value=new List<int>();  
    SpriteRenderer[] spriteRenderer = new SpriteRenderer[8];

    List<string> ddang = new List<string>() { "aA", "bB","cC","dD","eE","fF","gG","hH","iI","jJ" };      //��
    List<string> ddang_kill = new List<string>() { "cg", "cG", "Cg", "CG" };                             //������
    List<string> ggang = new List<string>() { "AC", "AH" };                                              //��
    List<string> ggang_kill = new List<string>() { "DG" };                                               //������ .������



    public GameObject[] card;
    public GameObject[] target;
    public Sprite[] my_sprite = new Sprite[20];

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
            {   //dictionary�� 10�� ���� �߰��ϱ�
            { "CH",999},               //38����
            { "AC",400},{ "AH",400},   //13,18 ����
            { "aA", 200 },{ "bB", 220 },{ "cC", 240 },{ "dD", 260 },{ "eE", 280 },{ "fF", 300 },{ "gG", 320 },{ "hH", 340 },{ "iI", 360 },{ "jJ", 380 }, //��
            { "ab",180},{ "aB",180},{ "Ab",180},{ "AB",180}, //�˸�  1,2
            { "ad",160},{ "aD",160},{ "Ad",160},{ "AD",160}, //����  1,4
            { "ai",140},{ "aI",140},{ "Ai",140},{ "AI",140}, //����  1,9
            { "aj",120},{ "aJ",120},{ "Aj",120},{ "AJ",120}, //���  1,10
            { "di",100},{ "dI",100},{ "Di",100},{ "DI",100}, //���  4,10
            { "df",80},{ "dF",80},{ "Df",80},{ "DF",80}, //����
            { "cg",1},{ "cG",1},{ "Cg",1},{ "CG",1},  //������
            {"DG",0 }                                 //������

     };
    Dictionary<string, int> non_jokbo = new Dictionary<string, int>()
     {
            {"a",1 },{"A",1 },{"b",2 },{"B",2 },{"c",3 },{"C",3 },{"d",4 },{"D",4 },{"e",5 },{"E",5 },
            {"f",6 },{"F",6 },{"g",7 },{"G",7 },{"h",8 },{"H",8 },{"i",9 },{"I",9 },{"j",10 },{"J",10 },
     };




    void Start()
    {
   


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

        spriteRenderer[0].sprite = my_sprite[11];
        spriteRenderer[1].sprite = my_sprite[1];

        spriteRenderer[2].sprite = my_sprite[2];
        spriteRenderer[3].sprite = my_sprite[6];
        
        spriteRenderer[4].sprite = my_sprite[13];
        spriteRenderer[5].sprite = my_sprite[16];
        
        spriteRenderer[6].sprite = my_sprite[12];
        spriteRenderer[7].sprite = my_sprite[10];



    }


    public void GameStart()
    {
        if (isstart)
        {
            isstart = false;
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
            isbatting=false;
            player0.Add(spriteRenderer[0].sprite.name);
            player0.Add(spriteRenderer[1].sprite.name);
            player0.Sort();

            computer0.Add(spriteRenderer[2].sprite.name);
            computer0.Add(spriteRenderer[3].sprite.name);
            computer0.Sort();

            computer1.Add(spriteRenderer[4].sprite.name);
            computer1.Add(spriteRenderer[5].sprite.name);
            computer1.Sort();

            computer2.Add(spriteRenderer[6].sprite.name);
            computer2.Add(spriteRenderer[7].sprite.name);
            computer2.Sort();



            card_list.Add(player0[0] + player0[1]);
            card_list.Add(computer0[0] + computer0[1]);
            card_list.Add(computer1[0] + computer1[1]);
            card_list.Add(computer2[0] + computer2[1]);

            for (int i = 0; i < card_list.Count; i++)
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


            //  =====================================================��
            for (int i = 0; i < player_card_value.Count; i++)
            {
                if (ddang.Contains(card_list[i]))
                {
                    isDDang= true;
                    Debug.Log("���� �����մϴ�.");
                    break;
                    

                }

            }
            //=============================================================�� ����
            if (isDDang)
            {
                for (int i = 0; i < player_card_value.Count; i++)
                {
                    if (ddang_kill.Contains(card_list[i]))
                    {
                        isDDang_kill= true;
                        Debug.Log("�����̰� �����մϴ�.");
                        player_card_value[i] = 370;
                        break;

                    }

                }
                

            }

            //=====================================================��
            for (int i = 0; i < player_card_value.Count; i++)
            {
                if (ggang.Contains(card_list[i]))
                {
                    isGGang = true;
                    Debug.Log("���� �����մϴ�.");
                    break;

                }

            }

            //====================================================������
            if (isGGang)
            {
                for (int i = 0; i < player_card_value.Count; i++)
                {
                    if (ggang_kill.Contains(card_list[i]))
                    {
                        isGGang_kill=true;
                        Debug.Log("�����̰� �����մϴ�.");
                        player_card_value[i] = 980;
                        break;
                        

                    }

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


            Debug.Log("�ִ밪 :" + max);
            Debug.Log(max_index + "��° �÷��̾�");


          


        }


    }

    // Update is called once per frame

    // ������Ʈ�� �������Ӹ��� ��� �۵��ȴ�
    // cororutine 
    // yield= ���Ǹ� �����ϰ� �� �ý����� �����ش� , �� ������Ʈ �ȿ��� �۵��� �����

    void Update()
    {
      
   
    }



    // timer �ð����� �ȿ��ִ� ������ �����Ѵ� 

    //    GameObject�� my_card, goal �̶�� ������� �����   *****+*+*+*+*+*+ 
    //   ���� ����� ������ ���� ���ϴ� ���� �ְ� ���ҋ� ����Ҽ� �ֵ��� �����
        // MoveCard(GameObject my_card, GameObject goal)
        IEnumerator MoveCard(GameObject my_card, GameObject goal)
    {
        while (timer <= 15)
        {
            
            timer = timer + Time.deltaTime;
            my_card.transform.position = Vector3.MoveTowards(my_card.transform.position, goal.transform.position, 5* Time.deltaTime);

            // yield=�񵿱� ,�����ش�
            yield return null;

            Debug.Log("�ڸ�ƾ ����");
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
