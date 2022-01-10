using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System;

[Serializable]
public class Json_File
{
    public MonsterInfo[] players;
}

[Serializable]
public class MonsterInfo
{
    public string name;
    public string score;
}

public class RankingManager : MonoBehaviour
{
    private const int MAXGETRANKING = 5;
    private int number = 0;

    // テキストコンポーネント取得用
    public GameObject[] score_component = new GameObject[MAXGETRANKING];
    public GameObject[] name_component = new GameObject[MAXGETRANKING];

    // コンポーネントからテキスト取得用
    public Text[] ranking_text = new Text[MAXGETRANKING];
    public Text[] name_text = new Text[MAXGETRANKING];


    // 初期化
    void Start()
    {
        StartCoroutine(Get("APIURL"));

        number = 0;
        for (int i = 0; i < MAXGETRANKING; i++)
        {
            // オブジェクトからTextを取得
            ranking_text[i] = score_component[i].GetComponent<Text>();
            name_text[i] = name_component[i].GetComponent<Text>();
        }
    }

    public IEnumerator Get(string url)
    {
        Debug.Log("GET");

        var request = new UnityWebRequest();
        request.downloadHandler = new DownloadHandlerBuffer();
        request.url = url;
        request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        request.method = UnityWebRequest.kHttpVerbGET;
        yield return request.Send();

        if (request.isNetworkError)
        {
            //Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // WebAPIで取得した文字列の先頭と末尾を削除する。(unityは配列で始まるJSONを扱えないため)
                string getStr = request.downloadHandler.text;

                // 先頭と末尾に文字挿入
                getStr = getStr.Insert(0, "{\"players\":");
                getStr = getStr.Insert(getStr.Length, "}");

                //Debug.Log("先頭と末尾の文字を削除できたか確認");
                Debug.Log(getStr);

                Json_File json_File = JsonUtility.FromJson<Json_File>(getStr);

                foreach (MonsterInfo tmp_Monster in json_File.players)
                {
                    //Debug.Log(tmp_Monster.name);
                    //Debug.Log(tmp_Monster.score);
                    name_text[number].text = tmp_Monster.name;
                    ranking_text[number].text = tmp_Monster.score;
                    if (number < MAXGETRANKING)
                    {
                        if (number != 4)
                        {
                            number++;
                        }
                    }
                    if (number == 4)
                    {
                        break;
                    }
                }
            }
            else
            {
                //Debug.Log("failed");
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}