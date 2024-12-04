using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter counter)
    {
        if(counter.HasKitchenObject())
        {
            Debug.LogError("Counter already has object ");
            return;
        }

        if(this.clearCounter != null) this.clearCounter.ClearKitchenObject();
        this.clearCounter = counter;

        counter.SetKitchenObject(this);
        transform.parent = counter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
