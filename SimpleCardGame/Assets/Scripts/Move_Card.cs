using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Card : MonoBehaviour
{
    Rigidbody2D my_rigid;
    //백터 위치를 받는것 = vector2
    Vector3 my_position;

    [SerializeField]
    Vector3 goal_position;
    Vector3 Next_position;

    


[SerializeField] 
 GameObject goal;

    void Start()
    {

        my_rigid=GetComponent<Rigidbody2D>();
        my_position=transform.position;

        goal_position=goal.transform.position;
        //c-a
        Next_position = my_position + (goal_position - my_position);

        ///                       내위치          
      // transform.position=transform.position+Next_position;


       
       // transform.position=Next_position;



        
    }


    // Update is called once per frame
    void Update() // 한 프레임마다 호출
    {


        Next_position = goal_position - transform.position;

        // transform.position = transform.position+ Next_position * Time.deltaTime;

        //my_rigid.MovePosition(transform.position + Next_position.normalized *5* Time.deltaTime);


        //                           정확하게도          시작            도착             시간/속도
        transform.position = Vector3.MoveTowards(transform.position, goal_position, 10 * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Next_position, 10 * Time.deltaTime);
    }
}
