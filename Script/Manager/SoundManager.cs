using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip decision;
    AudioSource audioSource;

    public bool DontDestroyEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    public void SE_Decision()
    {
        //音(sound1)を鳴らす
        audioSource.PlayOneShot(decision);
    }
}