using UnityEngine;
using UnityEngine.UI;

public class BulletButton : MonoBehaviour
{
    private static bool bulletStart;
    private Button bulletButton;
    // Start is called before the first frame update
    void Start()
    {
        bulletButton = GetComponent<Button>();
        bulletButton.onClick.AddListener(OnClickButton);
        bulletStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            bulletStart = true;
        }
    }

    public void OnClickButton()
    {
        bulletStart = true;
    }

    public static bool GetBulletStart()
    {
        return bulletStart;
    }
    public static void SetBulletStart(bool setBulletStart)
    {
        bulletStart = setBulletStart;
    }
}
