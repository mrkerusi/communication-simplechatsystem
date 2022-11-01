using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace Server
{
    public partial class ServerForm : Form
    {
        
        bool blnStartStop;
        ServiceHost host;
        ChatService cs = new ChatService();
        /*ChatServices is called from ChatLibrary*/

        public ServerForm()
        {
            InitializeComponent();
            blnStartStop = true;
        }
        /*lists the Connected User*/
        void cs_ChatListOfNames(List<string> names, object sender)
        {
            lstUser.Items.Clear();
            foreach (string s in names)
            {
                lstUser.Items.Add(s);
            }
        }
        /*Button Function to Start and Stop Services*/
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            
            if (blnStartStop)
            {
                host = new ServiceHost(typeof(Server.ChatService));
                host.Open();
                btnStartStop.Text = "Stop";
                ChatService.ChatListOfNames += new ListOfNames(cs_ChatListOfNames);
            }
            else
            {
                cs.Close();
                host.Close();
                btnStartStop.Text = "Start";
            }

            blnStartStop = !blnStartStop;
        }
        /*Button Function to Exit Services*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
