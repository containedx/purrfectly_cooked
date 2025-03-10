using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject 
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private Plate plate;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList = new List<KitchenObjectSO_GameObject>();

    private void Start()
    {
        plate.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach(var obj in kitchenObjectSOGameObjectList)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, Plate.OnIngredientAddedEventArgs e)
    {
        foreach(var obj in kitchenObjectSOGameObjectList)
        {
            if(obj.kitchenObjectSO == e.kitchenObjectSO)
            {
                obj.gameObject.SetActive(true);
            }
        }
    }
}
