using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dual : Enemy
{
    protected Vector3 ClonePosition;
    protected Enemy<CloneDual> CloneEnemy;
    void Start()
    {

        Speed = 0.5f;
        points = 40;
        LifePoints = 5;
        Sprite.color = Color.clear;
        Sprite.sprite = Resources.Load<Sprite>("enemy");
        this.Collider.radius = 0.2f;
        ClonePosition = new Vector3(-transform.position.x, -transform.position.y, -9.7f);
        CloneEnemy = new Enemy<CloneDual>("CloneDualEnemy");
        CloneEnemy.GameObject.transform.position = ClonePosition;
        }
    }