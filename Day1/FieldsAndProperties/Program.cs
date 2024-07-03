namespace FieldsAndProperties
{
    internal class Program
    {
        static void Main()
        {
            //int i; //local variables are unassigned
           // Console.WriteLine(i);  //error
            Class1 o1 = new Class1();
            //o1.SetI(10);
            //Console.WriteLine(o1.GetI());

            //o1.i = ++o1.i + o1.i++ - --o1.i - o1.i--;
            o1.I = ++o1.I + o1.I++ - --o1.I - o1.I--; 
            o1.I = 1000;  //set
            Console.WriteLine(o1.I);  //get
            o1.Prop3 = "aa";
            Console.WriteLine(o1.Prop3);

            //o1.Prop4 = "a"; //error
        }
    }

    //WHY property? ---? validations
    public class Class1
    {
        //class level variable - field
        //private int i; //initialised to their default value
        //public void SetI(int VALUE)  //dont ever write a setter/getter
        //{
        //    if (VALUE < 100)
        //        i = VALUE;
        //    else
        //        //throw new Exception("invalid value for i");
        //        Console.WriteLine("invalid value for i");
        //}
        //public int GetI()
        //{
        //    return i;
        //}
        private int i;
        public int I  //property
        {
            set 
            { 
                if(value <100)
                    i = value;
                else
                    Console.WriteLine("invalid value");
            }
            get 
            {
                return i;
            }
        }
        private string prop1;
        public string Prop1
        {
            set
            {
                prop1 = value;
            }
            get
            {
                return prop1;
            }
        }

        public string Prop2;  //field
                              
        //auto generated property - auto/automatic
        //no validations
        //compiler generates the code for get and set.
        //also generates the private variable
        public string Prop3 { get; set; }

        //readonly property
        private string prop4="AA";
        public string Prop4
        {
            get { return prop4; }
        }
    }
}
