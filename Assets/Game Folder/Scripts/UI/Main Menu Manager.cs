using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Texture2D Transition_Texture;
   public void Start_Click_Button()
   {
        StartCoroutine(Start_Button());
   }
    public void Quit_Click_Button()
    {

        StartCoroutine (Quit_Button());
    }

    private IEnumerator Start_Button()
    {
        TransitionManager.Transition_Screen_Event.Invoke(Transition_Texture,0,1,3f);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator Quit_Button()
    {
        TransitionManager.Transition_Screen_Event.Invoke(Transition_Texture, 0, 1, 3f);
        yield return new WaitForSeconds(3.5f);
        Application.Quit();
    } 
}
