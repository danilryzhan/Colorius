using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : MonoBehaviour
{
   ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void OnPlay(Vector2 direction,Color color)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _particleSystem.startColor = color;
        // Поворачиваем объект
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        _particleSystem.Play();
    }
}
