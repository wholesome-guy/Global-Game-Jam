using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPoolManager : MonoBehaviour
{
    #region Singleton Pattern
    public static ObjectPoolManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public enum Scene
    {
        Main_Menu,
            Game
    }

    public Scene Current_Scene;

    private void Start()
    {
        if(Current_Scene == Scene.Game)
        {
            //Preload_Game();
        }
    }

    

    #region Sound Effects Object
    [SerializeField] private GameObject Sound_Effects_Object;
    private Queue<GameObject> Sound_Effects_Object_Pool = new Queue<GameObject>();
    private int Sound_Effects_Pool_Count;

    [SerializeField] private int Sound_Effects_PreLoad_Count = 10;

    private void Preload_Sound_Effects_Object()
    {
        for (int i = 0; i < Sound_Effects_PreLoad_Count; i++)
        {
            GameObject Object = Instantiate(Sound_Effects_Object);
            Object.SetActive(false);
            Sound_Effects_Object_Pool.Enqueue(Object);
        }
    }

    public GameObject Instantiate_Sound_Effects_Object()
    {
        Sound_Effects_Pool_Count = Sound_Effects_Object_Pool.Count;
        if (Sound_Effects_Pool_Count > 0)
        {
            GameObject Object = Sound_Effects_Object_Pool.Dequeue();
            Object.SetActive(true);
            return Object;
        }
        return Instantiate(Sound_Effects_Object);
    }

    public void Destroy_Sound_Effects_Object(float Wait_Duration, GameObject Object)
    {
        StartCoroutine(Delay_Destroy_Sound_Effects_Object(Wait_Duration, Object));
    }

    private IEnumerator Delay_Destroy_Sound_Effects_Object(float Wait_Duration, GameObject Object)
    {
        yield return new WaitForSeconds(Wait_Duration);

        Object.SetActive(false);
        Sound_Effects_Object_Pool.Enqueue(Object);
    }
    #endregion

    #region Hit Particle
    [SerializeField] private GameObject Hit_Particle_VFX;
    private Queue<GameObject> Hit_Particle_VFX_Pool = new Queue<GameObject>();
    private int Hit_Particle_Pool_Count;

    [SerializeField] private int Hit_Particle_PreLoad_Count = 10;
    private void Preload_Hit_Particle()
    {
        for (int i = 0; i < Hit_Particle_PreLoad_Count; i++)
        {
            GameObject Object = Instantiate(Hit_Particle_VFX);
            Object.SetActive(false);
            Hit_Particle_VFX_Pool.Enqueue(Object);
        }
    }
    public GameObject Instantiate_Hit_Particle()
    {
        Hit_Particle_Pool_Count = Hit_Particle_VFX_Pool.Count;
        if (Hit_Particle_Pool_Count > 0)
        {
            GameObject Object = Hit_Particle_VFX_Pool.Dequeue();
            Object.SetActive(true);
            return Object;
        }
        return Instantiate(Hit_Particle_VFX);
    }

    public void Destroy_Hit_Particle(float Wait_Duration, GameObject Object)
    {
        StartCoroutine(Delay_Destroy_Hit_Particle(Wait_Duration, Object));
    }

    private IEnumerator Delay_Destroy_Hit_Particle(float Wait_Duration, GameObject Object)
    {
        yield return new WaitForSeconds(Wait_Duration);

        Object.SetActive(false);
        Hit_Particle_VFX_Pool.Enqueue(Object);
    }
    #endregion

    #region Capture Particle
    [SerializeField] private GameObject Capture_Particle_VFX;
    private Queue<GameObject> Capture_Particle_VFX_Pool = new Queue<GameObject>();
    private int Capture_Particle_Pool_Count;

    [SerializeField] private int Capture_Particle_PreLoad_Count = 10;
    private void Preload_Capture_Particle()
    {
        for (int i = 0; i < Capture_Particle_PreLoad_Count; i++)
        {
            GameObject Object = Instantiate(Capture_Particle_VFX);
            Object.SetActive(false);
            Capture_Particle_VFX_Pool.Enqueue(Object);
        }
    }

    public GameObject Instantiate_Capture_Particle()
    {
        Capture_Particle_Pool_Count = Capture_Particle_VFX_Pool.Count;
        if (Capture_Particle_Pool_Count > 0)
        {
            GameObject Object = Capture_Particle_VFX_Pool.Dequeue();
            Object.SetActive(true);
            return Object;
        }
        return Instantiate(Capture_Particle_VFX);
    }

    public void Destroy_Capture_Particle(float Wait_Duration, GameObject Object)
    {
        StartCoroutine(Delay_Destroy_Capture_Particle(Wait_Duration, Object));
    }

    private IEnumerator Delay_Destroy_Capture_Particle(float Wait_Duration, GameObject Object)
    {
        yield return new WaitForSeconds(Wait_Duration);

        Object.SetActive(false);
        Capture_Particle_VFX_Pool.Enqueue(Object);
    }
    #endregion

    #region Health Particle
    [SerializeField] private GameObject Health_Particle_VFX;
    private Queue<GameObject> Health_Particle_VFX_Pool = new Queue<GameObject>();
    private int Health_Particle_Pool_Count;

    [SerializeField] private int Health_Particle_PreLoad_Count = 10;

    private void Preload_Health_Particle()
    {
        for (int i = 0; i < Health_Particle_PreLoad_Count; i++)
        {
            GameObject Object = Instantiate(Health_Particle_VFX);
            Object.SetActive(false);
            Health_Particle_VFX_Pool.Enqueue(Object);
        }
    }

    public GameObject Instantiate_Health_Particle()
    {
        Health_Particle_Pool_Count = Health_Particle_VFX_Pool.Count;
        if (Health_Particle_Pool_Count > 0)
        {
            GameObject Object = Health_Particle_VFX_Pool.Dequeue();
            Object.SetActive(true);
            return Object;
        }
        return Instantiate(Health_Particle_VFX);
    }

    public void Destroy_Health_Particle(float Wait_Duration, GameObject Object)
    {
        StartCoroutine(Delay_Destroy_Health_Particle(Wait_Duration, Object));
    }

    private IEnumerator Delay_Destroy_Health_Particle(float Wait_Duration, GameObject Object)
    {
        yield return new WaitForSeconds(Wait_Duration);

        Object.SetActive(false);
        Health_Particle_VFX_Pool.Enqueue(Object);
    }
    #endregion

}
