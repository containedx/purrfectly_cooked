using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //if player is carrying sth
            if(player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            // if player DOESNT have item
            if(!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player) 
    {
        if(HasKitchenObject())
        {
            GetKitchenObject().DestroySelf();

            Transform kitchenObjectSpawn = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectSpawn.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}
