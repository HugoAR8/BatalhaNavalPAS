using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    //Controle do barco do player
    public CharacterController controller;

    //Botão de game over
    public GameObject gameOverButton;
    public static bool gameOver = false;

    //Navio atual do player
    public static GameObject curShip;
    [SerializeField] private GameObject[] allShips;

    //Velocidade do player
    private float speed = 120f;
    private float backwardsSpeed = 40f;

    //gravidade
    public Vector3 velocity;
    private float gravity = -90.81f;
    public Transform groundCheck;
    public float groundDistance = 4f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Moedas do player
    public GameObject coins;

    //Checa se o jogo foi salvo para não salvar varias vezes
    private bool savedGame = false;

    
    //Chamado ao inicio de cada cena
    private void Start()
    {
        gameOver = false;

        //Instanciando o navio correto que o player tem
        if(gameControl.curShip == "Corvette")
        {
            controller.radius = 4f;
            controller.height = 3.87f;
            curShip = Instantiate(allShips[0], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Frigate")
        {
            controller.radius = 3f;
            controller.height = 2.18f;
            curShip = Instantiate(allShips[1], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Cruiser")
        {
            controller.radius = 4f;
            controller.height = 3.87f;
            curShip = Instantiate(allShips[2], transform.position, transform.rotation);
        }
        else if(gameControl.curShip == "Destroyer")
        {
            controller.radius = 2.5f;
            controller.height = 0f;
            curShip = Instantiate(allShips[3], transform.position, transform.rotation);
        }
        else
        {
            controller.radius = 2.5f;
            controller.height = 0f;
            curShip = Instantiate(allShips[4], transform.position, transform.rotation);
        }
        //Ligando o navio instanciado ao objeto de controle do player
        curShip.transform.parent = this.transform;
        speed = curShip.GetComponent<Ship>().speed;
        backwardsSpeed = speed / 3;
        //Sumindo com o mouse 
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Chamado a cada frame
    void Update()
    {
        if (gameOver == false)
        {
            savedGame = false;
            //Texto de quantidade de moedas
            coins.GetComponent<TextMeshProUGUI>().text = gameControl.coins.ToString();

            //pegando o botão esquerdo do mouse pra atirar
            if (Input.GetMouseButtonDown(0))
            {
                curShip.GetComponent<Ship>().Attack();
            }
            //Gravidade
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -9f;
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            //Movimento
            float boatX = Input.GetAxis("Horizontal") *50 * Time.deltaTime;
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.forward * z;
            if (z > 0)
            {
                controller.Move(move * speed * Time.deltaTime);
            }
            else
            {
                controller.Move(move * backwardsSpeed * Time.deltaTime);
            }
            transform.Rotate(Vector3.up * boatX);
        }
        if (curShip == null)
        {
            gameOver = true;
        }

        //Função de gameOver
        if(gameOver == true )
        {
            //salvando jogo
            if(savedGame == false)
            {
                saveSystem.SaveGame();
                savedGame = true;
            }
            //Mostrando o cursor do mouse novamente
            Cursor.lockState = CursorLockMode.None;
            gameOverButton.SetActive(true);
        }


    }

    //Função de voltar pro menu
    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
