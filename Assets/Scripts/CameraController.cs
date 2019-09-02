<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float zoom;
    public GameObject knight;


    // Start is called before the first frame update
    void Start()
    {

        /*
         * TO DO:
         * the zoom should be a percentage of the distance between the player and the camera
         * so you should be able to do something like
         * distanceFromPlayer = (camera.x-player.x)*zoom
         */
        //apply the correct amount of zoom
        transform.position = knight.transform.position;
        //transform.position += transform.forward * zoom;
 
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKey(KeyCode.A))
       // {
       //     transform.position += -transform.right * speed * Time.deltaTime;
       // }
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += transform.right * speed * Time.deltaTime;
       // }

        transform.position = new Vector3(4, 2.7f, knight.transform.position.z);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float zoom;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * TO DO:
         * the zoom should be a percentage of the distance between the player and the camera
         * so you should be able to do something like
         * distanceFromPlayer = (camera.x-player.x)*zoom
         */
        //apply the correct amount of zoom
        transform.position += transform.forward * zoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
}
>>>>>>> CharacterAnimation
