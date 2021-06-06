using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCarrier : Enemy {

    public Vector3 otherSide;
	// Use this for initialization
	void Start () {
        Speed = 0.5f;
        points = 10;
        LifePoints = 1;
        transform.localScale = new Vector3(0.8f, 0.8f);
        Sprite.sprite = Resources.Load<Sprite>("red");
        Collider.radius = 0.6f;
        weaponRandomizer(3);
        gameObject.tag = "ItemCarrier";
    }

    public override void MovementPattern()
    {

        base.MovementPattern();

    }
}
