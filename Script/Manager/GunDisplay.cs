using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{
    [SerializeField] GameObject result;


    void Update()
    {
        if (Bullet.GetBulletFlg())
        {
            //ゲームオブジェクト非表示→表示
            result.SetActive(true);
        }

        if (!Bullet.GetBulletFlg())
        {
            result.SetActive(false);
        }
    }
}
