using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipes;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //if player is carrying sth
            if(player.HasKitchenObject())
            {
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) 
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
            var cutKitchenObjectSO = GetCuttingRecipeOutput(GetKitchenObject().GetKitchenObjectSO());
            if(cutKitchenObjectSO == null) return;

            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        if(GetCuttingRecipeOutput(input) != null) return true;

        return false;
    }

    private KitchenObjectSO GetCuttingRecipeOutput(KitchenObjectSO input)
    {
        foreach(var recipe in cuttingRecipes)
        {
            if(recipe.input == input) return recipe.output;
        }

        return null;
    }
}
