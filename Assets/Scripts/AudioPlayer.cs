using UnityEngine;

public class AudioPlayer : SingletonMonoBehaviour<AudioPlayer>
{
    #region Variables

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _negativePickUpAudioClip;
    [SerializeField] private AudioClip _positivePickUpAudioClip;
    [SerializeField] private AudioClip _winAudioClip;

    #endregion


    #region Public Methods

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null)
            return;
        
        _audioSource.PlayOneShot(audioClip);
    }

    public void AddNegativePickUpAudioClip()
    {
        PlaySound(_negativePickUpAudioClip);
    }
    public void AddPositivePickUpAudioClip()
    {
        PlaySound(_positivePickUpAudioClip);
    }

    public void AddWinAudioClip()
    {
        PlaySound(_winAudioClip);
    }

    #endregion

    
}