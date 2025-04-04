using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject impact_Effect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            GameObject impact =  Instantiate(impact_Effect, transform.position, transform.rotation);
            Destroy(impact, 2f);
            Destroy(gameObject);
        }
    }
}
