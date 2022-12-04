using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : Singleton<MusicManager>
{

    //[HideInInspector][Range(-1f, 1f)] public float normalizedScore;

    [SerializeField] private EventReference music;
    public FMOD.Studio.EventInstance musicInstance;

    // Start music
    void Start()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(music);
        musicInstance.start();
        updateMusicParams(-1.0f);
    }

    // Destroy music instance on object destruction
    void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();
    }

    // Update the parameter controlling adaptive music
    // Call this in the game manager when score is updated
    public void updateMusicParams(float newScore)
    {
        musicInstance.setParameterByName("Score", newScore);
        Debug.Log(newScore + " music score");
    }
}
