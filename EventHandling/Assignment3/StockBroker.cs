using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class StockBroker
    {
        public string brokerName;
        List<Stock> stocks = new List<Stock>();

        public StockBroker(string name)
        {
            this.brokerName = name;
        }

        public event BrokerDelegateHandler BrokerEventHandler;
        
        public virtual void onBrokerEventChanged()
        {
            BrokerDelegateHandler handler = BrokerEventHandler;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Notify()
        {
            Console.WriteLine("{0}\t\t {1}\t\t {2}\t\t {3}", brokerName);
        }
        public void AddStock(Stock s)
        {
            //add stocks to the list
            stocks.Add(s);

            //call stock event
            s.StockThresholdReachedEvent += StockNotification();
            Console.WriteLine("Broker \t\t Stock \t\t Value \t\t Changes ");
        }

        private Stock.StockNotification StockNotification()
        {
            throw new NotImplementedException();
        }

        public delegate void BrokerDelegateHandler(Object sender, EventArgs e);
    }

   
}
