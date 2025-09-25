using Unity.Mathematics;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private EnemyManager enemyManager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            muzzleFlash.Play();
        }
    }
    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            enemyManager = hit.transform.GetComponent<EnemyManager>();
            Instantiate(impactEffect, hit.point,Quaternion.LookRotation(hit.normal));


            if (enemyManager != null)
            {
                enemyManager.EnemyTakeDamage(UnityEngine.Random.Range(minDamage, maxDamage));
            }

            
        }
    }

}
