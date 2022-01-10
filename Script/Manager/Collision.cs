using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    // 爆発オブジェクト
    public GameObject prefab;

    private static bool explosionFlg;
    private int explosionTime;

    // Start is called before the first frame update
    void Start()
    {
        explosionFlg = false;
        explosionTime = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        if (explosionFlg == true)
        {
            explosionTime++;
        }
        if(explosionTime >= 13)
        {
            // エネミー＆爆発削除
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            // エネミー削除
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            ScoreManager.ScoreUpdate();
            GoalScoreManager.ScoreUpdate();

            // 爆発描画
            explosionFlg = true;

            //爆発を出現させる位置を取得
            Vector3 placePosition = this.transform.position;
            //出現させる位置をずらす値
            Vector3 offsetGun = new Vector3(0.0f, 0, 0);

            //爆発を出現させる位置を調整
            placePosition = offsetGun + placePosition;
            //爆発生成！
            Instantiate(prefab, placePosition, Quaternion.identity);

            // 弾削除
            Destroy(collision.gameObject);

            // エネミーの座標を画面外に
            this.transform.position += new Vector3(5000.0f, 5000.0f, 5000.0f);
        }
    }

    public static void SetExplosionFlg(bool setExplosionFlg)
    {
        explosionFlg = setExplosionFlg;
    }
    public static bool GetExplosionFlg()
    {
        return explosionFlg;
    }
}
