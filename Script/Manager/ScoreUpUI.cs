using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpUI : MonoBehaviour
{
    public GameObject score_up_text;
    private bool textDraw_flg;
    private int drawTime;
    public AudioClip score_up;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
        textDraw_flg = false;
        drawTime = 0;
    }

    void Update()
    {
        if(textDraw_flg)
        {
            drawTime++;
        }
        if(drawTime == 30)
        {
            textDraw_flg = false;
            drawTime = 0;
            score_up_text.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "energy")
        {
            audioSource.PlayOneShot(score_up);
            ScoreManager.ScoreUpdate();
            GoalScoreManager.ScoreUpdate();
            textDraw_flg = true;
            score_up_text.SetActive(true);
        }
    }
}
