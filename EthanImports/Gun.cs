using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        //default left click inpput
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        //for raycast
        RaycastHit hit;

        //if raycast hits something
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            DamageSystem target = hit.transform.GetComponent<DamageSystem>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
