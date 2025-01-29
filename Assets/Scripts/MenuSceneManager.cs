using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] Button btnLevelSelect;
    [SerializeField] TMP_Text txtStartCont;

    [SerializeField] GameObject layoutMainMenu;
    [SerializeField] GameObject layoutLevelSelect;

    [SerializeField] List<GameObject> levelPages = new();

    void Start()
    {
        if (GameManager.furthestLevel > 1)
        {
            btnLevelSelect.interactable = true;
            txtStartCont.text = "Continue Game";
        }
    }

    public void OpenLevelSelect()
    {
        layoutMainMenu.SetActive(false);
        layoutLevelSelect.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartContGame()
    {
        GameManager.currentLevel = GameManager.furthestLevel;
        SceneManager.LoadScene(GameManager.furthestLevel);
    }

    public void LoadSelectedLevel(int selection)
    {
        GameManager.currentLevel = selection;
        SceneManager.LoadScene(selection);
    }

    public void ChangeLevelPage(GameObject page)
    {
        foreach (GameObject go in levelPages)
        {
            go.SetActive(false);
        }
        page.SetActive(true);
    }
}