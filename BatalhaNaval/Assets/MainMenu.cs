using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Booleanas que checam qual parte do menu o jogador esta
    private bool isShop = false;
    private bool isMenu = true;

    //Objeto menu e shop, para fazer com que o menu suma quando se esta no shop e vice-versa
    public GameObject menu;
    public GameObject shop;

    //Botões de compra de cada navio
    public GameObject FrigateButton;
    public GameObject CruiserButton;
    public GameObject DestroyerButton;
    public GameObject BatleshipButton;

    //Chamado ao inicio de cada cena
    private void Start()
    {
        //Função pra destruir os botões do navios que já foram comprados na loja
        if(gameControl.boughtFrigate == true)
        {
            if (FrigateButton != null)
            {
                Destroy(FrigateButton);
            }
        }
        if(gameControl.boughtCruiser == true)
        {
            if (CruiserButton != null)
            {
                Destroy(CruiserButton);
            }
        }
        if(gameControl.boughtDestroyer == true)
        {
            if (DestroyerButton != null)
            {
                Destroy(DestroyerButton);
            }
        }
        if(gameControl.boughtBatleship == true)
        {
            if (BatleshipButton != null)
            {
                Destroy(BatleshipButton);
            }
        }
        continueGame();
    }

    //Função que reseta tudo que o player conseguiu coletar
    public void newGame()
    {
        gameControl.coins = 0;
        gameControl.curShip = "Corvette";
        gameControl.boughtFrigate = false;
        gameControl.boughtCruiser = false;
        gameControl.boughtDestroyer = false;
        gameControl.boughtBatleship = false;
        saveSystem.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Função de carregar os dados no arquivo de save do jogo
    public void continueGame()
    {
        PlayerData data = saveSystem.loadGame();
        gameControl.coins = data.coins;
        gameControl.curShip = data.curShip;
        gameControl.boughtFrigate = data.boughtFrigate;
        gameControl.boughtCruiser = data.boughtCruiser;
        gameControl.boughtDestroyer = data.boughtDestroyer;
        gameControl.boughtBatleship = data.boughtBatleship;
        
    }
    //Função de ir para a proxima cena do jogo
    public void nextScene()
    {
        saveSystem.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    //Função de  sair do jogo
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }

    //Função de compra de cada barco do jogo
    public void buyFrigate()
    {
        if (gameControl.coins >= 350 && gameControl.boughtFrigate == false)
        {
            gameControl.boughtFrigate = true;
            gameControl.coins -= 350;
            gameControl.curShip = "Frigate";
            Destroy(FrigateButton);
            
        }
    }



    public void buyCruiser()
    {
        if (gameControl.coins >= 600 && gameControl.boughtCruiser == false)
        {
            gameControl.boughtFrigate = true;
            gameControl.boughtCruiser = true;
            gameControl.coins -= 600;
            gameControl.curShip = "Cruiser";
            Destroy(CruiserButton);
        }
    }
    public void buyDestroyer()
    {
        if (gameControl.coins >= 1250 && gameControl.boughtDestroyer == false)
        {
            gameControl.boughtFrigate = true;
            gameControl.boughtCruiser = true;
            gameControl.boughtDestroyer = true;
            gameControl.coins -= 1250;
            gameControl.curShip = "Destroyer";
            Destroy(DestroyerButton);
        }
    }
    public void buyBattleship()
    {
        if (gameControl.coins >= 2000 && gameControl.boughtBatleship == false)
        {
            gameControl.boughtFrigate = true;
            gameControl.boughtCruiser = true;
            gameControl.boughtDestroyer = true;
            gameControl.boughtBatleship = true;
            gameControl.coins -= 2000;
            gameControl.curShip = "Batleship";
            Destroy(BatleshipButton);
        }
    }

    //Função de troca de menu
    public void changeMenu()
    {
        if(isMenu == false)
        {
            menu.SetActive(true);
            shop.SetActive(false);
            isMenu = true;
            isShop = false;
        }
        else
        {
            menu.SetActive(false);
            shop.SetActive(true);
            isShop = true;
            isMenu = false;
        }
    }
}
