using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager<TID,TItem> where TItem : MonoBehaviour, IManagedItem<TID>
{
    Dictionary<TID, TItem> AllItems { get;}

    TItem Add(TItem _item);
    bool Remove(TID _id);
    bool Enable(TID _id);
    bool Disable(TID _id);
}
