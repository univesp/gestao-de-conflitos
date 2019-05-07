using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	[Header("BG music")]
	public AudioSource musicAudioSource;	

	[Header("Sound Effects")]
	public AudioSource sfxAudioSource;
	public AudioClip dialogoCachorroSFX;
	public AudioClip dialogoGenericoSFX;
	public AudioClip dialogoRespondeSFX;
	public AudioClip mouseClickSFX;
	public AudioClip mouseOverSFX;
	public AudioClip elevadorPortaSFX;
	public AudioClip elevadorOverSFX;

	public static AudioManager instance;

	private void Start() {
		instance = this;
	}

	public void PlayMusic(AudioClip bgMusic)
	{
		musicAudioSource.Stop();
		musicAudioSource.PlayOneShot(bgMusic);
	}

	public void PlaySFX(AudioClip sfx)
	{
		sfxAudioSource.PlayOneShot(sfx);
	}

	public void PlayDialogoCachorroSFX()
	{
		sfxAudioSource.PlayOneShot(dialogoCachorroSFX);
	}

	public void PlayDialogoGenericoSFX()
	{
		sfxAudioSource.PlayOneShot(dialogoGenericoSFX);
	}

	public void PlayDialogoRespondeSFX()
	{
		sfxAudioSource.PlayOneShot(dialogoRespondeSFX);
	}

	public void PlayMouseClick()
	{
		sfxAudioSource.PlayOneShot(mouseClickSFX);
	}

	public void PlayMouseOverSFX()
	{
		sfxAudioSource.PlayOneShot(mouseOverSFX);
	}

	public void PlayElevadorOverSFX()
	{
		sfxAudioSource.PlayOneShot(elevadorOverSFX);
	}

	public void PlayElevadorPortaSFX()
	{
		sfxAudioSource.Stop();
		sfxAudioSource.PlayOneShot(elevadorPortaSFX);
	}
}