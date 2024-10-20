using System;
using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Inventory : Node
    {
        [Export] public Godot.Collections.Array<Consumable> Consumables = new();
        [Export] public Godot.Collections.Array<Armor> Armors = new();
        [Export] public Godot.Collections.Array<Weapon> Weapons = new();
        [Export] public Godot.Collections.Array<Keys> Keys = new();
        // SLOT 0 = WEAPON
        // SLOT 1 = OFFHAND
        // SLOT 2 HAT
        // SLOT 3 HELMET
        // SLOT 4 CHEST
        // SLOT 5 LEG
        // SLOT 6 FOOT
        // SLOT 7 ARM
        // SLOT 8 NECK 
        [Export] public Item[] Equiped = new Item[9];
        public Stats StatIncrease = new();

        public override void _Ready()
        {
            foreach(Item i in Equiped) {
                if (i is Weapon w) StatIncrease += w.StatIncrease;
                if (i is Armor a) StatIncrease += a.StatIncrease;
            }
            base._Ready();
        }

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


        /// <returns>Returns index of the item in the inventory or -1 if it does not exist</returns>
        public int IndexOfItem(Item i)
        {
            if (i is Armor a) 
                return Armors.IndexOf(a);
            
            if (i is Weapon w)
                return Weapons.IndexOf(w);

            if (i is Consumable c)
                return Consumables.IndexOf(c);
            
            if (i is Keys k)
                return Keys.IndexOf(k);

            return -1;
        }

        public void RemoveItemFromInventory(Item i) 
        {
            var index = IndexOfItem(i);
            if (index != -1)
            {
                if (i is Weapon w) {
                    Weapons.RemoveAt(index);
                    return;
                } 

                if (i is Armor a) {
                    Armors.RemoveAt(index);
                    return;
                }

                if (i is Consumable c) {
                    Consumables.RemoveAt(index);
                    return;
                }

                if (i is Keys k) {
                    Keys.RemoveAt(index);
                    return;
                }
            }
            throw new Exception("Item, " + i + " does not exist in this inventory.");
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

                StatIncrease += a.StatIncrease;
            }

            if (i is Weapon w) {
                Equiped[0] = w;
                StatIncrease += w.StatIncrease;
            }
        }

        public void Unequip(Item i) {
            if (i is Armor a) {
                if (a.ArmorType == ArmorType.HAT) Equiped[2] = null;
                if (a.ArmorType == ArmorType.HELMET) Equiped[3] = null;
                if (a.ArmorType == ArmorType.CHEST) Equiped[4] = null;
                if (a.ArmorType == ArmorType.LEG) Equiped[5] = null;
                if (a.ArmorType == ArmorType.FOOT) Equiped[6] = null;
                if (a.ArmorType == ArmorType.ARM) Equiped[7] = null;
                if (a.ArmorType == ArmorType.NECK) Equiped[8] = null;

                StatIncrease -= a.StatIncrease;
            }

            if (i is Weapon w) {
                Equiped[0] = null;
                StatIncrease -= w.StatIncrease;
            }
        }

        public void Save()
        {
        }
    }
}