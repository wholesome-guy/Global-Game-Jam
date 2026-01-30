using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   public void Start_Click_Button()
   {
        SceneManager.LoadScene(1);
   }
    public void Quit_Click_Button()
    {

        Application.Quit();
    }
}
