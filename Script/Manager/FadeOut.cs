using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    private float speed = 0.05f;//透明化の速さ
    private float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    private float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    // Start is called before the first frame update
    void Start()
    {
        red = 0.0f;
        green = 0.0f;
        blue = 0.0f;
        alfa = 0.0f;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }

    // Update is called once per frame
    void Update()
    {
        if (G_Manager.instance.GetTitleFlg())
        {
            if (alfa <= 1.0f)
            {
                alfa += speed;
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
            }
            if (alfa >= 1.0f)
            {
                G_Manager.instance.SetTitleFlg(false);
                SceneManager.LoadScene("SelectScene");
            }
        }

        if (G_Manager.instance.GetSelectFlg() && G_Manager.nowSelectGameStage != 0)
        {
            if (alfa <= 1.0f)
            {
                alfa += speed;
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
            }
            if (alfa >= 1.0f)
            {
                if (G_Manager.nowSelectGameStage == 1)
                {
                    G_Manager.instance.SetSelectFlg(false);
                    SceneManager.LoadScene("GameScene");
                }

                if (G_Manager.nowSelectGameStage == 2)
                {
                    G_Manager.instance.SetSelectFlg(false);
                    SceneManager.LoadScene("GameScene2");
                }

                if (G_Manager.nowSelectGameStage == 3)
                {
                    G_Manager.instance.SetSelectFlg(false);
                    SceneManager.LoadScene("GameScene3");
                }
            }
        }
    }
}
