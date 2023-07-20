using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using static CuttingCounter;

public class SStoveCounter : BaseCounter,IHasProgress{

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public class OnStateChangedEventArgs : EventArgs {
        public State state;
    }


    public enum State {
        Idle,
        Frying,
        Fried,
        Burned,
    }

    private State state;

    [SerializeField] private FryingReciepeSO[] fryingReciepeSOArray;
    [SerializeField] private BurningReciepeSO[] burningReciepeSOArray;

    private float fryingTimer;
    private float burnedTimer;

    private FryingReciepeSO fryingReciepeSO;
    private BurningReciepeSO burningReciepeSO;

    private void Start() {
        state = State.Idle;
    }

    private void Update() {
        if (HasKitchenObject()) {
            switch (state) {

                case State.Idle:
                    break;

                case State.Frying:
                    fryingTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = fryingTimer / fryingReciepeSO.fryingTimerMax

                    });

                    if (fryingTimer > fryingReciepeSO.fryingTimerMax) {
                        //Fried

                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpwanKitchenObject(fryingReciepeSO.output, this);

                       
                        state = State.Fried;
                        burnedTimer = 0f;
                        burningReciepeSO = GetBurningSOWithInput(GetKitchenObject().GetKitchenObjectOS());

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state= state

                        });
                      
                    }

                    break;

                case State.Fried:
                    burnedTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                        progressNormalized = burnedTimer / burningReciepeSO.burningTimerMax

                    });


                    if (burnedTimer > burningReciepeSO.burningTimerMax) {
                        //Fried

                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpwanKitchenObject(burningReciepeSO.output, this);

                    
                        state = State.Burned;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state

                        });

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                            progressNormalized = 0f

                        });


                    }

                    break;

                case State.Burned:
                    break;
            }
       
        }
    }

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //Theree is no KitchenObject
            if (player.HasKitchenObject()) {
                //Player is Carrying Something

                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectOS())) {
                    //player carring something that can be fried
                    player.GetKitchenObject().SetKitchenObjectParent(this);

                    fryingReciepeSO = GetFryingSOWithInput(GetKitchenObject().GetKitchenObjectOS());

                    state = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                        state = state

                    });

                    OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArgs{
                        progressNormalized = fryingTimer / fryingReciepeSO.fryingTimerMax

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

                        state = State.Idle;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                            state = state

                        });

                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                            progressNormalized = 0f

                        });
                    }
                }
            }
            else {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);

                state = State.Idle;

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {
                    state = state

                });

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs {
                    progressNormalized = 0f

                });
            }
        }
    }


    private bool HasRecipeWithInput(KitchenObjectOS inputKitchenObjectOS) {

        FryingReciepeSO fryingReciepeSO = GetFryingSOWithInput(inputKitchenObjectOS);
        return fryingReciepeSO != null;

    }

    private KitchenObjectOS GetOutputForInput(KitchenObjectOS inputKitchenObjectOS) {
        FryingReciepeSO fryingReciepeSO = GetFryingSOWithInput(inputKitchenObjectOS);
        fryingReciepeSO = GetFryingSOWithInput(inputKitchenObjectOS);
        if (fryingReciepeSO != null) {
            return fryingReciepeSO.output;
        }
        else {
            return null;
        }
    }

    private FryingReciepeSO GetFryingSOWithInput(KitchenObjectOS inputKitchenObjectOS) {
        foreach (FryingReciepeSO fryingRecipeSO in fryingReciepeSOArray) {
            if (fryingRecipeSO.input == inputKitchenObjectOS) {
                return fryingRecipeSO;
            }
        }

        return null;
    }

    private BurningReciepeSO GetBurningSOWithInput(KitchenObjectOS inputKitchenObjectOS) {
        foreach (BurningReciepeSO burningRecipeSO in burningReciepeSOArray) {
            if (burningRecipeSO.input == inputKitchenObjectOS) {
                return burningRecipeSO;
            }
        }

        return null;
    }

    public bool IsFried() {
        return state == State.Fried;
    }
}
