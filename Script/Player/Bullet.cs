using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject prefab;
    private int bulletInterval;
    private static bool bulletFlg;
    public AudioClip bullet;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        bulletInterval = 30;
        bulletFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletButton.GetBulletStart() && bulletFlg == false && !PlayerMove.GetGameOverFlg())
        {
            bulletFlg = true;
            audioSource.PlayOneShot(bullet);
        }

        if(bulletFlg == true)
        {
            if (bulletInterval == 2)
            {
                //弾を出現させる位置を取得
                Vector3 placePosition = this.transform.position;
                //出現させる位置をずらす値
                Vector3 offsetGun = new Vector3(1.0f, 0.3f, 0);


                //弾を出現させる位置を調整
                placePosition = offsetGun + placePosition;
                //弾生成！
                Instantiate(prefab, placePosition, Quaternion.identity);
            }

            bulletInterval--;
            BulletButton.SetBulletStart(false);

            if (bulletInterval == 0)
            {
                bulletFlg = false;
                bulletInterval = 10;
            }
        }
    }

    public static void SetBulletFlg(bool setBulletFlg)
    {
        bulletFlg = setBulletFlg;
    }
    public static bool GetBulletFlg()
    {
        return bulletFlg;
    }
}
