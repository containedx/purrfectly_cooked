using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        RotationOnly
    }

    [SerializeField] private Mode mode = Mode.LookAtInverted;
    
    private void LateUpdate() // LateUpdate == After the regular Update
    {
        switch(mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                var cameraDir = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + cameraDir);
                break;
            case Mode.RotationOnly:
                var direction = Camera.main.transform.position - transform.position;
                direction.y = 0;
                transform.rotation = Quaternion.LookRotation(direction);
                break;

        }
    }
}
