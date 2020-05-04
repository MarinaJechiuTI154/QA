using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Algorithms_DataStruct_Lib.hash_tables
{
    public class PhoneNumber
    {
        public string AreaCode { get; }
        public string Exchange { get; }
        public string Number { get; }

        public PhoneNumber(string areaCode, string exchange, string number)
        {
            AreaCode = areaCode;
            Exchange = exchange;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            var numebr = obj as PhoneNumber;
            if (numebr == null)
                return false;
            return string.Equals(AreaCode, numebr.AreaCode)
                   && string.Equals(Exchange, numebr.Exchange)
                   && string.Equals(Number, numebr.Number);
        }

        public static bool operator == (PhoneNumber left, PhoneNumber right)
        {
            if (object.ReferenceEquals(left, right))
                return true;
            if (object.ReferenceEquals(null, left))
                return false;
            return left.Equals(right);
        }
        public static bool operator !=(PhoneNumber left, PhoneNumber right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int) 2166136261;
                const int HashingMultiplier = 167777619;
                int hash = HashingBase;

                // ^ - XOR operator
                hash = (hash * HashingMultiplier) ^
                       (!object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^
                       (!object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^
                       (!object.ReferenceEquals(null, Number) ? Number.GetHashCode() : 0);
                return hash;
            }
        }
        
    }

    public class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public int Ssn { set; get; }


    }
}
