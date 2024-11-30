using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenIngredient : MonoBehaviour
{
    [SerializeField] private KitchenIngredientSO ingredient;

    public KitchenIngredientSO GetKitchenIngredientSO()
    {
        return ingredient;
    }
}
