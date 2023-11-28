using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public SpriteRenderer[] renderers;

    public void Change (int index)
    {
        for (int i = 0; i < 4; i++)
        {
            if(index==i)
                renderers[i].enabled = true;
            else renderers[i].enabled = false;
        }
    }    

    
}
