using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStop : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Component‚ðŽæ“¾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.GetGoalFlag())
        {
            audioSource.Stop();
        }
    }
}
