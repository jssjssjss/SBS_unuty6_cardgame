using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;
    public GameObject[] target;

    float timer = 0;


    
    void Start()
    {


        
    }





    public void GameStart()
    {

        for (int i = 0; i < card.Length; i++)
        {
            StartCoroutine(MoveCard(card[i], target[i]));

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
        }

        if (timer > 15)
        {
            Debug.Log("10�ʰ�");

        }


    }

}
