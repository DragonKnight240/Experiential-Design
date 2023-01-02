using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPlaying : MonoBehaviour
{
    AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
