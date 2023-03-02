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
                Preparer = "superglass",
                Officegroup = "PCLLP",
                Status = "updated",
                Lastactivated = "26th jan",
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
