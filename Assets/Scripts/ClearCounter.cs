using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter 
{

    [SerializeField] private KitchenObjectOS kitchenObjectOS;
 


    public override void Interact(Player player)
    {
        if (!HasKitchenObject()) {
            //Theree is no KitchenObject
            if(player.HasKitchenObject()) {
                //Player is Carrying Something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else {
                //Payer not carring nothing
            }
        }
        else {
            //Theree is a KitchenObject
            if (player.HasKitchenObject()) {
                //Player is carring something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //Player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectOS())) {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else {
                    //Player is not carring plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                        //Counter is holding a 
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectOS())) {
                            player.GetKitchenObject().DestroySelf();
                        }

                    }
                }

            }else {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
