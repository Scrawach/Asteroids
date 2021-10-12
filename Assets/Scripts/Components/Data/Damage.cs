using System;

namespace Components.Data
{
    public class Damage
    {
        private readonly int _value;
        
        public Damage(int value)
        {
            if (value <= 0)
                throw new NotValidDamageValueException();
            _value = value;
        }

        public static implicit operator int(Damage damage) => damage._value;

        private class NotValidDamageValueException : Exception { }
    }
}