using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<string> sh = new List<string>();
  
    
    public GameObject[] card;
    public GameObject[] target;

   public  Sprite[] my_sprite = new Sprite[20]; 

    SpriteRenderer[]  spriteRenderer=new SpriteRenderer[8];
   

    float timer = 0;
    float test_timer = 0;
    


    
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
        
        spriteRenderer[4].sprite = my_sprite[8];
        spriteRenderer[5].sprite = my_sprite[7];
        
        spriteRenderer[6].sprite = my_sprite[9];
        spriteRenderer[7].sprite = my_sprite[10];


        for (int i = 0; i < card.Length; i++)
        {
            sh.Add(spriteRenderer[i].sprite.name);

        }
        for (int i = 0; i < card.Length; i++)
        {
            Debug.Log(sh[i]);
        }



        

    }


    public void GameStart()
    {

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
            if (i>=2)
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

    public void CardRotate()
    {
        //card[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        //card[1].transform.Rotate(Vector3.back * 90);


    }
    public void Batting()
    {


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
