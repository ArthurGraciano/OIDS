using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDual : Enemy
{

    // Use this for initialization
    void Start()
    {
        Speed = 0.5f;
        points = 40;
        LifePoints = 5;
        Sprite.color = Color.clear;
        Sprite.sprite = Resources.Load<Sprite>("enemy");
        this.Collider.radius = 0.2f;
    }
}
