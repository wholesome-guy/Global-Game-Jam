using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEndStateManager : MonoBehaviour
{
    [SerializeField] private Image End_State_Image;
    [SerializeField] private Sprite[] End_State_Sprites; //0 - energy, 1 - reputation, 2 - victory
    [SerializeField] private TextMeshProUGUI Heading;
    [SerializeField] private TextMeshProUGUI Subheading;
    [SerializeField] private GameObject RestartText;
    [SerializeField] private GameObject End_State_Group;

    public void Loss_To_Energy()
    {
        End_State_Group.SetActive(true);
        End_State_Image.sprite = End_State_Sprites[0];
        Heading.text = "UNMASKED";
        Subheading.text = "You ran out of energy";
    }

    public void Loss_To_Reputation()
    {
        End_State_Group.SetActive(true);
        End_State_Image.sprite = End_State_Sprites[1];
        Heading.text = "UNMASKED";
        Subheading.text = "Your ran out of reputation";
    }

    public void Victory()
    {
        End_State_Group.SetActive(true);
        End_State_Image.sprite = End_State_Sprites[2];
        Heading.text = "MASKED";
        Subheading.text = "You reached your house";
        RestartText.SetActive(false);
    }
}
