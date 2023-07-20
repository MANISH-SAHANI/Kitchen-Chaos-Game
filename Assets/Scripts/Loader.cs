using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader {

    public enum Scene {
        MainMenuScene,
        GameScene,
        LoadingScene,
        CreditsScene
    }

    private static Scene targetScene;

    public static void Load(Scene targetScence) {
        Loader.targetScene = targetScence;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }

    public static void LoaderCallBack() {
        SceneManager.LoadScene(targetScene.ToString());
    }
}