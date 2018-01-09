using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class ClassName
    {

        private string navn;

        private string x1;

        private double x2;

        private string x3;

        private int x4;


        public string Navn
        {
            get => navn;
            set => navn = value;
        }


        public string X1
        {
            get => x1;
            set => x1 = value;
        }


        public double X2
        {
            get => x2;
            set => x2 = value;
        }


        public string X3
        {
            get => x3;
            set
            {
                try
                {
                    x3 = value;
                    GetX3();
                }
                catch (NullReferenceException)
                {
                    value = null;
                    x3 = value;
                    Console.WriteLine("X3 Feltet skal udfyldes!");
                }
            }
        }

        /// <summary>
        /// int med fejlhåndtering ved forkert antal. hvis uger ikke er mellem 1 og 52 begge tal inkluderet.
        /// </summary>
        public int X4
        {
            get => x4;

            set
            {
                //=> x4 = value;

                try
                {
                    x4 = value;
                    GetX4();
                }

                catch (ArgumentException)
                {
                    value = 0;
                    x4 = value;
                    Console.WriteLine("x4 er mellem 1 og 52!");
                }


            }
        }


        public ClassName()
        : this("Dummy", "Dummy2", 11, "Dummy3", 77)
        {

        }

        public ClassName(string navn, string x1, double x2, string x3, int x4)
        {
            
            this.navn = navn;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }


        public string GetX3()
        {
            if (X3.Length != 0)
            {
                return X3;
            }
            else
            {
                throw new NullReferenceException("Modellen navnet må ikke være tomt.");
            }
        }

        public int GetX4()
        {
            if (X4 >= 1 && X4 <= 52)
            {
                return X4;
            }
            //else
            {
                throw new ArgumentException("Uger er mellem 1 og 52");
            }
        }



        public override string ToString()
        {
            return $"{nameof(Navn)}:{Navn}, {nameof(X1)}: {X1}, {nameof(X2)}: {X2}, {nameof(X3)}: {X3}, {nameof(X4)}: {X4}";
            
        }
    }
}
