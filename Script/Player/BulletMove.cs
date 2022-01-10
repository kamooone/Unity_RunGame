using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float speedY = 0.2f;

   
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedY, 0, 0);
    }
}
