using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class frmMain : Form
    {
        public List<Client> People { get; set; }
        public frmMain()
        {
            People = GetPeople();
            InitializeComponent();

        }

        private List<Client> GetPeople()
        {
            var list = new List<Client>();
            list.Add(new Client()
            {
                ReturnId = "21c caratworld v1",
                Clientname = "caratworld inc",
                Clientid = "caratworld",
                Preparer = "superglass-prashant",
                Officegroup = "PCLLP",
                Status = "pdf review",
                Lastactivity = "return Uploaded to EFS",
            });
            list.Add(new Client()
            {
                ReturnId = "21c chri v1",
                Clientname = "christi lifestyle llc",
                Clientid = "chri",
                Preparer = "superglass-prashant",
                Officegroup = "PCLLP",
                Status = "pdf done",
                Lastactivity = "return Uploaded to EFS",
            });
            list.Add(new Client()
            {
                ReturnId = "21c KalyanJewele v1",
                Clientname = "kalyanjewele inc",
                Clientid = "kalyanjewele",
                Preparer = "superglass-abhivridhi",
                Officegroup = "PCLLP",
                Status = "pdf done",
                Lastactivity = "Return Printed",
            });
            return list;
        }

        //btn_LogOut Click Event
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin fl = new frmLogin();
            fl.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var People = this.People;
            dataGridView1.DataSource = People;
        }
    }
}
