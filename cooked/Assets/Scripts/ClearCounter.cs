using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenIngredientSO ingredient;
    [SerializeField] private Transform counterAttachPoint;

    public void Interact()
    {
        Debug.Log("Interact " + transform);

        Transform tomato = Instantiate(ingredient.prefab, counterAttachPoint);
        tomato.localPosition = Vector3.zero;
    }
}
