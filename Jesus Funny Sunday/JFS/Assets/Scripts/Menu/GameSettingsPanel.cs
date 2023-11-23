using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    public Slider soundVolumeSlider;
    public Toggle objectParticlesToggle;
    public Toggle muteSoundToggle;

    private Menu menuManager;
    public Button buttonRetour;

    // Start is called before the first frame update
    void Start()
    {
        soundVolumeSlider.value = GameSettings.SoundVolume;
        objectParticlesToggle.isOn = GameSettings.ObjectParticles;
        muteSoundToggle.isOn = GameSettings.MuteSound;

        soundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        objectParticlesToggle.onValueChanged.AddListener(OnObjectParticlesChanged);
        muteSoundToggle.onValueChanged.AddListener(OnMuteSoundChanged);

        menuManager = GameObject.Find("MenuManager").GetComponent<Menu>();
        buttonRetour.onClick.AddListener(menuManager.Retour);
    }

    public void OnSoundVolumeChanged(float newValue)
    {
        GameSettings.SoundVolume = newValue;
    }

    public void OnObjectParticlesChanged(bool newValue)
    {
        GameSettings.ObjectParticles = newValue;
    }

    public void OnMuteSoundChanged(bool newValue)
    {
        GameSettings.MuteSound = newValue;
    }
}
