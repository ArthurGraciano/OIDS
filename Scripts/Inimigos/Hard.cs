using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : Enemy
{
    void Start()
    {
        Speed = 1.5f;
        points = 30;
        LifePoints = 2;
        Sprite.color = Color.red;
        Sprite.sprite = Resources.Load<Sprite>("enemy");
        weaponRandomizer(3);
        if (haveWeapon == true)
        {
            Sprite.color = Color.magenta;
        }
    }
}
