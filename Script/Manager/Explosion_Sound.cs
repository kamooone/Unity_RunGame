using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Sound : MonoBehaviour
{
    public AudioClip explosion;
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
        if(Collision.GetExplosionFlg())
        {
            audioSource.PlayOneShot(explosion);
            Collision.SetExplosionFlg(false);
        }

        if (Enemy_Die.GetExplosionFlg())
        {
            audioSource.PlayOneShot(explosion);
            Enemy_Die.SetExplosionFlg(false);
        }
    }
}
