using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Player Player;
    [SerializeField] private ParticleSystem _particle;
    private float lifeTime = 2f;
    private float yeaaaaaTime = 0f;

    public void Init(Vector3 position)
    {
        yeaaaaaTime = 0f;
        this.transform.position = position;
        _particle.Play();
        this.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        yeaaaaaTime += Time.deltaTime;
        if (yeaaaaaTime >= lifeTime)
        {
            yeaaaaaTime = 0f;
            Player.LetsGoPool(this);
        }
    }
}
