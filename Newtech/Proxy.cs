using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
namespace Newtech
{
    public class Proxy
    {
        public event Terminated SessionStarted;
        public event Terminated SessionTerminated;
        object OldSettings;
        string host;
        int Serverport;
        uint Cientport;
        Dictionary<string, AuthenticationMethod> auth;


        bool verbose;
        bool auto_store_sshkey;
        bool NoShell;
        bool _open;
        bool closed;
        SshClient ssh;
        Thread Check;
        /// <summary>
        /// returns whether the ssh connection is live and open
        /// </summary>
        public bool Open { get { return _open; } }
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;
        private TimeSpan keepalive;
        public Queue<object> errors;
        void CheckBool()
        {
            if (ssh.IsConnected)
                this.SessionStarted(this, new ProxyInfo(this.ToString()));
            while (ssh.IsConnected)
            {
                Thread.Sleep(2);
            }
            this.SessionTerminated(this, new ProxyInfo(this.ToString()));

        }
        /// <summary>
        /// Ensures all threads close
        /// </summary>
        public void Dispose()
        {
            if (Check!=null &&Check.IsAlive)
                Check.Abort();
            if (ssh != null)
            {
                if (ssh.IsConnected)
                    ssh.Disconnect();
                ssh.Dispose();
            }

        }
        /// <summary>
        /// sets target port and listening port to defaults (22,8080)
        /// </summary>
        public Proxy()
        {
            host = "";
            Serverport = 22;
            Cientport = 8080;
            auth = new Dictionary<string, AuthenticationMethod>();
            closed = true;
            verbose = false;
            NoShell = false;
            auto_store_sshkey = false;
            Check = new Thread(CheckBool);
            this.SessionTerminated += Proxy_SessionTerminated;
            this.SessionStarted += Proxy_SessionStarted;
            keepalive = new TimeSpan(0, 0, 20);
            errors = new Queue<object>();
        }
        SshClient setupThis()
        {
            var S = new SshClient(new ConnectionInfo(this.host, this.Serverport, this.auth["password"].Username, new AuthenticationMethod[] { auth["password"] }));
            // ssh = new SshClient(new ConnectionInfo("rhys.rklyne.net", 4243, "rhys", new AuthenticationMethod[] { new PasswordAuthenticationMethod("rhys", "eust0n1c") }));
            return S;
        }
        /// <summary>
        /// sets the proxy to auto store ssh keys, currently redundant
        /// </summary>
        /// <param name="h">proxy to auto store ssh keys</param>
        /// <returns>Amended object</returns>
        public Proxy AutoStoreSshkey(bool h)
        {
            auto_store_sshkey = h; return this;
        }
        /// <summary>
        /// sets duration of the heart beat
        /// </summary>
        /// <param name="h">duration</param>
        /// <returns>Amended object</returns>
        public Proxy KeepAlive(TimeSpan h)
        {
            keepalive = h; return this;
        }
        /// <summary>
        /// Hides The Shell
        /// </summary>
        /// <param name="h">whether the proxy shell should be hidden</param>
        /// <returns>Amended object</returns>
        public Proxy TurnOffShell(bool h)
        {
            NoShell = h; return this;
        }
        /// <summary>
        /// Sets the Proxy into verbose mode
        /// </summary>
        /// <param name="h">whether the proxy should be verbose</param>
        /// <returns>Amended object</returns>
        public Proxy Verbose(bool h)
        {
            verbose = h; return this;
        }
        /// <summary>
        /// Sets the ssh server you want to conect to
        /// </summary>
        /// <param name="h">Host Name</param>
        /// <returns>Amended object</returns>
        public Proxy sethost(string h)
        {
            host = h;
            return this;
        }
        /// <summary>
        /// Sets the ssh port to listion on
        /// </summary>
        /// <param name="h">Port</param>
        /// <returns>Amended object</returns>
        public Proxy setCientport(string h)
        {
            Cientport = Convert.ToUInt32(h);
            return this;
        }
        /// <summary>
        /// sets the ssh port to conect to
        /// </summary>
        /// <param name="h">port</param>
        /// <returns>Amended object</returns>
        public Proxy setServerport(string h)
        {
            Serverport = Convert.ToInt32(h);
            return this;
        }

        /// <summary>
        /// sets the ssh username & password
        /// </summary>
        /// <param name="h">password</param>
        /// <returns>Amended object</returns>
        public Proxy setlogin(string username, string password)
        {

            auth["password"] = new PasswordAuthenticationMethod(username, password);
            return this;
        }
        public void resetLan()
        {
            if (!Open)
            ChangeLanProxySettings(0, OldSettings);
        }

        private void ChangeLanProxySettings(int on, object proxsettings)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            if (on == 1)
                OldSettings = registry.GetValue("ProxyServer");
            registry.SetValue("ProxyEnable", on);//turn on off
            registry.SetValue("ProxyServer", proxsettings);//chane the settings
            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to really update
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

        }




