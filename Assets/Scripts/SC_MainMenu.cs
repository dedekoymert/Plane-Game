using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject WinMenu;
    public GameObject LostMenu;

    void Start()
    {
        if(ApplicationModel.status == 0) {
            WinMenu.SetActive(false);
            LostMenu.SetActive(false);
        } else if (ApplicationModel.status == 1) {
            MainMenu.SetActive(false);
            LostMenu.SetActive(false);
        } else if (ApplicationModel.status == 2){
            MainMenu.SetActive(false);
            WinMenu.SetActive(false);
        } else {
            MainMenu.SetActive(false);
            WinMenu.SetActive(false);
            LostMenu.SetActive(false);
        }
    }

    public void PlayNowButton()
    {
        ApplicationModel.status = 3;
		ApplicationModel.score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

}