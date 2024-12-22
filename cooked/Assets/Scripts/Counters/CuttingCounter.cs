using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter
{
    public event EventHandler OnCut;
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs : EventArgs {
        public float progressNormalized;
    }
    [SerializeField] private CuttingRecipeSO[] cuttingRecipes;

    private int cuttingProgress = 0;
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
                    cuttingProgress = 0;
                    var recipe = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                        progressNormalized = (float)cuttingProgress / recipe.cuttingNeeded
                    });
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

            cuttingProgress++;
            var recipe = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            OnCut?.Invoke(this, EventArgs.Empty);
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                progressNormalized = (float)cuttingProgress / recipe.cuttingNeeded
            });

            if(cuttingProgress >= recipe.cuttingNeeded)
            {
                // finished cutting
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        if(GetCuttingRecipeSOWithInput(input) != null) return true;

        return false;
    }

    private KitchenObjectSO GetCuttingRecipeOutput(KitchenObjectSO input)
    {
        var recipe = GetCuttingRecipeSOWithInput(input);
        if(recipe != null) return recipe.output;

        return null;
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(var recipe in cuttingRecipes)
        {
            if(recipe.input == input) return recipe;
        }

        return null;
    }
}
