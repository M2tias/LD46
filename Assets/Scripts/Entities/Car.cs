using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private AudioClip idle;
    [SerializeField]
    private AudioClip running;

    private bool carRunning = false;
    private bool carStarted = false;
    private bool isAtDoor = false;
    [SerializeField]
    private bool playerInCar = false;

    private Rigidbody body;
    private AudioSource audioSource;

    void Start()
    {
        player = GameManager.main.GetPlayer();
        player.transform.parent = null;
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInCar)
            {
                playerInCar = false;
            }
            else if (isAtDoor)
            {
                playerInCar = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (runtime.Cans > 0)
            {
                runtime.Cans--;
                runtime.Gas = Mathf.Clamp(runtime.Gas + config.GasInACan, runtime.Gas, config.MaxGasInTank);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 p = transform.position;
        if (playerInCar)
        {
            if (carStarted == false)
            {
                // some monologue here
                carStarted = true;
                carRunning = true;
            }

            player.transform.parent = transform;
            player.gameObject.SetActive(false);
            player.transform.position = new Vector3(p.x, player.transform.position.y, p.z);
            if (runtime.Gas > 0)
            {
                if (audioSource.volume != config.NormalVolume)
                {
                    audioSource.volume = config.NormalVolume;
                    audioSource.clip = running;
                    audioSource.Play();
                }
                body.velocity = new Vector3(config.CarSpeed * Time.fixedDeltaTime, 0, 0);
                runtime.Gas -= config.RunningCarGasConsumption * Time.fixedDeltaTime;
            }
            else
            {
                carRunning = false;
                runtime.Gas = 0;
            }
        }
        else
        {
            if (carRunning)
            {
                if (audioSource.volume != config.LesserVolume)
                {
                    audioSource.volume = config.LesserVolume;
                    audioSource.clip = idle;
                    audioSource.Play();
                }
                runtime.Gas = runtime.Gas - config.IdleCarGasConsumption * Time.fixedDeltaTime;
            }
            if (player.transform.parent != null)
            {
                player.transform.parent = null;
                player.gameObject.SetActive(true);
                player.transform.position = new Vector3(p.x, player.transform.position.y, p.z - 3);
            }

            body.velocity = Vector3.zero;
        }

        if ((!carRunning || runtime.Gas <= 0) && carStarted == true)
        {
            carRunning = false;
            playerInCar = false;
            // game over
            Debug.Log("Game over!");
        }
    }

    public void SetAtDoor(bool atDoor)
    {
        isAtDoor = atDoor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombie")
        {
            if (playerInCar && runtime.Gas > 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public bool GetPlayerInCar()
    {
        return playerInCar;
    }
}
