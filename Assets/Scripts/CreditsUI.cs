using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsUI : MonoBehaviour {

    [SerializeField] private Button BackButton;


    private void Awake() {
        BackButton.onClick.AddListener(() => {

            Loader.Load(Loader.Scene.MainMenuScene);

        });
    }
}