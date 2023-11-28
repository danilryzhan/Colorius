using UnityEngine;

public class SwipeColorChanger : MonoBehaviour
{
    public ColorChanger changer;
    public ParticleSystem _particleSystem;
    private Color[] colors = { Color.red, Color.blue, Color.white, Color.yellow };
    private int currentColorIndex = 0;


   
    void Update()
    {
        // ѕроверка нажати€ клавиш на клавиатуре
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeColorRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeColorLeft();
        }
    }

    private void ChangeColorRight()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        changer.Change(currentColorIndex);
        GetComponent<SpriteRenderer>().color = colors[currentColorIndex];
    }

    private void ChangeColorLeft()
    {
        currentColorIndex = (currentColorIndex - 1 + colors.Length) % colors.Length;
        changer.Change(currentColorIndex);
        GetComponent<SpriteRenderer>().color = colors[currentColorIndex];
    }

    private void OnDestroy()
    {
        _particleSystem.Play();
    }
}

