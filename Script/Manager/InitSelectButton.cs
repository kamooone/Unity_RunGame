using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitSelectButton : MonoBehaviour
{
    public Button selectButton;
    // Start is called before the first frame update
    void Start()
    {
        selectButton.onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
