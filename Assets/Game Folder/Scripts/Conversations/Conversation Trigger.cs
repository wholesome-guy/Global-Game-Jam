using UnityEditor;
using UnityEngine;
using DialogueEditor;
using DG.Tweening;
public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation Conversation;

    public void Interaction_Function()
    {
        ConversationManager.Instance.StartConversation(Conversation);  
    }

    


}
