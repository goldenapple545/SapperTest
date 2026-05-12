using System.Collections.Generic;

namespace CodeBase.Logic.Equipment
{
    public interface IEquipment
    { 
        void AddItem(Item item);
        IReadOnlyList<Item> GetAll();
        T GetItem<T>() where T : Item;
    }
}
