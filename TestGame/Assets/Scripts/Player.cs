using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D my_rigid;

    public Vector2 inputvec;
    public Vector2 next_vec;

    float my_speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        inputvec.x = Input.GetAxisRaw("Horizontal");
        inputvec.y = Input.GetAxisRaw("Vertical");

        next_vec = inputvec.normalized;


    }



    private void FixedUpdate()
    {
        my_rigid.MovePosition(my_rigid.position+next_vec * Time.fixedDeltaTime);
    }
}

