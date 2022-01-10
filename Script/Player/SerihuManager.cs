using UnityEngine;

public class SerihuManager : MonoBehaviour
{
	public AudioClip message;
	AudioSource audioSource;

	// 画面が止まるタイプのチュートリアルオブジェクト
	public GameObject stopObj;
	public GameObject stopObj1;
	public GameObject stopObj2;

	// 吹き出しオブジェクトとセリフ
	public GameObject fukidashi;
	public GameObject[] serihu = new GameObject[17];

	// 現在のセリフナンバー
	private int serifuNum;

	// セリフ表示フラグ
	private bool serihuFlg;

	// 止まるタイプセリフフラグ
	private static bool stopFlg;

	// Use this for initialization
	void Start()
	{
		//Componentを取得
		audioSource = GetComponent<AudioSource>();
		serifuNum = 0;
		serihuFlg = false;
		stopFlg = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(stopFlg == true)
        {
			// アイテム削除
			if (serifuNum == 11)
			{
				Destroy(stopObj);
			}
			if (serifuNum == 12)
			{
				Destroy(stopObj1);
			}
			if (serifuNum == 14)
			{
				Destroy(stopObj2);
			}

			Time.timeScale = 0;

			if ((JumpButton.GetJumpStart() || JumpButton.GetRotateFlg()) && (serifuNum == 11 || serifuNum == 12))
			{
				Time.timeScale = 1;
				stopFlg = false;
			}
			if (BulletButton.GetBulletStart() && serifuNum == 14)
			{
				Time.timeScale = 1;
				stopFlg = false;
			}
		}
	}

	//---------------------------------------------------------
	// 当たり判定
	//---------------------------------------------------------
	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "serihu" && serihuFlg == false)
		{
			audioSource.PlayOneShot(message);
			serihuFlg = true;
			fukidashi.SetActive(true);
			serihu[serifuNum].SetActive(true);
		}

		if (collision.gameObject.tag == "stop")
		{
			stopFlg = true;
		}
	}

	//離れたオブジェクトが引数otherとして渡される
	void OnTriggerExit2D(Collider2D collision)
	{
		//離れたオブジェクトのタグが"Player"のとき
		if (collision.CompareTag("serihu") && serihuFlg == true)
		{
			fukidashi.SetActive(false);
			serihu[serifuNum].SetActive(false);
			serihuFlg = false;
			serifuNum++;
		}
	}

	//---------------------------------------------------------
	// 当たり判定
	//---------------------------------------------------------
	public static bool GetStopFlg()
	{
		return stopFlg;
	}
}
