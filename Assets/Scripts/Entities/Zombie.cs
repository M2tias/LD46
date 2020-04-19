using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float angle;

    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 5)]
    public float radius = 10;

    [SerializeField]
    private Config config;
    [SerializeField]
    private List<AudioClip> growls;
    [SerializeField]
    private AudioClip hitSound;

    private Player player;
    private Car car;
    private AudioSource audio;
    private LineRenderer line;
    private Rigidbody body;
    private Vector3 movement = Vector3.zero;
    private float currentHP;
    private bool isActive = false;
    private float timeActivated = 0;
    private Activator activator;
    private float timeHit = 0;
    private float timeSound = 0;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(-180f, 180f);
        line = gameObject.GetComponent<LineRenderer>();
        body = gameObject.GetComponent<Rigidbody>();
        audio = gameObject.GetComponent<AudioSource>();
        player = GameManager.main.GetPlayer();
        car = GameManager.main.GetCar();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        line.widthMultiplier = 0.05f;
        CreatePoints();

        currentHP = config.ZombieMaxHP;
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * config.ZombieHitRange;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * config.ZombieHitRange;

            line.SetPosition(i, new Vector3(x, 1.1f, y));

            angle += (360f / segments);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (!audio.isPlaying && Time.time - timeSound > config.ZombieSoundDelay && playerDistance < config.ZombieSoundRange)
        {
            timeSound = Time.time;
            float r = Random.value;
            if (r <= config.ZombieSoundChance)
            {
                int sound = Random.Range(0, growls.Count);
                audio.clip = growls[sound];
                audio.volume = config.NormalVolume;
                audio.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float carDistance = Vector3.Distance(transform.position, car.transform.position);
        if (!isActive)
        {
            if (playerDistance <= config.ZombiePlayerActivationRange)
            {
                activator = Activator.Player;
                timeActivated = Time.fixedTime;
                isActive = true;
            }
            else if(player.GetShoot() && playerDistance <= config.ZombieShootingActivationRange)
            {
                activator = Activator.Shooting;
                timeActivated = Time.fixedTime;
                isActive = true;
            }
            else if(car.GetPlayerInCar() && carDistance <= config.ZombieCarActivationRange)
            {
                activator = Activator.Car;
                timeActivated = Time.fixedTime;
                isActive = true;
            }

        }

        // zombies run after player in the activation range, but run "longer" if other things triggered it
        if (isActive || playerDistance <= config.ZombiePlayerActivationRange)
        {
            float angleRad = Mathf.Atan2(player.transform.position.z - transform.position.z, player.transform.position.x - transform.position.x);
            angle = (180 / Mathf.PI) * angleRad - 90;
            movement = (player.transform.position - transform.position).normalized * config.ZombieSpeed * Time.fixedDeltaTime;
            body.velocity = movement;
        }
        else
        {
            movement = movement * 0.99f;
            body.velocity = movement;
        }

        if(activator == Activator.Car && Time.fixedTime - timeActivated > config.ZombieCarActivationTimeout)
        {
            isActive = false;
        }
        else if (activator == Activator.Shooting && Time.fixedTime - timeActivated > config.ZombieShootingActivationTimeout)
        {
            isActive = false;
        }

        if(playerDistance <= config.ZombieHitRange && Time.fixedTime - timeHit > config.ZombieHitDelay)
        {
            player.DealDamage(config.ZombieHitDamage);
            timeHit = Time.fixedTime;
            audio.clip = hitSound;
            audio.volume = config.NormalVolume;
            audio.Play();
        }

        body.transform.rotation = Quaternion.Euler(0, -angle, 0);
    }

    public void DealDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    enum Activator
    {
        Player,
        Car,
        Shooting
    }
}
