using System;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ks_executor
{
    class ks_executor : ServiceBase
    {
        /// <summary>
        /// Public Constructor for ks_executor.
        /// - Put all of your Initialization code here.
        /// </summary>
        public ks_executor m_executor = new ks_executor();
        //public ks_remote m_remote = new ks_remote();
        public ks_remote m_remote = new ks_remote();

        public void WriteLog(string Text)
        {
            FileStream fs = new FileStream(@"c:\KSExecutorService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(Text);
            m_streamWriter.Flush();
            m_streamWriter.Close();


        }

        public ks_executor()
        {
            this.ServiceName = "KS Executor";
            this.EventLog.Source = "KS Executor";
            this.EventLog.Log = "Application";
            
            // These Flags set whether or not to handle that specific
            //  type of event. Set to true if you need it, false otherwise.
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

            if (!EventLog.SourceExists("KS Executor"))
                EventLog.CreateEventSource("KS Executor", "Application");
        }

        /// <summary>
        /// The Main Thread: This is where your Service is Run.
        /// </summary>
        static void Main()
        {
            ServiceBase.Run(new ks_executor());
        }

        /// <summary>
        /// Dispose of objects that need it here.
        /// </summary>
        /// <param name="disposing">Whether or not disposing is going on.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// OnStart: Put startup code here
        ///  - Start threads, get inital data, etc.
        /// </summary>
        /// <param name="args"></param>

        public void StartServer()
        {
            TcpChannel chan = new TcpChannel(5555);
            ChannelServices.RegisterChannel(chan);
            
            WellKnownServiceTypeEntry remObj = new WellKnownServiceTypeEntry(typeof(), "Executor", WellKnownObjectMode.SingleCall);
            
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            WriteLog("KS Executor Service: Service is starting \n");

            //RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("ks_remote.RemoteObject,object"),"Executor", WellKnownObjectMode.SingleCall);
            //RemotingConfiguration.RegisterWellKnownServiceType(remObj);
            //txtOut.AppendText("Server is running...");
            //remObj.
            //USB_getStatus();

           // if(!USB_Disabled)
            //{
           //     USB_disableAllStorageDevices();
           // }
           // else if(USB_Disabled)
           // {
            //    USB_enableAllStorageDevices();
           // }

            EventLog.WriteEntry("KS Executor Service Has Started");
            WriteLog("KS Executor Service: Service Has Started \n");
        }

        /// <summary>
        /// OnStop: Put your stop code here
        /// - Stop threads, set final data, etc.
        /// </summary>
        protected override void OnStop()
        {
            base.OnStop();

            WriteLog("KS Executor Service: Service is starting \n");
            EventLog.WriteEntry("KS Executor Service Has Stopped");
            WriteLog("KS Executor Service: Service Has Stopped \n");
        }

        /// <summary>
        /// OnPause: Put your pause code here
        /// - Pause working threads, etc.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// OnContinue: Put your continue code here
        /// - Un-pause working threads, etc.
        /// </summary>
        protected override void OnContinue()
        {
            base.OnContinue();
        }

        /// <summary>
        /// OnShutdown(): Called when the System is shutting down
        /// - Put code here when you need special handling
        ///   of code that deals with a system shutdown, such
        ///   as saving special data before shutdown.
        /// </summary>
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        /// <summary>
        /// OnCustomCommand(): If you need to send a command to your
        ///   service without the need for Remoting or Sockets, use
        ///   this method to do custom methods.
        /// </summary>
        /// <param name="command">Arbitrary Integer between 128 & 256</param>
        protected override void OnCustomCommand(int command)
        {
            //  A custom command can be sent to a service by using this method:
            //#  int command = 128; //Some Arbitrary number between 128 & 256
            //#  ServiceController sc = new ServiceController("NameOfService");
            //#  sc.ExecuteCommand(command);

            base.OnCustomCommand(command);
        }

        /// <summary>
        /// OnPowerEvent(): Useful for detecting power status changes,
        ///   such as going into Suspend mode or Low Battery for laptops.
        /// </summary>
        /// <param name="powerStatus">The Power Broadcase Status (BatteryLow, Suspend, etc.)</param>
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            return base.OnPowerEvent(powerStatus);
        }

        /// <summary>
        /// OnSessionChange(): To handle a change event from a Terminal Server session.
        ///   Useful if you need to determine when a user logs in remotely or logs off,
        ///   or when someone logs into the console.
        /// </summary>
        /// <param name="changeDescription"></param>
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }

       


        
        
    }
}
