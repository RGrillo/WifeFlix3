using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfUI
{

    /// <summary>
    /// Stores MES Connection Settings
    /// </summary>
    public class MesConnectionSettings 
    {

        public string Id { get; set;  }

        /// <summary>
        /// Friendly name of the connection setting
        /// </summary>
        public string Name { get; set; }

        public string HostName { get; set; }
        public string Channel { get; set; }
        public int Port { get; set; }
        public string QueueManager { get; set; }
        public string AccessQueue { get; set; }
        public string ReplyQueue { get; set; }

        /// <summary>
        /// Number of milliseconds to wait when attempting to get from queue
        /// </summary>
        public int WaitForResponseInterval { get; set; }

        public int MaxSendAttempts { get; set; } 
        public int MessageExpiry { get; set; }
        public string ComputerName { get; set; }
        public int MaxResponseAttempts { get; set; }
        public string MessagesSavePath { get; set; }
        public bool IsMessageSavingEnabled { get; set; }
        public string Environment { get; set; }
        //public string MessageSource { get; set; }
        public string PlantID { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
