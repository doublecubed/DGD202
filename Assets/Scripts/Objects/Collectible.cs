using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _renderer;
    
    
    [SerializeField] private AudioClip _pickupSound;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Projectile"))
        {
            TurnOffTheObject();
            PlaySound();
            PlayParticles();
            Invoke("DestroyObject", 3f);
        }
    }

    private void TurnOffTheObject()
    {
        _collider.enabled = false;
        _renderer.enabled = false;
    }

    private void PlaySound()
    {
        _audioSource.PlayOneShot(_pickupSound);
    }

    private void PlayParticles()
    {
        _particles.Play();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
