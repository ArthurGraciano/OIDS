using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public static int NumberOfEnemies;
    protected float actualTime;
    protected float respawnTime;
    protected bool RespawnOn;
    protected int nivelOid;
    protected int points;

    // Use this for initialization
    void Start()
    {
        RespawnOn = false;
        NumberOfEnemies = 0;
        nivelOid = 0;
    }

    void FixedUpdate()
    {

        points = JogoManager.GameManager.Pontos;
        if (RespawnOn == false) {
            if (points >= 0 && points <= 100)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle1(20));
            }
            else if (points > 100 && points <= 200)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle2(20));
            }
            else if (points > 200 && points <= 300)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle3(20));
            }
            else if (points > 300 && points <= 400)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle4(20));
            }
            else if (points > 400 && points <= 500)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle5(20));
            }
            else if (points > 500 && points <= 600)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle6(20));
            }
            else if (points > 600 && points <= 700)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle7(20));
            }
            else if (points > 700 && points <= 800)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle8(20));
            }
            else if (points > 800)
            {
                RespawnOn = true;
                StartCoroutine(RespawnCycle9(100));
            }
        }
    }


    IEnumerator RespawnCycle1(int maxRange)
    {


        for (int i = 0; i <= maxRange; i++)
        {

            if (points > 100)
            {
                StopCoroutine("RespawnCycle1");
                RespawnOn = false;
                yield break;
            }

            new Enemy<Weak>("WeakEnemy");
            yield return new WaitForSeconds(1.3f);
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle2(int maxRange)
    {

        for (int i = 0; i <= maxRange; i++)
        {
            if (points > 200)
            {
                StopCoroutine("RespawCycle2");
                RespawnOn = false;
                yield break;
            }
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy < 61)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(1f);
            }
          
            else
            {
                new Enemy<Medium>("Enemy");
                yield return new WaitForSeconds(1.3f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle3(int maxRange)
    {

        if (points > 300)
        {
            StopCoroutine("RespawCycle3");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 60)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(1f);
            }
            else if (randomEnemy >= 61 && randomEnemy <= 90)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(1.3f);
            }
            else
            {
                new Enemy<Hard>("HardEnemy");
                yield return new WaitForSeconds(1.3f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle4(int maxRange)
    {
        if (points > 400)
        {
            StopCoroutine("RespawCycle4");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 50)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(1f);
            }
            else if (randomEnemy >= 51 && randomEnemy <= 75)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(1f);
            }
            else
            {
                new Enemy<Hard>("HardEnemy");
                yield return new WaitForSeconds(1.3f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle5(int maxRange)
    {
        if (points > 500)
        {
            StopCoroutine("RespawCycle5");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 50)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else if (randomEnemy >= 51 && randomEnemy <= 70)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(1f);
            }
            else
            {
                new Enemy<Hard>("HardEnemy");
                yield return new WaitForSeconds(1.3f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle6(int maxRange)
    {
        if (points > 600)
        {
            StopCoroutine("RespawCycle6");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 40)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else if (randomEnemy >= 41 && randomEnemy <= 60)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(1f);
            }
            else
            {
                new Enemy<Hard>("HardEnemy");
                yield return new WaitForSeconds(1f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle7(int maxRange)
    {
        if (points > 700)
        {
            StopCoroutine("RespawCycle7");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 50)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else if (randomEnemy >= 51 && randomEnemy <= 70)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else

            {
                new Enemy<Invisible>("InvisibleEnemy");
                yield return new WaitForSeconds(1f);
            }
        }
        RespawnOn = false;
    }

    IEnumerator RespawnCycle8(int maxRange)
    {
        if (points > 800)
        {
            StopCoroutine("RespawCycle8");
            RespawnOn = false;
            yield break;
        }
        for (int i = 0; i <= maxRange; i++)
        {
            int randomEnemy = Random.Range(1, 101);
            if (randomEnemy >= 1 && randomEnemy <= 30)
            {
                new Enemy<Weak>("WeakEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else if (randomEnemy >= 31 && randomEnemy <= 60)
            {
                new Enemy<Medium>("MediumEnemy");
                yield return new WaitForSeconds(0.8f);
            }
            else if (randomEnemy >= 61 && randomEnemy <= 80)
            {
                new Enemy<Hard>("HardEnemy");
                yield return new WaitForSeconds(0.8f);
             }
            else
            {
                    new Enemy<Invisible>("InvisibleEnemy");
                    yield return new WaitForSeconds(1f);
                }
            }
            RespawnOn = false;
        }
        IEnumerator RespawnCycle9(int maxRange)
    {
            for (int i = 0; i <= maxRange; i++)
            {
                int randomEnemy = Random.Range(1, 101);
                if (randomEnemy >= 1 && randomEnemy <= 30)
                {
                    new Enemy<Weak>("WeakEnemy");
                    yield return new WaitForSeconds(0.5f);
                }
                else if (randomEnemy >= 31 && randomEnemy <= 50)
                {
                    new Enemy<Medium>("MediumEnemy");
                    yield return new WaitForSeconds(0.5f);
                }
                else if (randomEnemy >= 51 && randomEnemy <= 80)
                {
                    new Enemy<Hard>("HardEnemy");
                    yield return new WaitForSeconds(0.8f);
                }
             
            else
                {
                    new Enemy<Invisible>("InvisibleEnemy");
                    yield return new WaitForSeconds(1f);
                }
            }
            RespawnOn = false;
        }
}