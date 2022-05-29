using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFielsManager : MonoBehaviour
{
  //InputFieldを格納するための変数
    InputField inputField;

    public GameObject DataManager;

    private string username;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        inputField = GameObject.Find("InputField").GetComponent<InputField>();

        DataManager = GameObject.Find("DataManager");

        username = "";
        score = 0;
    }
 
 
    //入力された名前情報を読み取ってコンソールに出力する関数
    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        username = inputField.text;

        // score取得
        score = GoalScoreManager.GetScore();

        // DB登録
        DataManager.GetComponent<DataManager>().Save(username, score);
 
        //入力フォームのテキストを空にする
        inputField.text = "";

        //　セレクト画面に遷移
        SceneManager.LoadScene("SelectScene");
    }
}
