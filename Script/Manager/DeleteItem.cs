using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // energyゲージ上昇
            PlayerMove.Damage(0.05f);

            // アイテム削除
            Destroy(this.gameObject);
        }
    }
}
