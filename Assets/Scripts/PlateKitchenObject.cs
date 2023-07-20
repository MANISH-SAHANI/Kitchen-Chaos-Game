using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateKitchenObject : KitchenObject {

    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs {
        public KitchenObjectOS kitchenObjectOS;
    }

    [SerializeField] private List<KitchenObjectOS> validkitchenObjectSOList;

    private List<KitchenObjectOS> kitchenObjectSOList;

    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectOS>();
    }

    public bool TryAddIngredient(KitchenObjectOS kitchenObjectOS) {

        if (!validkitchenObjectSOList.Contains(kitchenObjectOS)) {
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectOS)) {
            //Already has this type
            return false;
        }
        else {
            kitchenObjectSOList.Add(kitchenObjectOS);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs {
                kitchenObjectOS = kitchenObjectOS
            }); 

            return true;
        }
    }

    public  List<KitchenObjectOS> GetKitchenObjectOSList() {
        return kitchenObjectSOList;
    }



}

