using System;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    #region VARIABLES

    public float carSpeed;

    #endregion


    #region MONOBEHAVIOUR

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        MoveCar();
        CheckCarGas();
        CheckPassengers();
    }



    #endregion

    #region METHODS

    private void MoveCar()
    {
        transform.position += new Vector3(0f, 0f, carSpeed * Time.deltaTime);
    }

    private void CheckPassengers()
    {
        throw new NotImplementedException();
    }

    private void CheckCarGas()
    {
        throw new NotImplementedException();
    }

    #endregion

}
