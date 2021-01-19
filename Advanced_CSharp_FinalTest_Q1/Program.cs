using System;
using System.Collections;

namespace Advanced_CSharp_FinalTest_Q1
{
    class Program
    {
       public static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber(pub);
            pub.Add(new Product
            {
                pName = "Laptop"
                
            });
            pub.Add(new Product
            {
                pName = "Mouse"
             
            });
            pub.Add(new Product
            {
                pName = "HeadPhone"
               
            });
         
        }
    }

    public delegate void EventHandler(object sender, EventArgs e);
    public class Publisher : ArrayList
    {
        public event EventHandler ItemAddInfo;
        protected virtual void OnModi(EventArgs e)
        {
            if (ItemAddInfo != null) ItemAddInfo(this, e);
        }
        public override int Add(Object product)
        {
            int added = base.Add(product);
            OnModi(EventArgs.Empty);
            return added;
        }
     
    }

    public class Subscriber
    {
        private Publisher publishers;
        public Subscriber(Publisher publisher)
        {
            this.publishers = publisher;
            publishers.ItemAddInfo += pub_ItemAddInfo;
        }
        void pub_ItemAddInfo(object sender, EventArgs e)
        {
            if (sender == null)
            {
                Console.WriteLine("No Item added to arraylist");
                return;
            }
            Console.WriteLine("Item Added to ArrayList");
        }
    
    }

    public class Product
    {
        public string pName { get; set; }
      
    }
}
