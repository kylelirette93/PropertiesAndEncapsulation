using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PropertiesAndEncapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Game character.
            GameCharacter hero = new GameCharacter();
            Console.WriteLine(hero.Name); // Should show "Hero".
            hero.Health = 100;
            Console.WriteLine(hero.IsAlive); // Should show true.
            hero.Health = -10; // Invalid, clamps to 0.
            Console.WriteLine(hero.Health); // Should show 0.
            Console.WriteLine(hero.IsAlive); // Should show false.

            // Test the inventory.
            Inventory backpack = new Inventory(20);
            Console.WriteLine(backpack.Capacity); // Should be 20.
            backpack.ItemCount = 10;
            Console.WriteLine(backpack.IsFull); // Should be false.
            backpack.ItemCount = 30; // Clamps to capacity.
            Console.WriteLine(backpack.ItemCount); // Should be 20.
            Console.WriteLine(backpack.IsFull); // Should be true.
            backpack.Gold = -5; // Invalid, clamps to 0.
            Console.WriteLine(backpack.Gold); // Should be 0.

            // Test the power-up.
            PowerUp speedBoost = new PowerUp("Speed", 10.0f);
            Console.WriteLine(speedBoost.Name); // Should be "Speed".
            Console.WriteLine(speedBoost.IsActive); // should be true.
            speedBoost.Duration = 0; // Deactivate speed boost.
            Console.WriteLine(speedBoost.IsActive); // Should be false.

        }
    }

    class GameCharacter
    {
        public GameCharacter(string name = "Hero")
        {
            Name = name;
        }
        // Auto implemented, read only property for Name.
        public string Name { get; }

        // Full property with validation.
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                // Clamp health values between 0 and 100.
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > 100)
                {
                    health = 100;
                }
                else
                {
                    health = value;
                }
            }
        }
        // Computed property.
        public bool IsAlive
        {
            // If health is greater than 0, player is alive.
            get { return health > 0; }
        }
    }

    class Inventory
    {
        public Inventory(int capacity = 20)
        {
            Capacity = capacity;
        }

        // Full property with validation.
        private int gold;
        public int Gold
        {
            get { return gold; }
            set
            {
                // Prevent negative values for gold.
                if (value < 0)
                {
                    gold = 0;
                }
                else
                {
                    gold = value;
                }
            }
        }
        // Auto implemented, read only property.
        public int Capacity { get; }

        // Full property with validation.
        private int itemCount;
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                // Clamp items within inventory capacity.
                if (value < 0)
                {
                    itemCount = 0;
                }
                else if (value > Capacity)
                {
                    itemCount = Capacity;
                }
                else
                {
                    itemCount = value;
                }
            }
        }
        // Computed property.
        public bool IsFull
        {
            // If item count is greater than or equal to inventory capacity, it's full.
            get
            { return itemCount >= Capacity; }
        }
    }

    class PowerUp
    {
        // Constructor, passing name and duration to properties.
        public PowerUp(string name = "Boost", float duration = 0)
        {
            Name = name;
            Duration = duration;
        }

        // Auto implemented, read only property.
        public string Name { get; }

        // Full property with validation.
        private float duration;
        public float Duration
        {
            // Ensure duration won't be negative.
            get { return duration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Duration must be greater than or equal to 0.");
                }
                duration = value;
            }
        }

        public bool IsActive
        {
            // If duration is greater than 0, powerup is active.
            get { return duration > 0; }
        }
    }
}