        /// <summary>
        /// starts the ssh conection and changes lan proxy settings
        /// </summary>
        public void Start()
        {

            Console.WriteLine("[Runtime]StartingSsh...");
            startssh();
            closed = false;
            Console.WriteLine("[Runtime]Changing LAN Proxy...");
            ChangeLanProxySettings(1, String.Format("socks=LOCALHOST:{0}", Cientport));
        }
        /// <summary>
        /// stops ssh and reverts the lan proxy settings (note this Wont Halt to wait for changes)
        /// </summary>
        /// 
        public void Stop()
        {
            Console.WriteLine("[Runtime]Closing SSH...");
            if (ssh.IsConnected)
            {
                ssh.Disconnect();
            }

            _open = false;
            
            ChangeLanProxySettings(0, (this.OldSettings == null) ? "" : OldSettings);
            Console.WriteLine("[Runtime]Returned LAN Proxy");

        }

        void startssh()
        {
            ssh = setupThis();
            if (verbose)
                ssh.HostKeyReceived += (object sender, Renci.SshNet.Common.HostKeyEventArgs e) => { Console.WriteLine(String.Join(" ,", new object[] { e.CanTrust, e.FingerPrint, e.HostKey, e.HostKeyName, e.KeyLength, e.ToString() })); };

            try { ssh.Connect(); }
            catch (Exception e) { errors.Enqueue(e); }

            ssh.ErrorOccurred += (object sender, Renci.SshNet.Common.ExceptionEventArgs e) => { errors.Enqueue(e); };


            Check.Start();
            //if (ssh.IsConnected)
            ssh.AddForwardedPort(new ForwardedPortDynamic("localhost", this.Cientport));
            if (ssh.IsConnected)
                foreach (var f in ssh.ForwardedPorts)
                {
                    if (verbose)
                        f.RequestReceived += (object sender, Renci.SshNet.Common.PortForwardEventArgs e) => { Console.WriteLine(String.Join(" ", new object[] { e.OriginatorHost, e.OriginatorPort, e.ToString() })); };
                    f.Start();
                    Console.WriteLine("port forwarded: " + f.IsStarted);
                }
            ssh.KeepAliveInterval = keepalive;

        }

        void ErrorCatch(object sender, Renci.SshNet.Common.ExceptionEventArgs e, out bool starting)
        {
            errors.Enqueue(e);
            starting = false;
        }
        public override string ToString()
        {
            return String.Format("Host: {0}, Server: {1}, {2}, Number of auths: {3}", host, Serverport, this.Cientport, auth.Keys.Count);
        }
        /// <summary>
        /// stops ssh and reverts the lan proxy settings (note this will halt untill the proxy and settings have reverted)
        /// </summary>
        public void StopAndWait()
        {
            Stop();
            while (!closed) { Thread.Sleep(20); }
        }


        void Proxy_SessionStarted(object source, ProxyInfo e)
        {
            Console.WriteLine("[Runtime]Started SSH...");
            _open = true;
        }

        void Proxy_SessionTerminated(object source, ProxyInfo e)
        {
            Console.WriteLine("[Runtime]Closed SSH...");
            closed = true;
        }

    }
    public delegate void Started(object source, ProxyInfo e);
    public delegate void Terminated(object source, ProxyInfo e);
    public class ProxyInfo : EventArgs
    {
        private string AcountInfo;
        public ProxyInfo(string Text)
        {
            AcountInfo = Text;
        }
        public string GetInfo()
        {
            return AcountInfo;
        }
    }
    //public class Proxytst
    //{
    //    public static SshClient ssh;
    //    public static bool con { get { return ssh.IsConnected; } }
    //    public static string test(string Pass)
    //    {
    //        ssh = new SshClient(new ConnectionInfo("rhys.rklyne.net", 4243, "rhys", new AuthenticationMethod[] { new PasswordAuthenticationMethod("rhys", Pass) }));
    //        ssh.HostKeyReceived += ssh_HostKeyReceived;
    //        ssh.Connect();

    //        ssh.AddForwardedPort(new ForwardedPortDynamic("localhost", 8080));
    //        foreach (var f in ssh.ForwardedPorts)
    //        {
    //            f.RequestReceived += f_RequestReceived;
    //            f.Start();
    //            Console.WriteLine(f.IsStarted);
    //        } var a = ssh.CreateCommand("ifconfig");
    //        ssh.KeepAliveInterval = new TimeSpan(0, 0, 20);
    //        Console.ReadLine();
    //        return a.Execute();
    //    }

    //    static void ssh_HostKeyReceived(object sender, Renci.SshNet.Common.HostKeyEventArgs e)
    //    {
    //        Console.WriteLine(String.Join(" ,", new object[] { e.CanTrust, e.FingerPrint, e.HostKey, e.HostKeyName, e.KeyLength, e.ToString() }));
    //    }

    //    static void f_RequestReceived(object sender, Renci.SshNet.Common.PortForwardEventArgs e)
    //    {
    //        Console.WriteLine(String.Join(" ", new object[] { e.OriginatorHost, e.OriginatorPort, e.ToString() }));
    //    }

    //}
}
