using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasMeterUI : MonoBehaviour
{
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private Image meterFill;

    void Start()
    {
        updateFillAmount();
    }

    void Update()
    {
        updateFillAmount();
    }

    private void updateFillAmount()
    {
        float current = Mathf.Clamp(runtime.Gas, 0, config.MaxGasInTank);
        float fillAmount = current / config.MaxGasInTank;
        meterFill.fillAmount = fillAmount;
    }
}
