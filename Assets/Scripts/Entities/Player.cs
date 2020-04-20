using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody body;
    [SerializeField]
    private Config config;
    [SerializeField]
    private RuntimeValues runtime;
    [SerializeField]
    private ParticleSystem shotgunParticles;
    private Animator animator;
    private AudioSource audio;

    private float vertical = 0;
    private float horizontal = 0;
    private bool shoot = false;
    private float lastShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(vertical) > 0 || Mathf.Abs(horizontal) > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 moveVert = Vector3.forward * vertical * Time.fixedDeltaTime * config.PlayerSpeed;
        Vector3 moveHori = Vector3.right * horizontal * Time.fixedDeltaTime * config.PlayerSpeed;
        Vector2 movement = new Vector3(horizontal, vertical).normalized * Time.fixedDeltaTime * config.PlayerSpeed;
        Vector3 pos = body.position;

        // //TODO: rotation speed?
        // TODO: up is up on screen etc. mouse rotates player, doesn't affect movement

        // this creates a horizontal plane passing through this object's center
        Plane plane = new Plane(Vector3.up, transform.position);

        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            Vector3 hitPoint = ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
            Debug.DrawLine(hitPoint, hitPoint + Vector3.up * 10, Color.red);

            float angleRad = Mathf.Atan2(hitPoint.z - transform.position.z, hitPoint.x - transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90;
            this.transform.rotation = Quaternion.Euler(0, -angleDeg, 0);
        }

        if (shoot && (Time.time - lastShot < config.ShootDelay))
        {
            shoot = false;
        }

        if (shoot && (Time.time - lastShot >= config.ShootDelay))
        {
            ParticleSystem.EmissionModule emission = shotgunParticles.emission;
            emission.enabled = true;
            shotgunParticles.Play();
            shoot = false;
            lastShot = Time.time;
            audio.Play();
        }
        else
        {
            ParticleSystem.EmissionModule emission = shotgunParticles.emission;
            emission.enabled = false;
            /*shotgunParticles.Stop();*/
        }

        body.velocity = moveVert + moveHori;
        //body.velocity = transform.forward * movement.y
        //    + transform.right * movement.x;//new Vector3(movement.x, 0, movement.y);
    }

    public bool GetShoot()
    {
        return shoot;
    }

    public void DealDamage(float damage)
    {
        runtime.PlayerHP -= damage;
    }
}
