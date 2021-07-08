using UnityEngine;

public class TauGun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 10f;
    public float forceFactor = 200f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Transform magnetPoint;
    public bool gunPulling;

    public GameObject heldObject;

    void Start(){
        magnetPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //default left click inpput
        if(Input.GetButton("Fire1"))
        {
            Shoot();
            gunPulling = true;
        }
        
        else
        {
            gunPulling = false;
        }

        if(Input.GetButton("Fire2")){

        }
    }


    void Shoot()
    {
        ////muzzleFlash.Play();
        //for raycast
        RaycastHit hit;

        //if raycast hits something
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            //DamageSystem target = hit.transform.GetComponent<DamageSystem>();
            Rigidbody target = hit.rigidbody;

            if(target != null)
            {
                target.AddForce((magnetPoint.position + magnetPoint.transform.forward * 0.5f - target.position + new Vector3(0, 0.9f, 0)).normalized * forceFactor * Time.fixedDeltaTime);
            }


        }
    }

    public void nowHolding(GameObject thing){
        heldObject = thing;
    }
}
