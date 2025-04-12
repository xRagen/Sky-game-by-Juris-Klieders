using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagere : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip playerHurtSound;

    private void OnEnable()
    {
        GameEvents.TakeDamage += PlayHurtSound;
    }

    private void OnDisable()
    {
        GameEvents.TakeDamage -= PlayHurtSound;
    }

    private void PlayHurtSound()
    {
        source.PlayOneShot(playerHurtSound);
    }
}
