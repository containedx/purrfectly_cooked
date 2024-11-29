using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {

        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();


        inputVector = inputVector.normalized;
        // ciekawostki: 
        // bez normalized ruch po przekatnej bylby szybszy - vector 1,1 jest dluzszy, wiec musimy znormalizowac by zawsze byla ta sama dlugosc

        return inputVector;
    }
}
