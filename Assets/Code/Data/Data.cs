﻿/// <summary>
/// Class containing all JSON data locally.
/// </summary>
public static class Data {
    #region Fields

    public static Item[] Items;

    #endregion

    #region Methods

    public static Item GetItemData (string id) {
        Item data = null;
        foreach (var item in Items) {
            if (item.name == id) {
                data = item;
            }
        }

        return data;
    }

    #endregion
}