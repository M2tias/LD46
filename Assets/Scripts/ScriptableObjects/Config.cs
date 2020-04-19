using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config ", menuName = "ScriptableObjects/New Config")]
public class Config : ScriptableObject
{
    [SerializeField]
    private float gasInACan;
    public float GasInACan { get { return gasInACan; } }

    [SerializeField]
    private float maxGasInTank;
    public float MaxGasInTank { get { return maxGasInTank; } }

    [SerializeField]
    private int maxGasCansCarried;
    public int MaxGasCansCarried { get { return maxGasCansCarried; } }

    [SerializeField]
    private float playerSpeed;
    public float PlayerSpeed { get { return playerSpeed; } }

    [SerializeField]
    private float zombieSpeed;
    public float ZombieSpeed { get { return zombieSpeed; } }

    [SerializeField]
    private float zombieWaveSpeed;
    public float ZombieWaveSpeed { get { return zombieWaveSpeed; } }

    [SerializeField]
    private float carSpeed;
    public float CarSpeed { get { return carSpeed; } }

    [SerializeField]
    private float runningCarGasConsumption;
    public float RunningCarGasConsumption { get { return runningCarGasConsumption; } }

    [SerializeField]
    private float idleCarGasConsumption;
    public float IdleCarGasConsumption { get { return idleCarGasConsumption; } }

    [SerializeField]
    private float playerMaxHP;
    public float PlayerMaxHP { get { return playerMaxHP; } }

    [SerializeField]
    private float zombieMaxHP;
    public float ZombieMaxHP { get { return zombieMaxHP; } }

    [SerializeField]
    private float shotgunDamage;
    public float ShotgunDamage { get { return shotgunDamage; } }

    [SerializeField]
    private float zombieHitDamage;
    public float ZombieHitDamage { get { return zombieHitDamage; } }

    [SerializeField]
    private float startGas;
    public float StartGas { get { return startGas; } }

    [SerializeField]
    private float startZombieWaveDistance;
    public float StartZombieWaveDistance { get { return startZombieWaveDistance; } }

    [SerializeField]
    private int startCans;
    public int StartCans { get { return startCans; } }

    [SerializeField]
    private float startPlayerHP;
    public float StartPlayerHP { get { return startPlayerHP; } }

    [SerializeField]
    private float shootDelay;
    public float ShootDelay { get { return shootDelay; } }

    [SerializeField]
    private float normalVolume;
    public float NormalVolume { get { return normalVolume; } }

    [SerializeField]
    private float lesserVolume;
    public float LesserVolume { get { return lesserVolume; } }

    [SerializeField]
    private float zombieSoundChance;
    public float ZombieSoundChance { get { return zombieSoundChance; } }

    [SerializeField]
    private float zombieSoundRange;
    public float ZombieSoundRange { get { return zombieSoundRange; } }

    [SerializeField]
    private float zombieSoundDelay;
    public float ZombieSoundDelay { get { return zombieSoundDelay; } }


    [SerializeField]
    private float zombiePlayerActivationRange;
    public float ZombiePlayerActivationRange { get { return zombiePlayerActivationRange; } }

    [SerializeField]
    private float zombieCarActivationRange;
    public float ZombieCarActivationRange { get { return zombieCarActivationRange; } }

    [SerializeField]
    private float zombieCarActivationTimeout;
    public float ZombieCarActivationTimeout { get { return zombieCarActivationTimeout; } }

    [SerializeField]
    private float zombieShootingActivationRange;
    public float ZombieShootingActivationRange { get { return zombieShootingActivationRange; } }

    [SerializeField]
    private float zombieShootingActivationTimeout;
    public float ZombieShootingActivationTimeout { get { return zombieShootingActivationTimeout; } }

    [SerializeField]
    private float zombieHitRange;
    public float ZombieHitRange { get { return zombieHitRange; } }

    [SerializeField]
    private float zombieHitDelay;
    public float ZombieHitDelay { get { return zombieHitDelay; } }
}
