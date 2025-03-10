using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private Plate plate;
    [SerializeField] private Transform iconTemplate;

    private void Start()
    {
        iconTemplate.gameObject.SetActive(false);
        plate.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, Plate.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in transform)
        {
            if(child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach( var obj in plate.GetKitchenObjectSOList())
        {
            var icon = Instantiate(iconTemplate, transform);
            icon.gameObject.SetActive(true);
            icon.GetComponent<PlateIngredientIcon>().SetKitchenObjectSO(obj);
        }
    }
}
