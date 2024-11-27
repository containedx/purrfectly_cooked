using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0f, 0f);

        if( Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1f;
        }

        if( Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1f;
        }

        if( Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1f;
        }

        if(Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1f;
        }

        inputVector = inputVector.normalized;


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);

        // ciekawostki: 
        // bez normalized ruch po przekatnej bylby szybszy - vector 1,1 jest dluzszy, wiec musimy znormalizowac by zawsze byla ta sama dlugosc
        // bez Time.deltaTime player poruszalby sie w roznnej predkosci w roznych FPS
    }
}
