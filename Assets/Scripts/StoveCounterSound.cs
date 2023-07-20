using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour {
    
    [SerializeField] private SStoveCounter stoveCounter;

    private AudioSource audioSource;
    private float warningSoundTimer;
    private bool playWarningSound;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        float burnShowProgressAmount = .5f;
        playWarningSound = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
    }

    private void StoveCounter_OnStateChanged(object sender, SStoveCounter.OnStateChangedEventArgs e) {
        bool playSound = e.state == SStoveCounter.State.Frying || e.state == SStoveCounter.State.Fried;
        if (playSound) {
            audioSource.Play();
        }
        else {
            audioSource.Pause();
        }
    }

    private void Update() {
        if (playWarningSound) {
            warningSoundTimer -= Time.deltaTime;
            if (warningSoundTimer <= 0) {
                float warningSoundTimerMax = .2f;
                warningSoundTimer = warningSoundTimerMax;

                SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);  
            }
        }
    }
}