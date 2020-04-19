using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Player GetPlayer()
    {
        return player;
    }

    public Car GetCar()
    {
        return car;
    }
}
