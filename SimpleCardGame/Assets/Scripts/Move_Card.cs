using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Card : MonoBehaviour
{
    Rigidbody2D my_rigid;
    //���� ��ġ�� �޴°� = vector2
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

        ///                       ����ġ          
      // transform.position=transform.position+Next_position;


       
       // transform.position=Next_position;



        
    }


    // Update is called once per frame
    void Update() // �� �����Ӹ��� ȣ��
    {


        Next_position = goal_position - transform.position;

        // transform.position = transform.position+ Next_position * Time.deltaTime;

        //my_rigid.MovePosition(transform.position + Next_position.normalized *5* Time.deltaTime);


        //                           ��Ȯ�ϰԵ�          ����            ����             �ð�/�ӵ�
        transform.position = Vector3.MoveTowards(transform.position, goal_position, 10 * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Next_position, 10 * Time.deltaTime);
    }
}
