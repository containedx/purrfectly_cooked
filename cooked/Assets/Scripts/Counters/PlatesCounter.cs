using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer = 3.9f;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnedAmount = 0;
    private int platesSpawnedAmountMax = 4;


    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if(platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount ++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(player.HasKitchenObject()) return;
        if(platesSpawnedAmount < 1) return;

        platesSpawnedAmount--;
        KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }
    
}
