using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipes;

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
                    
                    var recipe = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    
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

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        if(GetFryingRecipeSOWithInput(input) != null) return true;

        return false;
    }

    private KitchenObjectSO GetFryingRecipeOutput(KitchenObjectSO input)
    {
        var recipe = GetFryingRecipeSOWithInput(input);
        if(recipe != null) return recipe.output;

        return null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(var recipe in fryingRecipes)
        {
            if(recipe.input == input) return recipe;
        }

        return null;
    }
    
}
