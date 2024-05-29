using System;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    
    [SerializeField] private int _collectedSpheres;

    private void Start()
    {
        _counter.text = "0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            IncreaseCounter();
        }
    }

    public void IncreaseCounter()
    {
        _collectedSpheres++;
        _counter.text = _collectedSpheres.ToString();        
    }
}
