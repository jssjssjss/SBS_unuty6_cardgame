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
        }

        if (timer > 15)
        {
            Debug.Log("10초과");

        }


    }

}
