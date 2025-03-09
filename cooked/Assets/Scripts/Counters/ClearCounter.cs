using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
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
            else
            {
                // if Player has a Plate
                if( player.GetKitchenObject().TryGetPlate(out Plate plate))
                {
                    if( plate.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()) )
                    {
                        GetKitchenObject().DestroySelf();
                    }     
                }
                else // if plate is on the counter
                {
                    if( GetKitchenObject().TryGetPlate(out plate))
                    {
                        if( plate.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()) )
                        {
                            player.GetKitchenObject().DestroySelf();
                        }  
                    }
                }
            }
        }
    }

}
