using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class Player
    {
        // Properties (Data Members)
        public string Name;
        private int Health; // Marked as private

        // Methods (Member Functions)
        public void SetHealth(int newHealth)
        {
            Health = newHealth;
        }

        public int GetHealth() // Method to access the private Health property
        {
            return Health;
        }
    }
}
