using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        Transform kitchenObjectSpawn = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectSpawn.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}
