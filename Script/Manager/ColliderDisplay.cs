using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisplay : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.GetGameOverFlg())
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
