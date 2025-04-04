using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Control_2 : MonoBehaviour
{
    GameObject Soldier;
    RaycastHit hit;
    float distance;
    Vector3 lastValidPos;

    Rigidbody rb;

    [SerializeField] GameObject jet_Effects;
    GameObject jet;

    public bool grounded;
    float jetFuel;
    public bool jetpack_Active;
    void Start()
    {
        Soldier = GameObject.FindGameObjectWithTag("Player");      
        rb = Soldier.GetComponent<Rigidbody>();
        jetFuel = 90f;
        //jetpack_Active = false;
    }

    
    void FixedUpdate()
    {
        if (Physics.Raycast(Soldier.transform.position, -Vector3.up, out hit))
        {
            lastValidPos = hit.transform.position;
            //Debug.Log(hit.collider.gameObject.tag);

            //Debug.Log(hit.distance);
            if (hit.collider.gameObject.tag == "Ground")
            {
                if (hit.distance <= 0.1)
                {
                    Debug.Log("On Ground");
                    grounded = true;
                    jetpack_Active = false;
                    jetFuel = 90f;
                }

                else if (hit.distance > 0.1)
                {
                    Debug.Log("In Air");
                    grounded = false;
                }
            }

            else if (hit.collider.tag == "null") 
            {
                Debug.Log("WE In The Void BOII");
            }
            
        }

        else 
        {
            Debug.Log("WE In The Void BOII");
            //Soldier.transform.position = new Vector3(lastValidPos.x, lastValidPos.y + 0.5f, lastValidPos.y);
            Soldier.transform.position = new Vector3(0f, 0.5f, 0f);
        }
        jetPack_Controller();
    }

    void jetPack_Controller()
    {
        if (jetpack_Active && jetFuel >=0)
        {
            Debug.Log("We Flyin BOI" + jetFuel);
            rb.AddForce(new Vector3(0, 20f, 0) * Time.deltaTime, ForceMode.Impulse);
            jetFuel--;
        }
    }

    public void onPress()
    {
        if (grounded == false)
        {
            jetpack_Active = true;
            jet = Instantiate(jet_Effects, Soldier.transform.position, Soldier.transform.rotation);
            //Debug.Log("Pressed" + jetpack_Active);           
        }
    }

    public void onRelease()
    {
        jetpack_Active = false;
        Destroy(jet, 0.5f);
        //Debug.Log("Released" + jetpack_Active);
    }

    public void E_jump()
    {
        if (grounded)
        {
            //Debug.Log("I Jumped Once");
            rb.AddForce(new Vector3(0, 400f * Time.deltaTime, 0) , ForceMode.Impulse);
        }

/*        else if (grounded == false && jetFuel >= 0)
        {
            Debug.Log("Jet_Pack Activated");
            rb.AddForce(new Vector3(0, 300f, 0) * Time.deltaTime, ForceMode.Impulse);
            jetFuel--;
        }*/
    }

}