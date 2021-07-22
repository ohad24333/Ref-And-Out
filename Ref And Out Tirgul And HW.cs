using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REF_Out_Tirgul_And_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ref and Out Program

            int myInt;
            MethodWithOut(out myInt);
            MethodWithRef(ref myInt);

            int a = 1, b = 2;
            RefFunc(ref a,ref b);

            Console.WriteLine($"a = {a},b = {b}");

            int c, d;
            OutFunc(out c,out d);
            Console.WriteLine($"c = {c},d = {d}");

            #endregion

            string error;
            Console.WriteLine(ValidateValues("Ohad", "Saadia", "0523407822", "314455841", 26,out error) + error);
            Console.WriteLine(ValidateValues("Ohad", "Saadia", "05234078", "3144551", 26, out error) + error);



        }


        //ref - it's the ability to send the referance of a value type in a function
        //out - gives you the power to make sure that the function will initialize a pionter that you send

        // both helps you to save the changes of a variabls outside the function
        // in ref you dont have to treat the argumant but in out you have to initialize


        #region Ref and Out Methods

        public static void MethodWithOut(out int num)
        {
            num = 0;
        }

        public static void MethodWithRef(ref int num)
        {

        }

        public static void RefFunc (ref int a,ref int b)
        {
            a++;
            b = b * 2;
        }

        public static void OutFunc(out int a, out int b)
        {
            a = 3;
            b = 5;
        }

        #endregion

        #region Validation Methods

        public static bool ValidateValues(string name,string sureName, string phone, string id, int age ,out string error)
        {
            error = "";
            bool fix = true;

            ValidateName(name, ref error, ref fix);
            ValidateName(sureName, ref error, ref fix);
            ValidatePhone(phone, ref error, ref fix);
            ValidateId(id, ref error, ref fix);
            ValidateAge(age, ref error, ref fix);
            if (fix) return true;
            else return false;
           
        }

        public static bool ValidateName(string name , ref string error,ref bool fix)
        {
            if (name != "" || name != null) return true;
            else
            {
                error += "\n Name Is Empty";
                fix = false;
                return false;
            }
        }

        public static bool ValidatePhone(string phone ,ref string error, ref bool fix)
        {
            if (phone.Length >= 9 && phone[0] == '0') return true;
            else
            {
                error += "\n Phon Number Is Invalid";
                fix = false;
                return false;
            }
        }

        public static bool ValidateId(string id, ref string error, ref bool fix)
        {
            if (id.Length == 9) return true;
            else
            {
                error += "\n Id Is Invalid";
                fix = false;
                return false;
            }
        }

        public static bool ValidateAge(int age, ref string error, ref bool fix)
        {
            if (age > 0 && age < 100) return true;
            else
            {
                error += "\n Phone Number Is Invalid";
                fix = false;
                return false;
            }
        }

        #endregion
    }
}
