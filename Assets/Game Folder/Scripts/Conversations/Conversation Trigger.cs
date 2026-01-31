using UnityEditor;
using UnityEngine;
using DialogueEditor;
public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation Conversation;
    [SerializeField] private EnergySystem EnergySystem;
    public void Interaction_Function()
    {
        ConversationManager.Instance.StartConversation(Conversation);  
    }
    public void Set_Energy_Before_Decision()
    {
        ConversationManager.Instance.SetInt("Energy", EnergySystem.Current_Energy_Round);
    }

}
