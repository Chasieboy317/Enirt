using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnstile : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerspushing;
    public Transform checkPoint;
    public bool turned;
    void Start()
    {
        playerspushing = 0;
        turned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!turned && playerspushing == 4)
        {
            if (Physics.Raycast(checkPoint.transform.position, Vector3.up))
            {
                transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime * 0.1f);
                turned = true;
            }
            else
            {
                transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 0.1f);
                turned = true;
            }
        }
        playerspushing = 0;
    }

    void playerPushing(int num)
    {
        playerspushing += num;
    }
}
