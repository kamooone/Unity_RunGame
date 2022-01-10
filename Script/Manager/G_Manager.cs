using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class G_Manager : MonoBehaviour
{
    public static G_Manager instance = null;

    private static bool titleFlg = false;
    private static bool selectFlg = false;


    private void Awake()
    {
        // シングルトン設計
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // 既にインスタンスを生成していた場合破棄することで常に1つにする。
            Destroy(this.gameObject);
        }
    }


    public void SetTitleFlg_False()
    {
        titleFlg = false;
    }
    public void SetTitleFlg_True()
    {
        titleFlg = true;
    }

    public void SetSelectFlg_False()
    {
        selectFlg = false;
    }
    public void SetSelectFlg_True()
    {
        selectFlg = true;
    }




    public void SetTitleFlg(bool setTitleFlg)
    {
        titleFlg = setTitleFlg;
    }
    public bool GetTitleFlg()
    {
        return titleFlg;
    }


    public void SetSelectFlg(bool setSelectFlg)
    {
        selectFlg = setSelectFlg;
    }
    public bool GetSelectFlg()
    {
        return selectFlg;
    }




    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

}