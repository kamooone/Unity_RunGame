using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.GetDashSpeed() == 0.04f)
        {
            speed = 0.03f * Time.timeScale;
        }
        else
        {
            speed = 0.0f;
        }
        transform.position += new Vector3(speed, 0, 0);
    }
}
