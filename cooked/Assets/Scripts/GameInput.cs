using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += InteractPerformed;
    }

    private void InteractPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
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
