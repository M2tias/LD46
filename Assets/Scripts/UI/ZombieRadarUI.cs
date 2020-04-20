using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieRadarUI : MonoBehaviour
{
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private Text zombieWaveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombieWaveText.text = ((int)Mathf.Round(runtime.ZombieWaveDistance)).ToString() + "m";
        if(runtime.ZombieWaveDistance < 100)
        {
            zombieWaveText.color = Color.red;
        }
    }
}
