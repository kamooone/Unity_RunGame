using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    //---------------------------------------------------------
    // コンポーネント取得
    //---------------------------------------------------------
    private Animator     animator;

    //---------------------------------------------------------
    // メンバ変数定義
    //---------------------------------------------------------
    private int   direction;
    private bool  jumpFlg;
    private int   rotateCnt;


    //---------------------------------------------------------
    // Start is called before the first frame update
    //---------------------------------------------------------
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = 1;
        jumpFlg = false;
        rotateCnt = 0;

    }

    //---------------------------------------------------------
    // Update is called once per frame
    //---------------------------------------------------------
    void Update()
    {
        if (jumpFlg == false)
        {
            animator.SetBool("dash", true);
        }
        transform.position += new Vector3(PlayerMove.GetDashSpeed() * Time.timeScale, 0, 0);
        if (direction != 1)
        {
            transform.Rotate(0, 180, 0);
        }
        direction = 1;
        if (PlayerMove.GetGameOverFlg())
        {
            animator.SetBool("bullet", true);
            if (rotateCnt < 3)
            {
                transform.position += new Vector3(-0.6f, 0, 0);
            }
            rotateCnt++;
        }
    }
}

