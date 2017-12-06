using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class HealthManager : Photon.MonoBehaviour, IPunObservable
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed;
    private float health;
    bool isDeath = false;
    private Animator _animator;
    private Collider Collider1;
  


    void Start()
    {
        _animator = GetComponent<Animator>();
        healthBar.value = 1;
        health = 1;
        print(healthBar.value);
        Collider1 = GetComponent<Collider>();
    }
    
    void Update()
    {
        healthBar.value = health;
        if (health <= 0 && !isDeath)
        {
            Death();
        }
    }
    void Death()
    {
        _animator.Play("Death");
        _animator.SetTrigger("Death");
        Destroy(Collider1.gameObject);
        print("Player is Dead");
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals("Beam"))
        {
            print("TRIGGERSTAY: " + health);
            health -= .01f;
        }
    }

    void IPunObservable.OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) 
    {
        if (stream.isWriting) {
            stream.SendNext (health);
        } else {
            health = (float)stream.ReceiveNext ();
        }
    }    
}
