using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Logic.Equipment
{
    /// <summary>
    /// Хранилище экипировки игрока.
    /// </summary>
    public class Equipment : IEquipment
    {
        private readonly List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public IReadOnlyList<Item> GetAll()
        {
            return _items;
        }

        public T GetItem<T>() where T : Item
        {
            return _items.OfType<T>().FirstOrDefault();
        }
    }
}