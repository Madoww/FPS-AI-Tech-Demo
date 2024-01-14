using FPS.Core.Character.Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Player.Handlers
{
    public class InventoryHandler : PlayerHandler
    {
        public event Action OnItemAppended;
        public event Action OnItemRemoved;

        private readonly List<InventoryItemData> items = new List<InventoryItemData>();
        private readonly Dictionary<ItemData, InventoryItemData> itemsByType = new Dictionary<ItemData, InventoryItemData>();

        public void AppendItem(ItemData item)
        {
            if (!itemsByType.TryGetValue(item, out var inventoryItemData))
            {
                inventoryItemData = new InventoryItemData()
                {
                    Item = item,
                    Count = 1
                };
                itemsByType.Add(item, inventoryItemData);
                OnItemAppended?.Invoke();
                return;
            }

            itemsByType[item].Count++;
            OnItemAppended?.Invoke();
        }

        public void RemoveItem(ItemData item)
        {
            if (!itemsByType.TryGetValue(item, out var inventoryItemData))
            {
                Debug.LogWarning("Tried to remove item that's not in inventory");
                return;
            }

            var newCount = --inventoryItemData.Count;
            if (newCount == 0)
            {
                itemsByType.Remove(item);
            }
            OnItemRemoved?.Invoke();
        }
    }
}