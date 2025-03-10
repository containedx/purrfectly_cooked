using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {get; private set;}


    [SerializeField] private RecipeListSO recipeList;
    private List<RecipeSO> waitingRecipeList = new List<RecipeSO>();

    private float spawnRecipeTimer = 4f;
    private float spawnRecipeFrequency = 4f;
    private int waitingRecipeMax = 5;

    private void Awake()
    {
        Instance = this;
    }


    private void Update()
    {
        if(waitingRecipeMax <= waitingRecipeList.Count) return;

        spawnRecipeTimer += Time.deltaTime;

        if(spawnRecipeTimer >= spawnRecipeFrequency)
        {
            spawnRecipeTimer = 0f;
            SpawnNewRandomRecipe();
        }
    }

    public void DeliverRecipe(Plate plate)
    {
        foreach(var recipe in waitingRecipeList)
        {
            if( recipe.CheckIfPlateHasCorrectIngredients(plate))
            {
                Debug.Log("Delivered " + recipe.recipeName);
                waitingRecipeList.Remove(recipe);
                return;
            }
        }

        Debug.Log("player did not deliver correct recipe");
    }

    private void SpawnNewRandomRecipe()
    {
        var recipe = recipeList.GetRandomRecipe();
        Debug.Log(recipe.recipeName);
        waitingRecipeList.Add(recipe);
    }
}
