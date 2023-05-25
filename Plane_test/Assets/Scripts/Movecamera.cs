using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject target;
    public Vector2 radius;
    public Vector2 cube_size;

    float cam_hieght;
    float cam_width;

    bool hitbox=false;


    void Start()
    {
        cam_hieght = Camera.main.orthographicSize;
        cam_width = cam_hieght*Screen.width/Screen.height;

        Debug.Log(cam_hieght);
        Debug.Log(Screen.height);
        Debug.Log(Screen.width);

        
    }

    // Update is called once per frame
    void Update()
    {
       


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(radius,cube_size);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10);


        float camboundaryx = cube_size.x * 0.5f - cam_width;
        float camboundaryy = cube_size.y * 0.5f - cam_hieght;

        float clampx = Mathf.Clamp(transform.position.x, -camboundaryx + radius.x, camboundaryx + radius.x);
        float clampy = Mathf.Clamp(transform.position.y, -camboundaryy + radius.y, camboundaryy + radius.y);

        transform.position = new Vector3(clampx,clampy, -10);



    }


  





}
