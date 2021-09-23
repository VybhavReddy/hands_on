using System;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace bill_generayion
{
    class Eb_bill_entry
    {
        public int consumer_no { get; set; }
        public string consumer_name { get; set; }
        public int totalunits { get; set; }
        public double per_unit_cost { get; set; }
        public double total_amount { get; set; }
    }
    class bill_form
    {
        public int bill_number { get; set; }
        public int consumer_num { get; set; }
        public double total_amt { get; set; }
        public string duedate { get; set; }
        public void print()
        {
            Console.WriteLine("Bill no.: {0}\nConsumer no.: {1}\nTotal amount: {3}\nDuedate: {4}", bill_number, consumer_num, total_amt, duedate);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of consumers");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayList arr = new ArrayList();
            for (int i = 1; i <= n; i++)
            {
                Eb_bill_entry obj = new Eb_bill_entry();
                bill_form bill_obj = new bill_form();
                Console.WriteLine("Enter details of Consumer {0}", i);
                Console.WriteLine("Enter Consumer number: ");
                obj.consumer_no=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Consumer name");
                obj.consumer_name = Console.ReadLine();
                Console.WriteLine("Enter total number of units");
                obj.totalunits = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter cost per unit");
                obj.per_unit_cost = Convert.ToDouble(Console.ReadLine());
                obj.total_amount = obj.totalunits * obj.per_unit_cost;
                
                Random ra = new Random();
                bill_obj.bill_number = ra.Next(9000000, 9999999);
                bill_obj.consumer_num = obj.consumer_no;
                Random dat = new Random();
                bill_obj.duedate= (DateTime.Now).AddDays(dat.Next(1,9)).ToString();
                bill_obj.total_amt = obj.total_amount;
                arr.Add(bill_obj);
            }
            FileStream fs = new FileStream(@"C:\c# training\EB.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            foreach (bill_form obj in arr)
            {
                sr.WriteLine("Printing details of Consumer number: {0}", obj.consumer_num);
                sr.WriteLine("Bill number: {0}", obj.bill_number);
                sr.WriteLine("Total amount in Rupees: {0}", obj.total_amt);
                sr.WriteLine("Due Date: " + obj.duedate);
                sr.WriteLine("***********************************************************");
            }
            sr.Close();
            fs.Close();
        }
    }
}
