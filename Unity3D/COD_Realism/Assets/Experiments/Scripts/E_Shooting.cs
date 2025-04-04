using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet_Prefab;

    float bulletForce = 1f;

    [SerializeField] float fireDelay = 0.2f;
    float countDown;
    FloatingJoystick lookJoystick;
    GameObject objLook_Joystick;

    [SerializeField] Transform firePoint;

    private void Start()
    {
        countDown = fireDelay;

        objLook_Joystick = GameObject.FindGameObjectWithTag("Look_Stick") as GameObject;
        lookJoystick = objLook_Joystick.GetComponent<FloatingJoystick>();
    }

    void Update()
    {
        countDown -= 0.05f;
        if (countDown <= 0)
        {
            if (Vector3.Magnitude(new Vector3(lookJoystick.Horizontal, lookJoystick.Vertical)) >= 0.8f)
            {
                Shoot();
                countDown = fireDelay;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bullet_Prefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * bulletForce , ForceMode.Impulse);
    }
}
