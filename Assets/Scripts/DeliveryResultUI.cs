using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour {

    private const string POPUP = "Popup";

    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite sucessSprite;
    [SerializeField] private Sprite failedSprite;

    private Animator animator;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start () {
        DeliveryManager.Instance.OnRecipeSucess += DeliveryManger_OnRecipeSucess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManger_OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void DeliveryManger_OnRecipeFailed(object sender, System.EventArgs e) {
        gameObject.SetActive(true);

        animator.SetTrigger(POPUP);
        backgroundImage.color = failedColor;
        iconImage.sprite= failedSprite;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void DeliveryManger_OnRecipeSucess(object sender, System.EventArgs e) {
        gameObject.SetActive(true);

        animator.SetTrigger(POPUP);
        backgroundImage.color = successColor;
        iconImage.sprite = sucessSprite;
        messageText.text = "DELIVERY\nSUCCESS";
    }
}
