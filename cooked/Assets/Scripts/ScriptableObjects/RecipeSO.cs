using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> kitchenObjectSOList;
    public string recipeName;

    public bool CheckIfPlateHasCorrectIngredients(Plate plate)
    {
        if(kitchenObjectSOList.Count == plate.GetKitchenObjectSOList().Count)
        {
            foreach(var ingredient in kitchenObjectSOList)
            {
                bool ingredientFound = false;
                foreach(var plateIngredient in plate.GetKitchenObjectSOList())
                {
                    if(ingredient == plateIngredient)
                    {
                        ingredientFound = true;
                        break;
                    }
                }

                if(!ingredientFound) return false;
            }

            return true;
        }

        return false;
    }
}
