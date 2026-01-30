using System;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public static Action<Vector3> Hit_Particles_Event;
    public static Action<Vector3> Capture_Particles_Event;
    public static Action<Vector3> Health_Particles_Event;


    private GameObject Damage_Particle;
    private GameObject Capture_Particle;
    private GameObject Health_Particle;
    private ObjectPoolManager Object_Pool_Manager;

    private void OnEnable()
    {
        Hit_Particles_Event += Hit_Particle_Instantiate;
        Capture_Particles_Event += Capture_Particle_Instantiate;
        Health_Particles_Event += Health_Particle_Instantiate;

    }
    private void OnDisable()
    {
        Hit_Particles_Event -= Hit_Particle_Instantiate;
        Capture_Particles_Event -= Capture_Particle_Instantiate;
        Health_Particles_Event -= Health_Particle_Instantiate;

    }


    private void Start()
    {
        Object_Pool_Manager = ObjectPoolManager.instance;
    }

    private void Hit_Particle_Instantiate(Vector3 Position)
    {

        Damage_Particle = Object_Pool_Manager.Instantiate_Hit_Particle();
        Damage_Particle.transform.SetLocalPositionAndRotation(Position, Quaternion.identity);

        Object_Pool_Manager.Destroy_Hit_Particle(3f, Damage_Particle);
    }

    private void Capture_Particle_Instantiate(Vector3 Position)
    {

        Capture_Particle = Object_Pool_Manager.Instantiate_Capture_Particle();
        Capture_Particle.transform.SetLocalPositionAndRotation(Position, Quaternion.identity);

        Object_Pool_Manager.Destroy_Capture_Particle(3f, Capture_Particle);
    }
    private void Health_Particle_Instantiate(Vector3 Position)
    {

        Health_Particle = Object_Pool_Manager.Instantiate_Health_Particle();
        Health_Particle.transform.SetLocalPositionAndRotation(Position, Quaternion.identity);

        Object_Pool_Manager.Destroy_Health_Particle(3f, Health_Particle);
    }
}
