﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int _currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = _currentWeapon;

        ProcessScrollWheel();
        ProcessKeyInput();

        if (previousWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentWeapon >= transform.childCount - 1)
            {
                _currentWeapon = 0;
            }

            else
            {
                _currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_currentWeapon <= 0)
            {
                _currentWeapon = transform.childCount - 1;
            }

            else
            {
                _currentWeapon--;
            }
        }


    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentWeapon = 2;
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeapon)
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
