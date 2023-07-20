using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectOS_GameObject {

        public KitchenObjectOS kitchenObjectOS;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectOS_GameObject> kitchenObjectOSGameObjectList;

    private void Start() {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach (KitchenObjectOS_GameObject kitchenObjectOSGameObject in kitchenObjectOSGameObjectList) {
                kitchenObjectOSGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        foreach(KitchenObjectOS_GameObject kitchenObjectOSGameObject in kitchenObjectOSGameObjectList) {
            if(kitchenObjectOSGameObject.kitchenObjectOS == e.kitchenObjectOS) {
                kitchenObjectOSGameObject.gameObject.SetActive(true);  
            }
        }
    }
}
