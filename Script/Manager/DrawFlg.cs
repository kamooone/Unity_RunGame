using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFlg : MonoBehaviour
{
    // 画面内時のみ表示
    void OnWillRenderObject()
    {
        this.gameObject.SetActive(true);
    }
}