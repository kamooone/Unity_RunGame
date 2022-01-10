using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDisplay : MonoBehaviour
{
    [SerializeField] GameObject result;

    void Update()
    {
        //[D]キーを押す
        if (PlayerMove.GetGameOverFlg())
        {
            //ゲームオブジェクト非表示→表示
            result.SetActive(true);
        }
    }
}
