using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {get; private set;}

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;


    [SerializeField] private RecipeListSO recipeList;
    private List<RecipeSO> waitingRecipeList = new List<RecipeSO>();

    private float spawnRecipeTimer = 5f;
    private float spawnRecipeFrequency = 5f;
    private int waitingRecipeMax = 4;

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

    public List<RecipeSO> GetWaitingRecipeList()
    {
        return waitingRecipeList;
    }

    public void DeliverRecipe(Plate plate)
    {
        foreach(var recipe in waitingRecipeList)
        {
            if( recipe.CheckIfPlateHasCorrectIngredients(plate))
            {
                Debug.Log("Delivered " + recipe.recipeName);
                waitingRecipeList.Remove(recipe);

                OnRecipeCompleted?.Invoke(this, EventArgs.Empty);

                return;
            }
        }

        //Debug.Log("player did not deliver correct recipe");
    }

    private void SpawnNewRandomRecipe()
    {
        var recipe = recipeList.GetRandomRecipe();
        Debug.Log(recipe.recipeName);
        waitingRecipeList.Add(recipe);

        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }
}
