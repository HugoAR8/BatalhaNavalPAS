using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isShop = false;
    private bool isMenu = true;
    public GameObject menu;
    public GameObject shop;

    public GameObject FrigateButton;
    public GameObject CruiserButton;
    public GameObject DestroyerButton;
    public GameObject BatleshipButton;


    private void Start()
    {
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
    }

    public void newGame()
    {
        gameControl.coins = 0;
        gameControl.curShip = "Corvette";
        gameControl.boughtFrigate = false;
        gameControl.boughtCruiser = false;
        gameControl.boughtDestroyer = false;
        gameControl.boughtBatleship = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void continueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }
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
