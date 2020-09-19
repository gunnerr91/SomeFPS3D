using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPSCamera;
    public float range = 100f;
    public float damage = 20f;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public Ammo ammoSlot;
    public AmmoType ammoType;
    public float timeBetweenShots = 0.5f;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out var hit, range))
        {
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, .1f);
            if (hit.transform.name.Contains("Enemy") || hit.transform.name == "EnemyHealth")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
        }
    }
}
