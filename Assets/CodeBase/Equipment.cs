using System.Collections.Generic;

namespace CodeBase
{
    public class Equipment : IEquipment
    {
        private readonly List<Item> _items = new List<Item>();
        public void AddItem(Item item)
        { 
            _items.Add(item);
        }
    }
}