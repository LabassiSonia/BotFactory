using System;
using System.Collections.Generic;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;
using System.Threading;
using System.Diagnostics;
using Common.Interface;
using BotFactory.Models;

namespace BotFactory.Factories
{
    

    public class UnitFactory : IUnitFactory
    {
        //Fields
        private int _QueueCapacity;
        private int _StorageCapacity;
        private Queue<IFactoryQueueElement> _Queue;
        private List<ITestingUnit> _Storage;
        private int _QueueFreeSlots;
        private int _StorageFreeSlots;
        private  event FactoryStatusHandler _FactoryStatus;
        

        //Properties implementation
        public int QueueCapacity
        {
            get { return _QueueCapacity; }
        }
        public int StorageCapacity
        {
            get { return _StorageCapacity; }
        }
        public Queue<IFactoryQueueElement> Queue
        {
            get { return _Queue; }
            set { _Queue = value; }
        }
        public List<ITestingUnit> Storage
        {
            get { return _Storage; }
            set { _Storage = value; }
        }
        public int QueueFreeSlots
        {
            get { return _QueueFreeSlots; }
            set { _QueueFreeSlots = value; }
        }
        public int StorageFreeSlots
        {
            get { return _StorageFreeSlots; }
            set { _StorageFreeSlots = value; }
        }
        public TimeSpan QueueTime { get ; set; }


        public event FactoryStatusHandler FactoryStatus
        {
            add { _FactoryStatus += value; }
            remove { _FactoryStatus -= value; }
        }




        //Constructors and methods
        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            _QueueCapacity = queueCapacity;
            _StorageCapacity = storageCapacity;
            Storage = new List<ITestingUnit>(_StorageCapacity);
            Queue = new Queue<IFactoryQueueElement>(_QueueCapacity);
        }
 
        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            StorageFreeSlots = StorageCapacity - Storage.Count;
            QueueFreeSlots = QueueCapacity - Queue.Count;
           
                if (QueueFreeSlots<=0) return false;
                else
                {
                    Queue.Enqueue(new FactoryQueueElement(model.ToString(), name, parkingPos, workingPos));
                    QueueFreeSlots--;
                
                    //Construction 
                    TestingUnit bot;
                    IFactoryQueueElement element;
                    while (QueueFreeSlots<QueueCapacity && StorageFreeSlots>0)
                     {
                        lock (Storage)
                        {
                            element = Queue.Dequeue();
                            
                            QueueFreeSlots++;
                            FactoryProgress(element);
                            bot = (TestingUnit)Activator.CreateInstance(model, name, parkingPos, workingPos);
                            bot.OnStatusChanged("Creation");
                            new Thread(delegate() {Construction(bot);}).Start();
                            Monitor.Wait(Storage); 
                            Storage.Add(bot);
                            StorageFreeSlots--;
                            FactoryProgress(bot);
                        }
                    }
                return true;
                }
            }

        
        //This thread constructs a bot
        private void Construction(ITestingUnit bot)
            {
                lock (Storage)
                {
                    Thread.Sleep((int)bot.BuildTime * 1000);
                    Debug.WriteLine("Robot Construit");
                    Monitor.Pulse(Storage);
                }
            }


        public  virtual void FactoryProgress(object Bot)
        { if (_FactoryStatus != null) {
                _FactoryStatus(this, new FactoryProgressEventArgs { Bot = Bot });
            }
            
        }
    }


}

