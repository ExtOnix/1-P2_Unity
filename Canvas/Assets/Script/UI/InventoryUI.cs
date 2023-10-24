using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] InventoryButton inventoryItem = null;
    [SerializeField] Transform inventoryContent = null;

    public bool IsValid => inventoryItem && inventoryContent;

    private void Awake()
    {
        NetworkFetcher.OnDeals += GenerateInventory;
    }
    //void Start() => GenerateInventory();
    void ClearTransform(Transform _tr)
    {
        for (int i = 0; i < _tr.childCount; i++)
        {
            Destroy(_tr.GetChild(i).gameObject);
        }
    }
    void GenerateInventory(Deal[] _deals)
    {
        ClearTransform(inventoryContent);
        for (int i = 0; IsValid && i < 10; i++)
        {
            int _index = i;
            InventoryButton _button = Instantiate(inventoryItem,inventoryContent);
            _button.Init($"{_deals[_index].Title}", () => Debug.Log($"{_deals[_index].SalePrice}$"));
        }
    }

    private void OnDestroy()
    {
        NetworkFetcher.OnDeals -= GenerateInventory;
    }
}
