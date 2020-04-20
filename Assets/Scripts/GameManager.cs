using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Car car;
    [SerializeField]
    private GameObject UI;

    public static GameManager main;

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        runtime.Cans = config.StartCans;
        runtime.Gas = config.StartGas;
        runtime.PlayerHP = config.StartPlayerHP;
        runtime.ZombieWaveDistance = config.StartZombieWaveDistance;
        UI.SetActive(true);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float carCoef = car.GetPlayerInCar() ? -0.5f : 1f;
        runtime.ZombieWaveDistance -= config.ZombieWaveSpeed * carCoef * Time.fixedDeltaTime;
        if(runtime.ZombieWaveDistance <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(runtime.PlayerHP <= 0)
        {
            SceneManager.LoadScene("GameOverHitToDeath");
        }
    }

    public Player GetPlayer()
    {
        return player;
    }

    public Car GetCar()
    {
        return car;
    }
}
