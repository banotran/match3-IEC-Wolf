using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    public override void SetView()
    {
        base.SetView();

        if (View != null)
        {
            var sprRend = View.GetComponent<SpriteRenderer>();
            if (sprRend != null) {
                sprRend.sprite = Board.GameSettings.GetItemSprite(Board.ThemeId, (int)ItemType);
            }
        }
    }

    protected override string GetPrefabName()
    {
        string prefabname = Constants.PREFAB_NORMAL;
        return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
