using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    //---------------------------------------------------------
    // コンポーネント取得
    //---------------------------------------------------------
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject shadow;
    public AudioClip jump;
    public AudioClip die;
    public AudioClip clear;
    AudioSource audioSource;

    //---------------------------------------------------------
    // メンバ変数定義
    //---------------------------------------------------------
    private int direction;       // プレイヤーの向き
    private float Jumppower;       // ジャンプ力
    private bool doubleJumpFlg;   // 二段ジャンプフラグ
    private float rotate;          // 衝突時の倒れる際の回転
    private int rotateCnt;       // 倒れる時の回転する回数

    private static bool grounded;        // 地面に着地判定
    private static bool gameOverFlg;     // ゲームオーバーフラグ
    private static bool gameOver;        // ゲームオーバーフラグ
    private static bool jumpFlg;         // プレイヤージャンプフラグ
    private static float dashSpeed;       // プレイヤーの速さ
    private static float energyLife; // energyアイテム初期値
    private static float maxEnergyLife = 1.0f; // energyアイテム最大値
    private static float player_pos_x;
    private static bool goalFlag;
    private static bool goal;
    private static int goal_drawTime;
    private static int result_drawTime;

    protected static EnergyGauge energyGauge;

    public enum ACTION_STATE
    {
        RUN,
        JUMP,
        DOUBLEJUMP,
        BULLET,
        GAMEOVER
    }
    // プレイヤー初期行動状態
    public static ACTION_STATE action_state = ACTION_STATE.RUN;

    //---------------------------------------------------------
    // Start is called before the first frame update
    //---------------------------------------------------------
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = 1;
        dashSpeed = 0.06f;
        Jumppower = 1000.0f;
        jumpFlg = false;
        doubleJumpFlg = false;
        rotate = 30.0f;
        rotateCnt = 0;
        gameOverFlg = false;
        gameOver = false;
        result_drawTime = 0;
        energyLife = 0.0f;

        // energyゲージ
        energyGauge = GameObject.FindObjectOfType<EnergyGauge>();
        energyGauge.SetPlayer(this);
        Damage(0.0f);

        goalFlag = false;
        goal = false;
        goal_drawTime = 0;
        action_state = ACTION_STATE.RUN;
    }

    //---------------------------------------------------------
    // Update is called once per frame
    //---------------------------------------------------------
    void Update()
    {
        if (!gameOverFlg && !goalFlag)
        {
            // ジャンプモーション
            if (grounded && Time.timeScale != 0f)
            {
                if (JumpButton.GetJumpStart() && !jumpFlg)
                {
                    action_state = ACTION_STATE.JUMP;
                }
            }
            if (jumpFlg == true && !JumpButton.GetRotateFlg())
            {
                animator.SetBool("move", false);
                animator.SetBool("dash", false);
                animator.SetBool("jump", true);
            }

            // 二段ジャンプ
            if (JumpButton.GetRotateFlg() && jumpFlg && !doubleJumpFlg)
            {
                action_state = ACTION_STATE.DOUBLEJUMP;
            }

            // 弾発射
            if (Bullet.GetBulletFlg())
            {
                action_state = ACTION_STATE.BULLET;
            }
        }
        // ゲームオーバー時モーション
        else if (grounded && !goalFlag)
        {
            action_state = ACTION_STATE.GAMEOVER;
            if(result_drawTime > 100)
            {
                gameOver = true;
            }
            result_drawTime++;
        }
        // ゲームクリア時
        else if (goalFlag)
        {
            dashSpeed = 0.0f;
            if (goal_drawTime > 100 && !goal)
            {
                goal = true;
                audioSource.PlayOneShot(clear);
            }
            goal_drawTime++;
        }

        PlayerAction();
    }


    //---------------------------------------------------------
    // プレイヤー行動状態
    //---------------------------------------------------------
    void PlayerAction()
    {
        transform.position += new Vector3(dashSpeed * Time.timeScale, 0, 0);
        player_pos_x = transform.position.x;

        switch (action_state)
        {
            // ダッシュ時
            case ACTION_STATE.RUN:

                animator.SetBool("bullet", false);
                animator.SetBool("dash", true);
                break;


            // ジャンプ時
            case ACTION_STATE.JUMP:

                audioSource.PlayOneShot(jump);
                grounded = false;
                jumpFlg = true;
                JumpButton.SetJumpStart(false);
                rb.AddForce(Vector3.up * Jumppower);
                break;


            // 二段ジャンプ時
            case ACTION_STATE.DOUBLEJUMP:

                // 速度をクリアして2回目のジャンプも1回目と同じ挙動にする。
                audioSource.PlayOneShot(jump);
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * (Jumppower - 50.0f));
                doubleJumpFlg = true;
                break;


            // 弾発射時
            case ACTION_STATE.BULLET:

                animator.SetBool("bullet", true);
                animator.SetBool("dash", false);
                break;


            // ゲームオーバー時
            case ACTION_STATE.GAMEOVER:

                animator.SetBool("bullet", true);
                if (rotateCnt < 15)
                {
                    transform.position += new Vector3(-0.2f, 0, 0);
                    transform.Rotate(0, 0, 0 - rotate);
                }
                rotateCnt++;
                break;
        }

        Rotate();
        action_state = ACTION_STATE.RUN;
    }

    //---------------------------------------------------------
    // 二段ジャンプ時の回転
    //---------------------------------------------------------
    void Rotate()
    {
        if (JumpButton.GetRotateFlg() && doubleJumpFlg)
        {
            animator.SetBool("jump", false);
            animator.SetBool("d_Jump", true);

            if (rotateCnt < 12)
            {
                transform.Rotate(0, 0, 0 + rotate);
            }
            if (rotateCnt >= 12)
            {

            }
            rotateCnt++;
        }
        if (direction != 1)
        {
            transform.Rotate(0, 180, 0);
        }
        direction = 1;
    }

    //---------------------------------------------------------
    // 当たり判定
    //---------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ground1")
        {
            grounded = true;
            jumpFlg = false;
            JumpButton.SetRotateFlg(false);
            doubleJumpFlg = false;

            if (!gameOverFlg)
            {
                animator.SetBool("jump", false);
                animator.SetBool("d_Jump", false);
                animator.SetBool("bullet", true);
                rotateCnt = 0;
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            // 影表示
            shadow.SetActive(true);
        }

        if (collision.gameObject.tag == "Ground1")
        {
            // 影非表示
            shadow.SetActive(false);
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Die_Collision")
        {
            audioSource.PlayOneShot(die);
            dashSpeed = 0.0f;
            gameOverFlg = true;
            animator.SetBool("dash", false);
            animator.SetBool("jump", false);
            animator.SetBool("d_Jump", false);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            goalFlag = true;
        }
    }


    //---------------------------------------------------------
    // セッター / ゲッター
    //---------------------------------------------------------

    //---------------------
    // スピード
    //---------------------
    public static float GetDashSpeed()
    {
        return dashSpeed * Time.timeScale;
    }
    public static void SetDashSpeed(float setDashSpeed)
    {
        dashSpeed = setDashSpeed * Time.timeScale;
    }

    //---------------------
    // ゲームオーバーフラグ
    //---------------------
    public static bool GetGameOverFlg()
    {
        return gameOver;
    }
    public static void SetGameOverFlg(bool setGameOverFlg)
    {
        gameOver = setGameOverFlg;
    }

    //---------------------
    // ジャンプフラグ
    //---------------------
    public static bool GetJumpFlg()
    {
        return jumpFlg;
    }
    public static void SetJumpFlg(bool setJumpFlg)
    {
        jumpFlg = setJumpFlg;
    }

    //---------------------
    // ダメージ
    //---------------------
    public static void Damage(float power)
    {
        energyGauge.GaugeReduction(power);
        energyLife += power;
    }

    //---------------------
    // ダメージ
    //---------------------
    public static float GetPlayer_Pos_X()
    {
        return player_pos_x;
    }

    //---------------------
    // 地面着地判定
    //---------------------
    public static bool Ground()
    {
        return grounded;
    }

    //---------------------
    // energyアイテム
    //---------------------
    public static float GetEnergyLife()
    {
        return energyLife;
    }
    public static float GetMaxEnergyLife()
    {
        return maxEnergyLife;
    }

    //---------------------
    // ゴールフラグ
    //---------------------
    public static bool GetGoalFlag()
    {
        return goal;
    }
}
