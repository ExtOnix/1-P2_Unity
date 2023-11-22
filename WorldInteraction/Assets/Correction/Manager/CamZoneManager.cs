using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class CamZoneManager : SingletonCorr<CamZoneManager>, IManager<string, CamZoneTrigger>
{
    Dictionary<string, CamZoneTrigger> items = new();
    public Dictionary<string, CamZoneTrigger> AllItems => items;

    public CamZoneTrigger Add(CamZoneTrigger _item)
    {
        string _toLower = _item.ID.ToLower();
        if (items.ContainsKey(_toLower))
            return null;
        items.Add(_toLower, _item);
        return _item;
    }

    public bool Remove(string _id)
    {
        string _toLower = _id.ToLower();
        if (items.ContainsKey(_toLower))
            return false;
        items.Remove(_toLower);
        return true;
    }

    public bool Disable(string _id)
    {
        string _toLower = _id.ToLower();
        if (items.ContainsKey(_toLower))
        {
            items[_toLower].Disable();
            return true;
        }
        else
            return false;
    }

    public bool Enable(string _id)
    {
        string _toLower = _id.ToLower();
        if (!items.ContainsKey(_toLower))
        {
            return false;
        }

        else
        {
            foreach(KeyValuePair<string,CamZoneTrigger> _item in items)
            { 
                _item.Value.Disable();
            }
            items[_toLower].Enable();
            return true;}
    }

   
}
