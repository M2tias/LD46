using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private Config config;
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Zombie")
        {
            int collisionCount = particleSystem.GetSafeCollisionEventSize();
            ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[collisionCount];
            int eventCount = particleSystem.GetCollisionEvents(other, collisionEvents);
            for (int i = 0; i < eventCount; i++)
            {
                Debug.Log(other.name);
                Zombie z = other.GetComponent<Zombie>();
                z.DealDamage(config.ShotgunDamage);
            }
        }
    }
}
