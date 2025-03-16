using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioSFXSO sfxData;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    public void PlayFootstepSound(Vector3 position, float volume)
    {
        PlaySound(sfxData.footstep, position, volume);
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, System.EventArgs e)
    {
        TrashCounter counterObject = sender as TrashCounter;
        var pos = counterObject.transform.position;
        PlaySound(sfxData.trash, pos);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, System.EventArgs e)
    {
        BaseCounter counterObject = sender as BaseCounter;
        var pos = counterObject.transform.position;
        PlaySound(sfxData.objectDrop, pos);
    }

    private void Player_OnPickedSomething(object sender, System.EventArgs e)
    {
        var pos = Player.Instance.transform.position;
        PlaySound(sfxData.objectPickup, pos);
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounterObject = sender as CuttingCounter;
        var pos = cuttingCounterObject.transform.position;
        PlaySound(sfxData.chop, pos);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        var pos = DeliveryCounter.Instance.transform.position;
        PlaySound(sfxData.deliverySuccess, pos);
    }

    private void DeliveryManager_OnRecipeFail(object sender, System.EventArgs e)
    {
        var pos = DeliveryCounter.Instance.transform.position;
        PlaySound(sfxData.deliveryFail, pos);
    }

    private void PlaySound(AudioClip[] audioClips, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClips[Random.Range(0, audioClips.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
