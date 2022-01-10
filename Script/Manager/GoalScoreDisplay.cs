using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScoreDisplay : MonoBehaviour
{
    [SerializeField] GameObject goal_score;

    public GameObject score_object = null; // Textオブジェクト
    private static Text score_text;

    void Start()
    {
        // オブジェクトからTextコンポーネントを取得
        score_text = score_object.GetComponent<Text>();
    }

    void Update()
    {
        //[D]キーを押す
        if (PlayerMove.GetGoalFlag())
        {
            //ゲームオブジェクト非表示→表示
            goal_score.SetActive(true);
        }

        // テキストの表示を入れ替える
        score_text.text = "Score:" + GoalScoreManager.GetScore();
    }
}
