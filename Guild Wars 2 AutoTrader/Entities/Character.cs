using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild_Wars_2_AutoTrader.Entities
{
    public class Crafting
    {
        public string discipline { get; set; }
        public int rating { get; set; }
        public bool active { get; set; }
    }

    public class Pve
    {
        public int id { get; set; }
        public List<int> traits { get; set; }
    }

    public class Pvp
    {
        public int id { get; set; }
        public List<int> traits { get; set; }
    }

    public class Wvw
    {
        public int id { get; set; }
        public List<int> traits { get; set; }
    }

    public class Specializations
    {
        public List<Pve> pve { get; set; }
        public List<Pvp> pvp { get; set; }
        public List<Wvw> wvw { get; set; }
    }

    public class Pve2
    {
        public int heal { get; set; }
        public List<int> utilities { get; set; }
        public int elite { get; set; }
    }

    public class Pvp2
    {
        public int heal { get; set; }
        public List<int> utilities { get; set; }
        public int elite { get; set; }
    }

    public class Wvw2
    {
        public int heal { get; set; }
        public List<int> utilities { get; set; }
        public int elite { get; set; }
    }

    public class Skills
    {
        public Pve2 pve { get; set; }
        public Pvp2 pvp { get; set; }
        public Wvw2 wvw { get; set; }
    }

    public class Attributes
    {
        public int Power { get; set; }
        public int Precision { get; set; }
        public int CritDamage { get; set; }
    }

    public class Stats
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Equipment
    {
        public int id { get; set; }
        public string slot { get; set; }
        public string binding { get; set; }
        public string bound_to { get; set; }
        public List<int?> infusions { get; set; }
        public Stats stats { get; set; }
        public List<int?> upgrades { get; set; }
        public int? charges { get; set; }
    }

    public class EquipmentPvp
    {
        public object amulet { get; set; }
        public object rune { get; set; }
        public List<object> sigils { get; set; }
    }

    public class Training
    {
        public int id { get; set; }
        public int spent { get; set; }
        public bool done { get; set; }
    }

    public class Inventory
    {
        public int id { get; set; }
        public int count { get; set; }
        public List<int?> upgrades { get; set; }

        public Inventory(int id, int count)
        {
            this.id = id;
            this.count = count;
        }
    }
    public class CombineInventory
    {
        public List<Inventory> combineInventory = new List<Inventory>();

        public CombineInventory(List<Inventory> inventoryList)
        {
            foreach (Inventory item in inventoryList)
            {
                if (!(item == null))
                {
                    if (combineInventory.Count.Equals(0))
                    {
                        combineInventory.Add(item);
                    }
                    else
                    {
                        if (combineInventory.Exists(x => x.id == item.id))
                        {
                            int index = combineInventory.FindIndex(x => x.id == item.id);

                            combineInventory[index].count += item.count;
                        }
                        else
                        {
                            combineInventory.Add(item);
                        }
                    }
                }
            }
        }
    }
    public class Bag
    {
        public int id { get; set; }
        public int size { get; set; }
        public List<Inventory> inventory { get; set; }

        public List<Inventory> getInventory()
        {
            return inventory;
        }
    }

    public class Character
    {
        public string name { get; set; }
        public string race { get; set; }
        public string gender { get; set; }
        public string profession { get; set; }
        public int level { get; set; }
        public string guild { get; set; }
        public int age { get; set; }
        public string created { get; set; }
        public int deaths { get; set; }
        public List<Crafting> crafting { get; set; }
        public List<string> backstory { get; set; }
        public List<object> wvw_abilities { get; set; }
        public Specializations specializations { get; set; }
        public Skills skills { get; set; }
        public List<Equipment> equipment { get; set; }
        public List<int> recipes { get; set; }
        public EquipmentPvp equipment_pvp { get; set; }
        public List<Training> training { get; set; }
        public List<Bag> bags { get; set; }
    }

}


