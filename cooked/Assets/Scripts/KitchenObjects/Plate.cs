using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> recipeIngredients; 
    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!recipeIngredients.Contains(kitchenObjectSO)) return false;

        if(kitchenObjectSOList.Contains(kitchenObjectSO)) return false;

        kitchenObjectSOList.Add(kitchenObjectSO);
        return true;
    }
}
