using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;

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
            Debug.Log("Player ray cast hit with: " + hit.transform.name);

            if (hit.transform.name == "Enemy" || hit.transform.name == "EnemyHealth")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("name of raycast object: " + hit.transform.name);
            }
        }
    }
}
