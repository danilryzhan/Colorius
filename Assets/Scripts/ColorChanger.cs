using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private AudioSource audio;
    public SpriteRenderer[] renderers;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Change (int index)
    {
        audio.Play();
        for (int i = 0; i < 4; i++)
        {
            if(index==i)
                renderers[i].enabled = true;
            else renderers[i].enabled = false;
        }
    }    

    
}
