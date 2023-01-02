using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static internal SoundManager Instance;
    public GameObject SFXPrefab;
    public GameObject MusicPrefab;
    public GameObject AmbiancePrefab;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SpawnSFX(AudioClip clip)
    {
        GameObject SFX = Instantiate(SFXPrefab);
        SFX.GetComponent<AudioSource>().clip = clip;
    }
}
