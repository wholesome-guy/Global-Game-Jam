using DG.Tweening;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private float Distance = 5;
    [SerializeField] private float Offset_Distance = 5;
    [SerializeField] private ConversationTrigger CT;
   public void Move_to_Player(Transform player)
   {
        Vector3 desired_position =
            player.position +
            player.forward * Distance +
            player.right * Offset_Distance; 
        desired_position.y =transform.position.y;

        transform.DOMove(desired_position, 2.5f)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() =>
            {
                CT.Interaction_Function();
            });

        transform.DOLookAt(player.position, 2.5f);
        
    }
        
}
