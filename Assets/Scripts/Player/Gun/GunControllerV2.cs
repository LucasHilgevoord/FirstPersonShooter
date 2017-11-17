using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControllerV2 : MonoBehaviour
{

    private AudioSource audio;
    public AudioClip ShootSound;
    private Animation GunRecoil;

    public ParticleSystem MuzzleFlash;

    public float CoolDown = 0.2f;
    public float CoolDownTimer;

    public float range = 100f;
    public float damage = 10f;
    public float ImpactForce = 40f;
    public Camera PlayerCam;

    public GameObject WoodImpact;
    public GameObject StoneImpact;
    public GameObject ZombieImpact;


    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        GunRecoil = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoolDownTimer > 0)
        {
            CoolDownTimer -= Time.deltaTime;
        }   

        if (CoolDownTimer < 0)
        {
            CoolDownTimer = 0;
        }  

        if (Input.GetMouseButton(0) && CoolDownTimer == 0)
        {
            CoolDownTimer = CoolDown;

            Shoot();
        }

    }

    void Shoot()
    {
        GunRecoil.Play();
        audio.Play();
        MuzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyHealthManagerV2 target = hit.transform.GetComponent<EnemyHealthManagerV2>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            if (hit.transform.tag == "Tree")
            {
                GameObject ImpactWood = Instantiate(WoodImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(ImpactWood, 2f);
            }

            if (hit.transform.tag == "Enemy")
            {
                GameObject ImpactZombie = Instantiate(ZombieImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(ImpactZombie, 2f);
            }

            if (hit.transform.tag == "Ground")
            {
                GameObject ImpactStone = Instantiate(StoneImpact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(ImpactStone, 2f);
            }
        }
    }
}    