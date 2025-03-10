using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plate : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs 
    {
        public KitchenObjectSO kitchenObjectSO;
    }


    [SerializeField] private List<KitchenObjectSO> recipeIngredients; 
    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!recipeIngredients.Contains(kitchenObjectSO)) return false;

        if(kitchenObjectSOList.Contains(kitchenObjectSO)) return false;

        kitchenObjectSOList.Add(kitchenObjectSO);
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenObjectSO = kitchenObjectSO});


        return true;
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
