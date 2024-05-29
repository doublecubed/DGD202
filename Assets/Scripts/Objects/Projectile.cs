using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
    #region REFERENCES
    
    public Rigidbody rb;
    public Collider collider;
    public AudioSource audioSource;

    public PlayerInventory inventoryScript;
    
    #endregion
    
    #region VARIABLES
    
    public float speed;
    public float bounceForce;
    public bool alreadyHit;
    public float selfDestructTime;
    public float bounceForceCoefficient;
    
    #endregion
    
    #region AUDIO CLIPS
    
    [Space(10)] 
    public AudioClip hitWood;
    public AudioClip hitMetal;
    public AudioClip hitGlass;
    public AudioClip hitGeneric;
    
    #endregion
    
    #region MONOBEHAVIOUR
    
    private void Start()
    {
        rb.velocity = transform.forward * speed;
        Invoke("DestroyYourself", selfDestructTime);

        bounceForce = speed * bounceForceCoefficient;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (alreadyHit) return;
        
        alreadyHit = true;
        
        PlaySound(other);

        HandleSelfMovement();
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            inventoryScript.IncreaseCounter();
        }
    }

    #endregion
    
    #region METHODS
    
    #region Exposed
    
    public void SetSpeed(float value)
    {
        speed = value;
        bounceForce = speed * bounceForceCoefficient;
    }
    
    #endregion
    
    #region Internal
    
    private void SetRigidbodyConstraints()
    {
        rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
    }

    private void PlaySound(Collision other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            audioSource.clip = hitGlass;
        } else if (other.gameObject.CompareTag("Metal"))
        {
            audioSource.clip = hitMetal;
        } else if (other.gameObject.CompareTag("Wood"))
        {
            audioSource.clip = hitWood;
        }
        else
        {
            audioSource.clip = hitGeneric;
        }
        
        audioSource.Play();
    }

    private void HandleSelfMovement()
    {
        SetRigidbodyConstraints();
        rb.useGravity = true;
        Vector3 randomVector = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f), Random.Range(-1f, 1f))
            .normalized;
        rb.AddForce(randomVector * bounceForce);
    }

    private void DestroyYourself()
    {
        Destroy(gameObject);
    }

    #endregion
    
    #endregion
}
