using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static SoundScript Inst;

    AudioSource myaudio;

    public AudioClip ShootingEnemy;
    public AudioClip EnemyDie;
    public AudioClip Turret;
    public AudioClip Alarm;
    public AudioClip HurtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (Inst == null)
            Inst = this;

        myaudio = gameObject.AddComponent<AudioSource>();
    }

    public void Shooting()
    {
        myaudio.PlayOneShot(ShootingEnemy);
    }

    public void Die()
    {
        myaudio.PlayOneShot(EnemyDie);
    }

    public void Explaning()
    {
        myaudio.PlayOneShot(Alarm);
    }

    public void Hurt()
    {
        myaudio.PlayOneShot(HurtPlayer);
    }

    public void SetTurret()
    {
        myaudio.PlayOneShot(Turret);
    }
}
