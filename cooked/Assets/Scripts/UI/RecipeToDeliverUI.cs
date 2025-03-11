using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeToDeliverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private Transform iconTemplate;

    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    public void SetRecipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;

        foreach(Transform child in iconContainer)
        {
            if(child == iconTemplate) continue;

            Destroy(child.gameObject);
        }

        foreach(var kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            Transform icon = Instantiate(iconTemplate, iconContainer);
            icon.gameObject.SetActive(true);
            icon.GetComponent<Image>().sprite = kitchenObjectSO.icon;
        }
    }
}
