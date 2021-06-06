using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class JogoManager : MonoBehaviour {

    public int Pontos;
    public int Vida;
    public int Mortes;
    public GameObject FimDeJogo;
    public GameObject DeathEndCycleMenu;
    public GameObject PointShopPanel;
    public static JogoManager GameManager;
    public Text PontosDoJogador;
    public Text VidaDoJogador;
    private bool isDead = false;
    public Text Highscore;
    private bool ShopOn = false;
    public Button BotaoPrimeiraCompra;
    public Button BotaoSegundaCompra;

	// Use this for initialization
	void Start ()
    {
        GameManager = this;
        Vida = 3;
        Time.timeScale = 1;
        Mortes = 0;
        BotaoPrimeiraCompra.onClick.AddListener(delegate { TaskOnClick(1, 1000, BotaoPrimeiraCompra); });
        BotaoSegundaCompra.onClick.AddListener(delegate { TaskOnClick(2, 5000, BotaoSegundaCompra); });
    }

    // Update is called once per frame
    void Update ()
    {
        PontosDoJogador.text = Pontos.ToString();
        VidaDoJogador.text = Vida.ToString();
        if (Vida <= 0)
        {
            HighscoreCheck();
            GameOver();        
        }

	}

    public void addPoints(int points)
    {
        Pontos += points;
    }

    public void GameOver()
    {
        
        Time.timeScale = 0;
        if (isDead == false)
        {
            FimDeJogo.SetActive(true);
            isDead = true;
            Mortes += 1;
            if (Mortes == 3)
            {
                Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
                FimDeJogo.SetActive(false);
                DeathEndCycleMenu.SetActive(true);

            }
        }
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PointShopButton()
    {   
        if(ShopOn == false)
        { 
        DeathEndCycleMenu.SetActive(false);
        PointShopPanel.SetActive(true);
            ShopOn = true;
        }
        else if(ShopOn == true)
        {
            DeathEndCycleMenu.SetActive(true);
            PointShopPanel.SetActive(false);
            ShopOn = false;
        }
    }


        
       

    public void TaskOnClick(int Vidas, int PontosGastos, Button bttn)
    {   
        if(Pontos > PontosGastos)
      {
        Vida += Vidas;
        Pontos -= PontosGastos;
        Destroy(bttn.gameObject);
        isDead = false;
        FimDeJogo.SetActive(false);
        DeathEndCycleMenu.SetActive(false);
        PointShopPanel.SetActive(false);
        Mortes -= 1;
        StartCoroutine(Imunidade());
       }
    }

    public IEnumerator RewardedAds()
    {
        if (Mortes == 1)
        {
            JogoManager.GameManager.Vida += 2;
            FimDeJogo.SetActive(false);
            StartCoroutine(Imunidade());
            yield break;
        }

        if (Mortes == 2)
        {
            JogoManager.GameManager.Vida += 1;
            FimDeJogo.SetActive(false);
            StartCoroutine(Imunidade());
            yield break;
        }
    }

    public IEnumerator Imunidade()

    {
        Time.timeScale = 1;
        player.Jogador.Imunidade = true;
        yield return new WaitForSecondsRealtime(2);
        isDead = false;
        player.Jogador.Imunidade = false;
        yield break;
    }

    void HighscoreCheck()
    {
        if (Pontos > PlayerPrefs.GetInt("Highscore"))
        {

            PlayerPrefs.SetInt("Highscore", Pontos);
        }
    }
}
