using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour {

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeComplete;
    public event EventHandler OnRecipeSucess;
    public event EventHandler OnRecipeFailed;

    public static DeliveryManager Instance { get; private set; }



    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipeMax = 4;
    private int successfulRecipesAmount;


    private void Awake() {

        Instance= this;

        waitingRecipeSOList= new List<RecipeSO>();
    }

    private void Update() {
        spawnRecipeTimer -= Time.deltaTime;

        if(spawnRecipeTimer < 0f ) {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (KitchenGameManager.Instance.IsGamePlaying() && waitingRecipeSOList.Count < waitingRecipeMax) {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
            }
        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject) {
        for(int i = 0; i < waitingRecipeSOList.Count; i++) {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if(waitingRecipeSO.kitchenObjectsOSList.Count == plateKitchenObject.GetKitchenObjectOSList().Count ) {
                // Has the samee number of ingredients
                bool plateContentMatchesRecipe = true;

                foreach(KitchenObjectOS recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectsOSList) {
                    //Cycliing through all ingredients in Recipe
                    bool ingredientsFound = false;

                    foreach (KitchenObjectOS plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectOSList()) {
                        //Cycliing through all ingredients in Plate
                        if(plateKitchenObjectSO == recipeKitchenObjectSO) {
                            //ingredients matches
                            ingredientsFound = true;
                            break;
                        }
                    }
                    if(!ingredientsFound ) {
                        //This recipe ingredients was not found onn plate
                        plateContentMatchesRecipe = false;
                    }
                }

                if(plateContentMatchesRecipe) {
                    //Player delivered the correct Recipe

                    successfulRecipesAmount++;

                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeComplete?.Invoke(this, EventArgs.Empty);
                    OnRecipeSucess?.Invoke(this, EventArgs.Empty);



                    return;
                }
            }

        }

        //No matches found
        //Debug.Log("Not correct Delivery");
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);

    }

    public List<RecipeSO> GetWaitingRecipeSOList(){
        return waitingRecipeSOList;
    }

    public int GetSuccessfulRecipesAmount() {
        return successfulRecipesAmount;
    }
}

