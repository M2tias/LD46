using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            int nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
