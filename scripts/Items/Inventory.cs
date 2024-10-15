using System;
using Godot;

namespace Entities
{
    public partial class Inventory : Node
    {
        public Godot.Collections.Array<Consumable> Consumables = new();
        public Godot.Collections.Array<Armor> Armors = new();
        public Godot.Collections.Array<Weapon> Weapons = new();
        public Godot.Collections.Array<Keys> Keys = new();

        // SLOT 0 = WEAPON
        // SLOT 1 = OFFHAND
        // SLOT 2 HAT
        // SLOT 3 HELMET
        // SLOT 4 CHEST
        // SLOT 5 LEG
        // SLOT 6 FOOT
        // SLOT 7 ARM
        // SLOT 8 NECK 
        public Item[] Equiped = new Item[9];

        public bool AddItemToInventory(Item i)
        {
            if (i is Armor a) 
            {
               Armors.Add(a);
               return true;
            }            

            if (i is Weapon w)
            {
                Weapons.Add(w);
                return true;
            }

            if (i is Consumable c)
            {
                Consumables.Add(c);
                return true;
            }

            if (i is Keys k)
            {
                Keys.Add(k);
                return true;
            }

            return false;
        }

        public bool InventoryContainsItem(Item i)
        {
            if (i is Armor a) 
                return Armors.Contains(a);
            
            if (i is Weapon w)
                return Weapons.Contains(w);

            if (i is Consumable c)
                return Consumables.Contains(c);
            
            if (i is Keys k)
                return Keys.Contains(k);

            return false;
        }

        public void RemoveItemFromInventory(Item i) 
        {
            if (InventoryContainsItem(i))
            {

            }
        }

        public void Equip(Item i)
        {
            if (i is Armor a) {
                if (a.ArmorType == ArmorType.HAT) Equiped[2] = a;
                if (a.ArmorType == ArmorType.HELMET) Equiped[3] = a;
                if (a.ArmorType == ArmorType.CHEST) Equiped[4] = a;
                if (a.ArmorType == ArmorType.LEG) Equiped[5] = a;
                if (a.ArmorType == ArmorType.FOOT) Equiped[6] = a;
                if (a.ArmorType == ArmorType.ARM) Equiped[7] = a;
                if (a.ArmorType == ArmorType.NECK) Equiped[8] = a;
            }

            if (i is Weapon w) {
                Equiped[0] = w;
            }
        }
    }
}