using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    private static int score_num = 0; // スコア変数
    private static Text score_text;

    // 初期化
    void Start()
    {
        score_num = 0;

        // オブジェクトからTextコンポーネントを取得
        score_text = score_object.GetComponent<Text>();

        // FPS固定
        Application.targetFrameRate = 60;
    }

    public static void ScoreUpdate()
    {
        score_num += 100; 

        // テキストの表示を入れ替える
        score_text.text = "Score:" + score_num;
    }
}