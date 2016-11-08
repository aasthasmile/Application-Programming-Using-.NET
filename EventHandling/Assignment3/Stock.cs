using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment3
{
    public class ThresholdReachedEventargs : EventArgs
    {
        public string stockName { get; set; }
        public int currentValue { get; set; }
        public int numberChanges { get; set; }
    }

    public class FileReachedEventargs : EventArgs
    {
        public DateTime dateAndTime { get; set; }
        public string stockName { get; set; }
        public int initialValue { get; set; }
        public int currentValue { get; set;}
    }

    class Stock
    {
        public string name;
        public int initialValue;  //stock price
        public int maxChange; //the range within a stock can change every time unit
        public int notificationThreshold; //the value to measure the change of the stock for raising the event

        public int currentValue;
        public int noofchanges=0;//number of changes in value can be sent to the listener.

        Thread thread = Thread.CurrentThread;
        

        public Stock(string name, int startingValue, int maxchange, int threshold)
        {
            this.name = name;
            this.initialValue = startingValue;
            this.currentValue = initialValue;
            this.maxChange = maxchange;   //currentValue = initialValue
            this.notificationThreshold = threshold; 
            thread = new Thread(new ThreadStart(Activate));
        }

        public void Activate()
        {
            for (;;)
            {
                //This thread causes the stock's value to be modified every 500 milliseconds. 
                Thread.Sleep(500);
                ChangeStockValue();
            }
        }
        public void ChangeStockValue()
        {
            Random random = new Random();
            currentValue +=random.Next(1,maxChange);
            noofchanges++;

            if((currentValue-initialValue)>notificationThreshold)
            {
                ThresholdReachedEventargs args = new ThresholdReachedEventargs();
                //create event Data
                args.stockName = name;
                args.currentValue = currentValue;
                args.numberChanges = noofchanges;

                onStockChangeReached(args);
            }
        }

        public delegate void StockNotification(String stockName, int currentValue, int numberChanges);


        public event StockNotification StockThresholdReachedEvent;

        protected virtual void onStockChangeReached(ThresholdReachedEventargs e)
        {
            /* StockNotification handler = StockThresholdReachedEvent;
             if (handler != null)
                 handler(this, e);*/
            StockThresholdReachedEvent?.DynamicInvoke(this, e);
        }

       

        //another event to notify saving the following information to a file 
        //when the stock's threshold is reached: date and time, stock name, inital value and current value

        public delegate void FileDelegate(Object sender ,EventArgs e);

        public event FileDelegate FileEventHandler;

        protected virtual void OnStockChangeFileCreated(FileReachedEventargs e)
        {
            FileDelegate filehandler = FileEventHandler;
            if (filehandler != null)
            {
                filehandler(this, e);
            }

        }

        public class ThresholdReachedEventargs : EventArgs
        {
            public string stockName { get; set; }
            public int currentValue { get; set; }
            public int numberChanges { get; set; }
        }


    }
}
