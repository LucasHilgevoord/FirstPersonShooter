using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    private int damageToGive = 1;

    private float CoolDown = 2.0f;
    private float CoolDownTimer;
    private float MaxCoolDown = 2.0f;

    private AudioSource audio;
    public AudioClip HurtSound;


    void Start ()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (CoolDownTimer > 0)
        {
            CoolDown -= Time.deltaTime;
        }

        if (CoolDown < 0)
        {
            CoolDownTimer = 0;
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && CoolDownTimer == 0)
        {
            CoolDownTimer = MaxCoolDown;
            CoolDown = MaxCoolDown;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            audio.Play();
        }
    }

}
