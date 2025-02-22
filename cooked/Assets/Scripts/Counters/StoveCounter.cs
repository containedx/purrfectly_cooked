using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    private enum State {
        Idle,
        Frying,
        Fried,
        Burned
    }


    [SerializeField] private FryingRecipeSO[] fryingRecipes;
    [SerializeField] private BurningRecipeSO[] burningRecipes;

    private State state;
    private float timer;
    private FryingRecipeSO recipe;
    private BurningRecipeSO burningRecipe;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if(!HasKitchenObject()) return;

        Debug.Log(state);

        switch(state)
        {
            case State.Idle:
                break;
            
            case State.Frying:
                timer += Time.deltaTime;
                if(timer > recipe.fryingTime) // fried
                {
                    timer = 0f;
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(recipe.output, this);
                    burningRecipe = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    state = State.Fried;
                }
                break;

            case State.Fried:
                timer += Time.deltaTime;
                if(timer > burningRecipe.burningTime) // fried
                {
                    timer = 0f;
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(burningRecipe.output, this);
                    state = State.Burned;
                }
                break;

            case State.Burned:
                break;
        }
    }

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //if player is carrying sth
            if(player.HasKitchenObject())
            {
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) 
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    recipe = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    state = State.Frying;
                    timer = 0f;
                }
            }
        }
        else
        {
            // if player DOESNT have item
            if(!player.HasKitchenObject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
                state = State.Idle;
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        if(GetFryingRecipeSOWithInput(input) != null) return true;

        return false;
    }

    private KitchenObjectSO GetFryingRecipeOutput(KitchenObjectSO input)
    {
        var recipe = GetFryingRecipeSOWithInput(input);
        if(recipe != null) return recipe.output;

        return null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(var recipe in fryingRecipes)
        {
            if(recipe.input == input) return recipe;
        }

        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach(var recipe in burningRecipes)
        {
            if(recipe.input == input) return recipe;
        }

        return null;
    }
    
}
