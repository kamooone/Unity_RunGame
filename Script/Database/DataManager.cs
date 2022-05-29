using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class DataManager : MonoBehaviour
{
    public void Save(string value_name, int value_score)
    {
        string name = value_name;
        int score = value_score;
        string jsonString = "[ { \"name\": \"" + name + "\", \"score\": \"" + score + "\" }]";
        StartCoroutine(Post("http://kamooone.sakura.ne.jp/SetRanking.php", jsonString));
    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);
    }
}
