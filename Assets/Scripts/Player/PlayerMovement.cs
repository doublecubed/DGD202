using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES

    public float Speed;

    [SerializeField] private Vector2 _inputVector;
    [SerializeField] private Vector3 _movementVector;

    #endregion

    #region MONOBEHAVIOUR

    private void Update()
    {
        GetInput();
        GenerateMovementVector();
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

    private void GenerateMovementVector()
    {
        _movementVector = new Vector3(_inputVector.x, 0f, _inputVector.y);
    }

    private void MoveCharacter()
    {
        transform.position += _movementVector * Speed * Time.deltaTime;
    }

    #endregion
}
