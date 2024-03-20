using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    #region VARIABLES

    public float Speed;

    private float _moveDirection;

    #endregion

    #region MONOBEHAVIOUR

    private void Update()
    {
        GetInput();
        SetCharacterFacing();
        MoveCharacter();
    }

    #endregion

    #region METHODS

    private void GetInput()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal");
    }

    private void SetCharacterFacing()
    {
        if (_moveDirection < 0)
        {
            transform.right = Vector3.left;
        }
        else if (_moveDirection > 0)
        {
            transform.right = Vector3.right;
        }
    }

    private void MoveCharacter()
    {
        transform.position += Vector3.right * Speed * _moveDirection * Time.deltaTime;
    }

    #endregion

}
