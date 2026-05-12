namespace CodeBase.Logic.Equipment
{
    public abstract class Item: IEquipmentItem
    { 
        public string Name { get; }
        
        public Item(string name)
        { 
            Name = name;
        }
    }
}