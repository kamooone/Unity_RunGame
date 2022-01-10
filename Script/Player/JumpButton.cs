using UnityEngine;
using UnityEngine.UI;


public class JumpButton : MonoBehaviour
{
    //---------------------------------------------------------
    // コンポーネント取得
    //---------------------------------------------------------
    private Button  jumpButton;

    //---------------------------------------------------------
    // メンバ変数定義
    //---------------------------------------------------------
    private static bool    jumpStart;
    private static bool    rotateFlg;


    //---------------------------------------------------------
    // Start is called before the first frame update
    //---------------------------------------------------------
    void Start()
    {
        jumpButton = GetComponent<Button>();
        jumpButton.onClick.AddListener(OnClickButton);
        jumpStart = false;
    }

    //---------------------------------------------------------
    // Update is called once per frame
    //---------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpStart = true;
            rotateFlg = false;
        }
    }

    //---------------------------------------------------------
    // ボタンクリック処理
    //---------------------------------------------------------
    public void OnClickButton()
    {
        if (!PlayerMove.GetJumpFlg())
        {
            jumpStart = true;
        }

        if (PlayerMove.GetJumpFlg() && rotateFlg == false)
        {
            rotateFlg = true;
        }
    }

    //---------------------------------------------------------
    // セッター＆ゲッター
    //---------------------------------------------------------
    //---------------------
    // ジャンプフラグ
    //---------------------
    public static bool GetJumpStart()
    {
        return jumpStart;
    }
    public static void SetJumpStart(bool setJumpStart)
    {
        jumpStart = setJumpStart;
    }

    //---------------------
    // プレイヤー回転フラグ
    //---------------------
    public static bool GetRotateFlg()
    {
        return rotateFlg;
    }
    public static void SetRotateFlg(bool setRotateFlg)
    {
        rotateFlg = setRotateFlg;
    }
}
