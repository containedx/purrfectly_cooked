using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayClick);

        quitButton.onClick.AddListener(() => 
        {
            Application.Quit();
        });
    }

    private void OnPlayClick()
    {
        Loader.Load(Loader.Scene.GameScene);
    }
}
