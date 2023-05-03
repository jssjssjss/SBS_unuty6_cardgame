using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody2D my_rigid;


    [SerializeField]
    Vector3 my_position;
    Vector3 Next_position;
    Vector3 Goal_position;

    public GameObject Goal;




    
    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
        my_position=transform.position;
        Goal_position=Goal.transform.position;
        Next_position = my_position + (Goal_position - my_position);
 
    }

    // Update is called once per frame
    void Update()
    {
        Next_position = Goal_position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, Goal_position, 8 * Time.deltaTime);

        
    }
}
