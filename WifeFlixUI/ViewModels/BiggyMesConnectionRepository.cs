using Biggy;
using Biggy.Core;
using Biggy.Data.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace WpfUI
{
    public class BiggyMesConnectionRepository 
    {
        private BiggyList<MesConnectionSettings> _list;

        public List<MesConnectionSettings> listConnection { get; set; }


             


        public BiggyMesConnectionRepository()
        {
            var _storeLocation = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CONFIG");
            _list = new BiggyList<MesConnectionSettings>(new JsonStore<MesConnectionSettings>(_storeLocation, "MesConnections"));

            listConnection = _list.ToList();


            //GetAll();
            //var mylist = _list.ToList();
            //GetMesConnectionById("Test_1");

       }




        public IQueryable<MesConnectionSettings> All()
        {

            return _list.AsQueryable<MesConnectionSettings>();
        }

       /// <summary>
        /// Add new alarm
        /// </summary>
        /// <param name="user"></param>
        public MesConnectionSettings Save(MesConnectionSettings alarm)
        {

            alarm.Id = Guid.NewGuid().ToString();
            _list.Add(alarm);
            return alarm;  // we neeed to return the alarm so we can log the acknowledge action
        }
        

        public MesConnectionSettings GetMesConnectionById(string name)
        {
            var myMesConnetion = _list.SingleOrDefault(c => c.Name == name);


            return myMesConnetion;
        }


        public MesConnectionSettings AddMesConnection(MesConnectionSettings nnw, out bool isAddResult)
        {

            MesConnectionSettings mesConnetion = new MesConnectionSettings();

            mesConnetion.Id = Guid.NewGuid().ToString();
            mesConnetion.Name = nnw.Name;
            mesConnetion.HostName = nnw.HostName;
            mesConnetion.Channel = nnw.Channel;
            mesConnetion.Port = nnw.Port;
            mesConnetion.QueueManager = nnw.QueueManager;
            mesConnetion.AccessQueue = nnw.AccessQueue;
            mesConnetion.ReplyQueue = nnw.ReplyQueue;
            mesConnetion.WaitForResponseInterval = nnw.WaitForResponseInterval;
            mesConnetion.MaxSendAttempts = nnw.MaxSendAttempts;
            mesConnetion.MessageExpiry = nnw.MessageExpiry;
            mesConnetion.ComputerName = System.Environment.MachineName.ToString();
            mesConnetion.MaxResponseAttempts = nnw.MaxResponseAttempts;
            mesConnetion.IsMessageSavingEnabled = nnw.IsMessageSavingEnabled;
            mesConnetion.Environment = nnw.Environment;
            mesConnetion.PlantID = nnw.PlantID;

            _list.Add(mesConnetion);

            isAddResult = true;
            return mesConnetion;

        }

        public MesConnectionSettings UpdateMesConnetion(MesConnectionSettings nnw, out bool isUpdatedResult)
        {
            
            var mesConnetion = _list.SingleOrDefault(c => c.Name == nnw.Name);
            mesConnetion.Name = nnw.Name;
            mesConnetion.HostName = nnw.HostName;
            mesConnetion.Channel = nnw.Channel;
            mesConnetion.Port = nnw.Port;
            mesConnetion.QueueManager = nnw.QueueManager;
            mesConnetion.AccessQueue = nnw.AccessQueue;
            mesConnetion.ReplyQueue = nnw.ReplyQueue;
            mesConnetion.WaitForResponseInterval = nnw.WaitForResponseInterval;
            mesConnetion.MaxSendAttempts = nnw.MaxSendAttempts;
            mesConnetion.MessageExpiry = nnw.MessageExpiry;
            mesConnetion.ComputerName = System.Environment.MachineName.ToString();
            mesConnetion.MaxResponseAttempts = nnw.MaxResponseAttempts;
            mesConnetion.IsMessageSavingEnabled = nnw.IsMessageSavingEnabled;
            mesConnetion.Environment = nnw.Environment;
            mesConnetion.PlantID = nnw.PlantID;

            _list.Update(mesConnetion);
            Console.WriteLine("Saved------------------------------------------------------------------------");

            isUpdatedResult = true;
            return mesConnetion;
        }


        public MesConnectionSettings DeleteMesConnetion(string Id, out bool isUpdatedResult)
        {
            var mesConnetion = _list.SingleOrDefault(c => c.Id == Id);

            _list.Remove(mesConnetion);
            listConnection.Remove(mesConnetion);
            isUpdatedResult = true;
            return mesConnetion;

        }


    }
}
