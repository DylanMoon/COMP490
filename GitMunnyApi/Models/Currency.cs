using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace GitMunnyApi.Models
{
    public sealed class Currency
    {
        public decimal Amount { get; }
        public CultureInfo Culture { get; }

        public Currency(decimal amount) : this(amount, System.Globalization.CultureInfo.CurrentCulture){}
        
        public Currency(decimal amount, CultureInfo culture){
            Amount = amount;
            Culture = culture;
        }

        public override string ToString()
        {
            return Amount.ToString("C", Culture);
        }

        //TODO: probably don't need all the operator overloads....

        public static Currency operator +(Currency a, Currency b){
            return new Currency (a.Amount + b.Amount, a.Culture);
        }
        
        public static Currency operator +(Currency a, decimal b){
            return new Currency (a.Amount + b, a.Culture);
        } 
        
        public static Currency operator +(decimal a, Currency b){
            return new Currency (a + b.Amount, b.Culture);
        }

        public static Currency operator -(Currency a, Currency b){
            return new Currency (a.Amount - b.Amount, a.Culture);
        }

        public static Currency operator -(Currency a, decimal b){
            return new Currency (a.Amount - b, a.Culture);
        } 
        
        public static Currency operator -(decimal a, Currency b){
            return new Currency (a - b.Amount, b.Culture);
        }

        public static Currency operator *(Currency a, Currency b){
            return new Currency (a.Amount * b.Amount, a.Culture);
        }

        public static Currency operator /(Currency a, Currency b){
            return new Currency (a.Amount * b.Amount, a.Culture);
        }
    }
}