using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVisuals = new List<GameObject>();

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        var plate = Instantiate(plateVisualPrefab, counterTopPoint);
        var plateOffset = 0.1f * plateVisuals.Count;
        plate.localPosition = new Vector3(0, plateOffset, 0);
        plateVisuals.Add(plate.gameObject);
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        var plate = plateVisuals[plateVisuals.Count - 1];
        plateVisuals.Remove(plate);
        Destroy(plate);
    }

}
