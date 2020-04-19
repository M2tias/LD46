using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private List<Sprite> hpIcons;
    [SerializeField]
    private Image icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentHP = (int)Mathf.Clamp(Mathf.Round(runtime.PlayerHP), 0, 10);
        icon.sprite = hpIcons[currentHP];
    }
}
