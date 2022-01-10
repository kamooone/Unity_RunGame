using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 画面外で弾削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obj" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Die_Collision")
        {
            // 弾削除
            Destroy(this.gameObject);
        }
    }
}
