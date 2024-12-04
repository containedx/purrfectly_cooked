using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterAttachPoint;

    private KitchenObject kitchenObject;

    public void Interact()
    {
        Debug.Log("Interact " + transform);

        if(kitchenObject == null)
        {
            Transform kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab, counterAttachPoint);
            kitchenObjectSpawn.GetComponent<KitchenObject>().SetClearCounter(this);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterAttachPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
