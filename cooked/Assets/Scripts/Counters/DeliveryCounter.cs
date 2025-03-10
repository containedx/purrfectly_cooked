using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            // if player has a plate 
            if( player.GetKitchenObject().TryGetPlate(out Plate plate))
            {
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
    
}
