using UnityEngine;

public class ItemManaged : MonoBehaviour, IManagedItem<string, ItemManaged>
{
    [SerializeField] string id = "Toto";
    public string ItemID => id;

    public void Disable()
    {

    }

    public void Enable()
    {

    }

    public void Register()
    {

    }
}
