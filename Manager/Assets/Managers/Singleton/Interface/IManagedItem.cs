using UnityEngine;

public interface IManagedItem<TKey,TItem> where TItem : MonoBehaviour
{
    TKey ItemID { get;}
    void Enable();
    void Disable();
    void Register();
}
