using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateLibrary;

namespace RealEstateLibrary
{
    public class Validate // Validate Class used for validated strings and other inputs 
    {

        public bool ValidateString(string toValidate) // public ValidateString function that returns a bool and accepts a string as a parameter
        {
            if (toValidate == "" || toValidate == null) // if toValidate is empty or it is null then
            {
                return false; // returns flase
            }
            //else toValidate was not empty or not null
            return true; // returns true
        }

        public bool ValidateNumber(string toValidate) // public ValidateNumber function that returns a bool and accepts a string as a parameter
        {
            bool isValidNumber = long.TryParse(toValidate, out _); // bool isValidNumber variable set to the returned value of the long TryParse function with toValidate as the first parameter and out _ as the second parameter, the second parameter being out _ means that the converted long number does not get outputted to any variable 
            return isValidNumber; // returns isValidNumber

        }

        public bool ValidateDecimal(string toValidate) // public ValidateDecimal function that returns a bool and accepts a string as a parameter
        {
            bool isValidDecimal = decimal.TryParse(toValidate, out _); // bool isValidDecimal variable set to the returned value of the long TryParse function with toValidate as the first parameter and out _ as the second parameter, the second parameter being out _ means that the converted decimal number does not get outputted to any variable 
            return isValidDecimal; // returns isValidDecimal
        }

        public bool ValidateInt(string toValidate) // public ValidateInt function that returns a bool and accepts a string as a parameter
        {
            bool isValidInt = int.TryParse(toValidate, out _); // bool isValidInt variable set to the returned value of the int TryParse function with toValidate as the first parameter and out _ as the second parameter, the second parameter being out _ means that the converted int does not get outputted to any variable 
            return isValidInt; // returns isValidNumber
        }

        public bool ValidateWord(string toValidate) // public ValidateWord function that returns a bool and accepts a string as a parameter
        {
            foreach (char characater in toValidate) // foreach character called character in the string toValidate do
            {
                if (char.IsDigit(characater)) // if the current character is a digit then
                {
                    return false; // returns false
                }
            }
            //else all the characters in the string were not digits
            return true; // returns true
        }

        public bool ValidatePhoneNumber(string toValidate) // public ValidatePhoneNumber function that returns a bool and accepts a string as a parameter
        {
            string allowedCharacters = "0123456789-()+"; // string allowedCharacters set to 0123456789-()+, this will be looped through to verify that every character is one of these
            foreach (char characater in toValidate) // foreach character called character in the string toValidate do
            {
                foreach (char validChar in allowedCharacters) // foreach character called validChar in the string allowedCharacters do
                {
                    if (characater == validChar) // if character is equal to validChar then
                    {
                        return true; // returns true
                    }
                }
            }
            //else there was a character that was not in allowedCharacters
            return false; // returns false
        }

        public bool ValidateTime(string toValidate) // public ValidateTime function that returns a bool and accepts a string as a parameter
        {
            string allowedCharacters = "0123456789:"; // string allowedCharacters set to 0123456789:, this will be looped through to verify that every character is one of these
            foreach (char characater in toValidate) // foreach character called character in the string toValidate do
            {
                foreach (char validChar in allowedCharacters) // foreach character called validChar in the string allowedCharacters do
                {
                    if (characater == validChar) // if character is equal to validChar then
                    {
                        return true; // returns true
                    }
                }
            }
            //else there was a character that was not in allowedCharacters
            return false; // returns false
        }



    }
}
