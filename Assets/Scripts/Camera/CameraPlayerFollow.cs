using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public Transform _lookTarget;
    
    
    [SerializeField] private Vector3 _followOfset;

    private void LateUpdate()
    {
        transform.position = _player.position + _player.forward * _followOfset.z + _player.up * _followOfset.y;
        transform.LookAt(_lookTarget);
    }
}
