using System.Collections.Generic;
using UnityEngine;

public interface IManager<TKey,TItem> where TItem : MonoBehaviour
{
    Dictionary<TKey,TItem> ItemsManaged { get; }

    void Add(TItem _item);
    void Remove(TItem _item);
    void EnableItem(TItem _item);
    void EnableItem(TKey _key);

    void DisableItem(TItem _item);
    void DisableItem(TKey _key);
}
