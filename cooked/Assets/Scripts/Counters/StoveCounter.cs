using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoveCounter : BaseCounter, IHasProgress
{
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnStateChangedEventArgs : EventArgs {
        public State state;
    }

    public enum State {
        Idle,
        Frying,
        Fried,
        Burned
    }


    [SerializeField] private FryingRecipeSO[] fryingRecipes;
    [SerializeField] private BurningRecipeSO[] burningRecipes;
    private State _state;
    private State state
    {
        get => _state;
        set
        {
            _state = value;

            OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                state = _state
            });
        }
    }

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

        //Debug.Log(state);

        switch(state)
        {
            case State.Idle:
                break;
            
            case State.Frying:
                timer += Time.deltaTime;
                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                    progressNormalized = timer / recipe.fryingTime
                });
                
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
                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                    progressNormalized = timer / burningRecipe.burningTime
                });

                
                if(timer > burningRecipe.burningTime) // fried
                {
                    timer = 0f;
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(burningRecipe.output, this);
                    state = State.Burned;

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                        progressNormalized = 0f
                    });
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


                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                        progressNormalized = timer / recipe.fryingTime
                    });
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

                OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs{
                    progressNormalized = 0f
                });
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
