using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CuttingCounter : BaseCounter,IHasProgress{


    public static event EventHandler OnAnyCut;

    new public static void ResetStaticData() {
        OnAnyCut= null;
    }

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    public event EventHandler OnCut;

    [SerializeField] private CuttingReciepeSO[] cutKitchenObjectOSArray;

    private int cuttingProgress;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //Theree is no KitchenObject
            if (player.HasKitchenObject()) {
                //Player is Carrying Something

                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectOS())){
                    //player carring something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    cuttingProgress= 0;
        
                    CuttingReciepeSO cuttingReciepeSO = GetCuttingSOWithInput(GetKitchenObject().GetKitchenObjectOS());

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = (float)cuttingProgress / cuttingReciepeSO.cuttingPogressMax
                    });
                }
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
            }
            else {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player) {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectOS())) {
            //There is a KitchenObject here and it can be cut
            cuttingProgress++;

            OnCut?.Invoke(this,EventArgs.Empty);
            OnAnyCut?.Invoke(this,EventArgs.Empty);

           
            CuttingReciepeSO cuttingReciepeSO = GetCuttingSOWithInput(GetKitchenObject().GetKitchenObjectOS());

            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                progressNormalized = (float)cuttingProgress / cuttingReciepeSO.cuttingPogressMax
            });

            if (cuttingProgress >= cuttingReciepeSO.cuttingPogressMax) {

                KitchenObjectOS outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectOS());

                GetKitchenObject().DestroySelf();

                KitchenObject.SpwanKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectOS inputKitchenObjectOS) {

        CuttingReciepeSO cuttingReciepeSO = GetCuttingSOWithInput(inputKitchenObjectOS);
        return cuttingReciepeSO != null;

    }

    private KitchenObjectOS GetOutputForInput(KitchenObjectOS inputKitchenObjectOS) {
        CuttingReciepeSO cuttingReciepeSO = GetCuttingSOWithInput(inputKitchenObjectOS);
        if(cuttingReciepeSO != null) {
            return cuttingReciepeSO.output;
        }else {
            return null;
        }
    }

    private CuttingReciepeSO GetCuttingSOWithInput(KitchenObjectOS inputKitchenObjectOS) {
        foreach (CuttingReciepeSO cuttingReciepeSO in cutKitchenObjectOSArray) {
            if (cuttingReciepeSO.input == inputKitchenObjectOS) {
                return cuttingReciepeSO;
            }
        }

        return null;
    }
}
