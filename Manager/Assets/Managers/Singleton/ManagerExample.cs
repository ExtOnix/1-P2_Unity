using System.Collections.Generic;

public class ManagerExample : Singleton<ManagerExample>, IManager<string, ItemManaged>
{
    Dictionary<string, ItemManaged> items = new();
    public Dictionary<string, ItemManaged> ItemsManaged => items;

    public void Add(ItemManaged _item)
    {
        items.Add(_item.ItemID.ToLower(), _item);
        _item.name += " [MANAGED]";
    }

    public void DisableItem(ItemManaged _item)
    {
        items[_item.ItemID.ToLower()].Disable();
    }

    public void DisableItem(string _key)
    {
        items[_key.ToLower()].Disable();
    }

    public void EnableItem(ItemManaged _item)
    {
        items[_item.ItemID.ToLower()].Enable();
    }

    public void EnableItem(string _key)
    {
        items[_key.ToLower()].Disable();
    }

    public void Remove(ItemManaged _item)
    {
       items.Remove(_item.ItemID.ToLower());
    }
}
