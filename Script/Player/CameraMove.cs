using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private int rotateCnt;

    // Start is called before the first frame update
    void Start()
    {
        rotateCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(PlayerMove.GetDashSpeed(), 0, 0);
       
        if (PlayerMove.GetGameOverFlg())
        {
            if (rotateCnt < 3)
            {
                transform.position += new Vector3(-0.6f * Time.timeScale, 0, 0);
            }
            rotateCnt++;
        }
    }
}
