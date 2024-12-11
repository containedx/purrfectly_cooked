using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kOParent)
    {
        if(kOParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has object ");
            return;
        }

        if(this.kitchenObjectParent != null) this.kitchenObjectParent.ClearKitchenObject();
        this.kitchenObjectParent = kOParent;

        kOParent.SetKitchenObject(this);
        transform.parent = kOParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
