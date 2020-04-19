using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasCanUI : MonoBehaviour
{
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private Text maxCanText;
    [SerializeField]
    private Text currentCanText;

    // Start is called before the first frame update
    void Start()
    {
        maxCanText.text = config.MaxGasCansCarried.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentCanText.text = runtime.Cans.ToString();
    }
}
