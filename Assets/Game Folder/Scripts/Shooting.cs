using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Camera Main_Camera;

    int Pistol_Ammo_Count;
    bool Shooting_Is_Enabled;


    ///Constant Values, Move to Scriptable Object Later
    const float Max_Raycast_Distance = 10f;
    const float Shooting_Cooldown = 0.1f;
    const float Pistol_Reload_Time = 1f;
    const int Pistol_Max_Ammo_Count = 6;


    void Start()
    {
        Main_Camera = Camera.main;
        Shooting_Is_Enabled = true;
    }
    private void OnEnable()
    {
        MouseInputManager.instance.Shoot_Event += Pistol_Shoot;
    }

    private void OnDisable()
    {
        MouseInputManager.instance.Shoot_Event -= Pistol_Shoot;
    }

    private void Pistol_Shoot()
    {

        if (!Shooting_Is_Enabled)
        {
            return;
        }

        ///play animation
        RaycastHit hit;
        if (Physics.Raycast(Main_Camera.transform.position, Main_Camera.transform.forward, out hit, Max_Raycast_Distance, LayerMask.GetMask("NPC"))) 
        {
            ///hit.collider.gameObject.GetComponent<EnemyBehaviour>().Damage();
            Debug.Log("Did Damage");
        }

        //Reload
        if (--Pistol_Ammo_Count <= 0)
        {
            StartCoroutine("Reload_Pistol");
        }
        else
        {
            StartCoroutine("Put_Shoot_On_Cooldown");
        }
        Debug.Log("Ammo - " + Pistol_Ammo_Count);
    }

    IEnumerator Put_Shoot_On_Cooldown()
    {
        Shooting_Is_Enabled = false;
        yield return new WaitForSeconds(Shooting_Cooldown);
        Shooting_Is_Enabled = true;
    }

    IEnumerator Reload_Pistol()
    {
        Shooting_Is_Enabled = false;
        yield return new WaitForSeconds(Pistol_Reload_Time);
        Pistol_Ammo_Count = Pistol_Max_Ammo_Count;
        Shooting_Is_Enabled = true;
        Debug.Log("Ammo - " + Pistol_Ammo_Count);
    }
}
