using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeValues ", menuName = "ScriptableObjects/New RuntimeValues")]
public class RuntimeValues : ScriptableObject
{
    // how much in car
    [SerializeField]
    private float gas;
    public float Gas { get { return gas; } set { gas = value; } }

    [SerializeField]
    private float zombieWaveDistance;
    public float ZombieWaveDistance { get { return zombieWaveDistance; } set { zombieWaveDistance = value; } }

    // how many cans being carried
    [SerializeField]
    private int cans;
    public int Cans { get { return cans; } set { cans = value; } }

    [SerializeField]
    private float playerHP;
    public float PlayerHP { get { return playerHP; } set { playerHP = value; } }
}

