using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ShopClass
{
    public string catalogVersion = "";
    public string itemClass = "";
    public string itemId = "";
    public string itemInstanceId = "";
    public string virtualCurrency = "";
    public uint price = 0;
}

[CreateAssetMenu(fileName = "ShopDataBase", menuName = "ScriptableObjects/ShopDataBase")]
public class ShopDataBase : ScriptableObject
{
    [Title("GooglePlay")]
    [ShowInInspector]
    private ShopClass removeAds;

    [Space]
    [Title("Item")]
    [ShowInInspector]
    private List<ShopClass> itemList = new List<ShopClass>();

    public void Initialize()
    {
        itemList.Clear();
    }

    public List<ShopClass> ItemList
    {
        get
        {
            return itemList;
        }
    }


    public ShopClass RemoveAds
    {
        get
        {
            return removeAds;
        }
        set
        {
            removeAds = value;
        }
    }

    public void SetItem(ShopClass shopClass)
    {
        itemList.Add(shopClass);

        itemList = Enumerable.Reverse(itemList).ToList();
    }

    public void SetItemInstanceId(string itemid, string instanceid)
    {
        for(int i = 0; i < itemList.Count; i ++)
        {
            if(itemList[i].itemId.Equals(itemid))
            {
                itemList[i].itemInstanceId = instanceid;
            }
        }
    }

    public string GetItemInstanceId(string itemid)
    {
        string itemInstanceId = "";

        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemId.Equals(itemid))
            {
                itemInstanceId = itemList[i].itemInstanceId;
            }
        }

        return itemInstanceId;
    }
}
