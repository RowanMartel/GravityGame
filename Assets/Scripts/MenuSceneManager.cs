using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] Button btnLevelSelect;
    [SerializeField] TMP_Text txtStartCont;
    [SerializeField] GameObject imgLevel3Lock;
    [SerializeField] GameObject imgLevel4Lock;
    [SerializeField] GameObject imgLevel5Lock;

    [SerializeField] GameObject layoutMainMenu;
    [SerializeField] GameObject layoutLevelSelect;

    void Start()
    {
        if (GameManager.furthestLevel > 1)
        {
            btnLevelSelect.interactable = true;
            txtStartCont.text = "Continue Game";

            if (GameManager.furthestLevel > 2)
            {
                imgLevel3Lock.SetActive(false);
                if (GameManager.furthestLevel > 3)
                    imgLevel4Lock.SetActive(false);
                    if (GameManager .furthestLevel > 4)
                        imgLevel5Lock.SetActive(false);
            }
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
}