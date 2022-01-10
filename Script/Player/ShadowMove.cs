using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerMove.GetPlayer_Pos_X(), this.transform.position.y, 0);
    }
}
