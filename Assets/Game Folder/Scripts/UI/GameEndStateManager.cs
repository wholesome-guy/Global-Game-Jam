using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameEndStateManager : MonoBehaviour
{
    [SerializeField] private Image End_State_Image;
    [SerializeField] private Sprite[] End_State_Sprites; //0 - energy, 1 - reputation, 2 - victory
    [SerializeField] private TextMeshProUGUI Heading;
    [SerializeField] private TextMeshProUGUI Subheading;
    [SerializeField] private GameObject End_State_Group;
    [SerializeField] private CanvasGroup Canvas_Group;

    [SerializeField] private Texture2D Transition_Texture;
    private void Start()
    {
        TransitionManager.Transition_Screen_Event(Transition_Texture, 1, 0, 3);

    }
    private void Loss_To_Energy()
    {
        Canvas_Group.alpha = 0;
        End_State_Group.SetActive(true);
        TransitionManager.UI_Fader_Event(Canvas_Group, 0, 1, 1.0f);
        End_State_Image.sprite = End_State_Sprites[0];
        Heading.text = "UNMASKED";
        Subheading.text = "You ran out of energy";
    }

    private void Loss_To_Reputation()
    {
        Canvas_Group.alpha = 0;
        End_State_Group.SetActive(true);
        TransitionManager.UI_Fader_Event(Canvas_Group, 0, 1, 1.0f);
        End_State_Image.sprite = End_State_Sprites[1];
        Heading.text = "UNMASKED";
        Subheading.text = "You ran out of reputation";
    }

    private void Victory()
    {
        Canvas_Group.alpha = 0;
        End_State_Group.SetActive(true);
        TransitionManager.UI_Fader_Event(Canvas_Group, 0, 1, 1.0f);
        End_State_Image.sprite = End_State_Sprites[2];
        Heading.text = "MASKED";
        Subheading.text = "You reached your house";
    }
    private void OnEnable()
    {
        PlayerCollision.Victory_Event += Victory;
        EnergySystem.Energy_Over += Loss_To_Energy;
        ReputationSystem.Reputation_Over += Loss_To_Reputation;
    }
    private void OnDisable()
    {
        PlayerCollision.Victory_Event -= Victory;
        EnergySystem.Energy_Over -= Loss_To_Energy;
        ReputationSystem.Reputation_Over -= Loss_To_Reputation;


    }

    public void Main_Menu_Button()
    {
        TransitionManager.Transition_Screen_Event(Transition_Texture, 0, 1, 2);
        StartCoroutine(Delay_launching_Scene());
    }
    private IEnumerator Delay_launching_Scene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
