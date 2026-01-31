using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera Main_Camera;

    private bool Shooting_Is_Enabled;


    
    private int Revolver_Ammo_Count;
    [Header("Revolver")]
    [SerializeField] private float Max_Revolver_Distance = 10f;
    [SerializeField] private float Revolver_Cooldown = 0.1f;
    [SerializeField] private int Revolver_Max_Ammo_Count = 6;

    
    private int Mask_Rifle_Ammo_Count;
    [Header("Mask Rifle")]
    [SerializeField] private float Max_Mask_Rifle_Distance = 20f;
    [SerializeField] private float Mask_Rifle_Cooldown = 0;
    [SerializeField] private int Mask_Rifle_Max_Ammo_Count = 30;
    [SerializeField] private Transform Mask_Rifle_Shoot_Point;

    
    private int Sanitizer_Grenade_Launcher_Ammo_Count;
    [Header("Sanitizer Grenade Launcher")]
    [SerializeField] private float Max_Sanitizer_Grenade_Launcher_Distance = 5f;
    [SerializeField] private float Sanitizer_Grenade_Launcher_Cooldown = 2f;
    [SerializeField] private int Sanitizer_Grenade_Launcher_Max_Ammo_Count = 6;

    [SerializeField] private GameObject[] Weapons_Array = new GameObject[3];

    public LayerMask Infected;
    public LayerMask Non_Infected;

    private ObjectPoolManager Object_Pool_Manager;
    private GameObject Mask;


    private enum Weapons
    {
        Revolver,
        Mask_Rifle,
        Sanitizer_Grenade_Launcher
    }
    private Weapons Current_Weapon;

    void Start()
    {
        Main_Camera = Camera.main;
        Shooting_Is_Enabled = true;

        Object_Pool_Manager = ObjectPoolManager.instance;
        Initialise_Weapon();
    }
   

    private void Initialise_Weapon()
    {
        Revolver_Ammo_Count = Revolver_Max_Ammo_Count;
        Current_Weapon = Weapons.Mask_Rifle;
        Weapons_Array[(int)Weapons.Mask_Rifle].SetActive(true);

        Mask_Rifle_Ammo_Count = Mask_Rifle_Max_Ammo_Count;

        Sanitizer_Grenade_Launcher_Ammo_Count = Sanitizer_Grenade_Launcher_Max_Ammo_Count;
    }

    private void Shoot()
    {

        if (!Shooting_Is_Enabled)
        {
            return;
        }
        switch (Current_Weapon)
        {
            case Weapons.Revolver:
                Revolver();
                break;

            case Weapons.Mask_Rifle:
                Mask_Rifle();
                break;

            case Weapons.Sanitizer_Grenade_Launcher:
                //Sanitizer_Grenade_Launcher();
                break;
        }


    }
    private void Revolver()
    {
        ///play animation
        RaycastHit hit;
        if (Physics.Raycast(Main_Camera.transform.position, Main_Camera.transform.forward, out hit, Max_Revolver_Distance, Infected))
        {
            Destroy(hit.collider.gameObject);
        }
        StartCoroutine(Put_Shoot_On_Cooldown(Revolver_Cooldown));
        if(--Revolver_Ammo_Count <= 0)
        {
            Weapons_Array[(int)Weapons.Revolver].SetActive(false);
            Weapon_Selector();
        }
        Debug.Log("Ammo - "+ Revolver_Ammo_Count);

    }

    private void Mask_Rifle()
    {
        ///play animation

        //Mask = Object_Pool_Manager.Instantiate_Mask_Projectile_Object();

        Mask.transform.SetPositionAndRotation(Mask_Rifle_Shoot_Point.position, Quaternion.identity);

        StartCoroutine(Put_Shoot_On_Cooldown(Mask_Rifle_Cooldown));

            if (--Mask_Rifle_Ammo_Count < 0)
            {
                Weapons_Array[(int)Weapons.Mask_Rifle].SetActive(false);
                Weapon_Selector();
            }
        Debug.Log("Ammo - " + Mask_Rifle_Ammo_Count);

    }

    private IEnumerator Put_Shoot_On_Cooldown(float CoolDown_Duration)
    {
        Shooting_Is_Enabled = false;
        yield return new WaitForSeconds(CoolDown_Duration);
        Shooting_Is_Enabled = true;
    }

    private void Weapon_Selector()
    {
        int Random = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Weapons)).Length);

        Current_Weapon = (Weapons)Random;
        
        //load animation
        Weapons_Array[Random].SetActive(true);
        
    }

}
