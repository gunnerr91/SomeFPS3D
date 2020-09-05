using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out var hit, range))
        {
            PlayMuzzleFlash();
            ProcessRayCast();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out var hit, range))
        {
            if (hit.transform.name == "Enemy" || hit.transform.name == "EnemyHealth")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
        }
    }
}
