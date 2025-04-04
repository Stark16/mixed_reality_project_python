using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
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

        
    }

    void Update()
    {
        objLook_Joystick = GameObject.FindGameObjectWithTag("Look_Stick") as GameObject;
        lookJoystick = objLook_Joystick.GetComponent<FloatingJoystick>();
        countDown -= 0.05f;
        if (countDown <= 0)
        {
            if (Vector3.Magnitude(new Vector3(lookJoystick.Horizontal, lookJoystick.Vertical)) >= 0.4f)
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
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
