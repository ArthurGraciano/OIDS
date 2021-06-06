using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : Enemy {

	// Use this for initialization
	void Start ()
    {
        Speed = 1.0f;
        points = 20;
        LifePoints = 5;  
        Sprite.color = Color.yellow;
        Sprite.sprite = Resources.Load<Sprite>("enemy");
        weaponRandomizer(2);
        if (haveWeapon == true)
        {
            Sprite.color = Color.cyan;
        }
    }
	
}
