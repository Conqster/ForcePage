using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity UI system
using UnityEngine.UI;
// Unity engine scence Management
using UnityEngine.SceneManagement;
using TMPro;

namespace ForcePage
{
    public class UIManager : MonoBehaviour
    {
        //Game state enums > MainMenu, playing(active), paused, gameOver
        //why cant i use serializefield
        public enum GameState { MainMenu, Playing, Paused, GameOver };
        public GameState currentState;
        public GameObject mainMenuPanel, pauseMenuPanel, gameOverPanel, inGameUI;

        public Image healthBar;
        float currentHealth, maxHealth = 100f;

        PlayerInventory _playerInventory;

        //Game current state variable

        //what will happen when on awake when the script is launched > Load Mainmenu else its Active

        private void Awake()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                SetGameState(GameState.MainMenu);
            }
            else
            {
                SetGameState(GameState.Playing);
            }
        }

        private void Start()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
        }

        void Update()
        {
            PlayerHealthUI();
            PlayerInput();
            //print(currentState);
        }

        void PlayerHealthUI()
        {
            currentHealth = _playerInventory.hp;
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        void PlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                print("Working");
                if (currentState == GameState.Playing)
                {
                    SetGameState(GameState.Paused);
                }
                else if (currentState == GameState.Paused)
                {
                    SetGameState(GameState.Playing);
                }
            }
        }
        // CheckGameState(GameState newGameState) >
        public void SetGameState(GameState newGameState)
        {
            currentState = newGameState;
            switch (currentState)
            {
                case GameState.MainMenu:
                    MainMenu();
                    break;
                case GameState.Playing:
                    GameActive();
                    //Manager.gamePaused = false;
                    Time.timeScale = 1f;
                    break;
                case GameState.Paused:
                    GamePaused();
                    //Manager.gamePaused = true;
                    Time.timeScale = 0f;
                    break;
                case GameState.GameOver:
                    GameOver();
                    //Manager.gamePaused = true;
                    Time.timeScale = 0f;
                    break;
            }
        }


        public void MainMenu()
        {
            //in game Ui
            inGameUI.SetActive(false);
            mainMenuPanel.SetActive(true);
            pauseMenuPanel.SetActive(false);
            gameOverPanel.SetActive(false);

        }

        public void GameActive()
        {
            inGameUI.SetActive(true);
            mainMenuPanel.SetActive(false);
            pauseMenuPanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }

        public void GamePaused()
        {
            inGameUI.SetActive(false);
            mainMenuPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
            gameOverPanel.SetActive(false);
        }

        public void GameOver()
        {
            inGameUI.SetActive(false);
            mainMenuPanel.SetActive(false);
            pauseMenuPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        public void StartGame()
        {
            SceneManager.LoadScene("FirstLevel");
            SetGameState(GameState.Playing);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            SetGameState(GameState.MainMenu);
        }


        public void PauseGame()
        {
            SetGameState(GameState.Paused);
        }

        public void ResumeGame()
        {
            SetGameState(GameState.Playing);
        }

        public void QuitGame()
        {
            Application.Quit();
        }


        
    }

}
