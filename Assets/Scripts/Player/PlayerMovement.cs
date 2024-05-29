// This script moves the player. It displaces the transform for movement. It does not use rigidody

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region REFERENCES

    private Rigidbody _rb;
    private Animator _animator;

    #endregion

    #region VARIABLES
    
    public float Speed;
    public float RotationSpeed;

    [SerializeField] private Vector2 _inputVector;
    [SerializeField] private Vector3 _movementVector;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        GetInput();
        RotateCharacter();
        AnimateCharacter();
        MoveCharacter();
    }

    #endregion

    #region METHODS

    private void GetInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        _inputVector = new Vector2(horizontalInput, verticalInput);
    }

    private void AnimateCharacter()
    {
        _animator.SetBool("running", _inputVector.y != 0);
        _animator.SetFloat("runDirection", _inputVector.y > 0 ? 1f : -1f);
        
        // THE BLOCK BELOW IS THE LONG VERSION OF THE CODE ABOVE
        // if (_inputVector.y > 0)
        // {
        //     _animator.SetBool("running", true);
        //     _animator.SetFloat("runDirection", 1f);
        // }
        // else if (_inputVector.y < 0)
        // {
        //     _animator.SetBool("running", true);
        //     _animator.SetFloat("runDirection", -1f);
        // } else
        // {
        //     _animator.SetBool("running", false);
        // }
    }
    
    private void RotateCharacter()
    {
        transform.rotation *= Quaternion.Euler(new Vector3(0f, _inputVector.x * RotationSpeed * Time.deltaTime, 0f));
    }

    private void MoveCharacter()
    {
        _rb.velocity = transform.forward * Speed * _inputVector.y;
    }

    #endregion
}
