using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if (PlayerMove.GetJumpFlg())
            {
                //this.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            }
            if (PlayerMove.Ground())
            {
                this.transform.localScale = new Vector3(1, 0.7f, 1);
            }
        }
    }
}
