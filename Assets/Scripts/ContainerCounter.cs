using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectOS kitchenObjectOS;


    public override void Interact(Player player) {

        if (!player.HasKitchenObject()) {
            //player os not carring anything

            KitchenObject.SpwanKitchenObject(kitchenObjectOS,player);


            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
