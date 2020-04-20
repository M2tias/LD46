using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscToQuitUI : MonoBehaviour
{
    private float waitForEsc = 2;
    private float pressedEscTime = 0;
    private bool pressedEsc = false;
    [SerializeField]
    private Text quitText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer) return;

        bool pressedThisFrame = Input.GetKeyDown(KeyCode.Escape);
        if(!pressedEsc && pressedThisFrame)
        {
            quitText.gameObject.SetActive(true);
            pressedEscTime = Time.time;
            pressedEsc = true;
        }
        else if(pressedEsc && pressedThisFrame)
        {
            Application.Quit();
        }

        if(Time.time - pressedEscTime > waitForEsc && pressedEsc)
        {
            pressedEsc = false;
            quitText.gameObject.SetActive(false);
        }
    }
}
