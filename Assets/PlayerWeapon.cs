﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private PlayerWeaponController playerWeaponController;
    private PlayerController playerController;
    private int weaponDamage;

    private void Start()
    {
        playerWeaponController = GetComponentInParent<PlayerWeaponController>();
        weaponDamage = playerWeaponController.GetWeaponDamage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(this.tag == "OrangeWeapon" && other.tag == "OrangeBullet" || this.tag == "BlueWeapon" && other.tag == "BlueBullet")
        {
            other.SendMessage("GetHit", weaponDamage * 2);
        }
        if ((this.tag == "BlueWeapon" && other.tag == "OrangeBullet") || (this.tag == "OrangeWeapon" && other.tag == "BlueBullet") || other.tag == "Enemy" || other.tag == "ChargedBullet")
        {
            Debug.Log(other.tag + " Got Hit");
            other.SendMessage("GetHit", weaponDamage);

            if(other.tag == "ChargedBullet")
            {
                playerController.GetCharge();
            }

        }
    }
}