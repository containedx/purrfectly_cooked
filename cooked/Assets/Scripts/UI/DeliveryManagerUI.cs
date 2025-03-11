using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += OnRecipeCompleted;
        UpdateVisual();
    }

    private void OnRecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void OnRecipeCompleted(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if(child == recipeTemplate) continue;

            Destroy(child.gameObject);
        }

        foreach(var recipe in DeliveryManager.Instance.GetWaitingRecipeList() )
        {
            Transform recipeTransform = Instantiate(recipeTemplate, container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<RecipeToDeliverUI>().SetRecipeSO(recipe);
        }
    }
}
