using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour {
    public Canvas pauseMenu;
    public Button continueGameText;
    public Button quitToMenuGameText;
    public Button exitGameText;

    void Start() {

        pauseMenu = pauseMenu.GetComponent<Canvas>();
        continueGameText = continueGameText.GetComponent<Button>();
        quitToMenuGameText = quitToMenuGameText.GetComponent<Button>();
        exitGameText = exitGameText.GetComponent<Button>();
        pauseMenu.enabled = false;

    }
    public void QuitToMenuPress() {

        SceneManager.LoadScene(0);

    }
    public void ContinuePress() {

        pauseMenu.enabled = false;

    }
    public void ExitGame() {

        Application.Quit();

    }
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            print("jopefwj");
            pauseMenu.enabled = !pauseMenu.enabled;
        }

    }

}
