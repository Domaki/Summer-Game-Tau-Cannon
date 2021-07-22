using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableController : MonoBehaviour
{

    public GameObject       gun;
    public bool             stuck;

    Rigidbody               rigidbod;

    // Start is called before the first frame update
    void Start()
    {
        rigidbod = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (stuck == true) {
            // transform.position = gun.transform.position + gun.transform.forward * 2.0f;
            transform.position = gun.transform.position + gun.transform.forward * (1.5f + 0.55f * transform.localScale.z);
            transform.rotation = gun.transform.rotation;
        }
        // find way to turn on gravity when pulling but not stuck
    }


    public void StickTo()
    {
        stuck = true;
    }


    public void PushOff()
    {
        stuck = false;
    }


    public void gravityOff()
    {
        rigidbod.useGravity = false;
    }


    public void gravityOn()
    {
        rigidbod.useGravity = true;
    }


    // NEED TO make sure collisions only checked during pulling
    void OnCollisionEnter(Collision collision){
        if ((collision.gameObject.tag == "Gun" || collision.gameObject.tag == "Player") && gun.GetComponent<TauGun>().heldObject == null && gun.GetComponent<TauGun>().isPulling == true)
        {
            stuck = true;
            //Debug.Log("penis");
            gun.GetComponent<TauGun>().nowHolding(gameObject);
        }
    }
}
