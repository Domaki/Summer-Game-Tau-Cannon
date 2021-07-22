using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToDeal;

    void Start()
    {
        damageToDeal = 3;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<DamageSystem>().TakeDamage(damageToDeal);
        }
        //Destroy(gameObject);
    }
}
