using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private Config config;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (runtime.Cans < config.MaxGasCansCarried)
            {
                runtime.Cans++;
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
