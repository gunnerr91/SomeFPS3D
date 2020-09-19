using UnityEngine;

public class WeaponsSwitcher : MonoBehaviour
{
    public int currentWeaponIndex = 0;

    void Start()
    {
        SetActiveWeapon();
    }
    void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeaponIndex >= transform.childCount - 1)
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeaponIndex <= 0)
            {
                currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currentWeaponIndex--;
            }
        }

        if (previousWeaponIndex != currentWeaponIndex)
        {
            SetActiveWeapon();
        }
    }

    private void SetActiveWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

}
