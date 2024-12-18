using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterAttachPoint;
    private KitchenObject kitchenObject;

    public virtual void Interact(Player player) 
    // abstract  forces implementation on children, virtual - can be, but doesnt have to
    {

    }

    public virtual void InteractAlternate(Player player) 
    {

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
