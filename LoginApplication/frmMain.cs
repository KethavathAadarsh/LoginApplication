using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Net;
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
                HyperLink = "https://www.irs.gov/pub/irs-pdf/fw9.pdf",
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
                HyperLink = "https://www.irs.gov/pub/irs-pdf/fw9.pdf",

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
                HyperLink = "https://www.irs.gov/pub/irs-pdf/fw9.pdf",

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
            dataGridView1.Columns["HyperLink"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold | FontStyle.Underline);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
           
        }
        private void GO_Click(object sender, EventArgs e)
        {
            
                string filter = FilterbyclientId.Text.Trim();

                if (string.IsNullOrEmpty(filter))
                {
                    // If the filter is empty or null, show all rows
                    dataGridView1.DataSource = People;
                    dataGridView1.Columns["HyperLink"].Visible = false;
                }
                else
                {
                    // Filter the rows based on the Clientid column
                    var filteredData = People.Where(p => p.Clientid.Contains(filter)).ToList();
                    dataGridView1.DataSource = filteredData;
                }
            }
       
        private void Printpdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row and its data source
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                Client client = row.DataBoundItem as Client;


                if (client != null)
                {
                    // Show a dialog box to get the file path
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Construct the URL using the client ID
                        string url = client.HyperLink;

                        // Show a message box with the URL and file path
                        string message = "\nFile Path: " + saveFileDialog.FileName;
                        DialogResult result = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                               
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                                using (WebClient webClient = new WebClient())
                                {
                                    //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                                    //webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                                    webClient.DownloadFileAsync(new Uri(url), @saveFileDialog.FileName);
                                }
                                //webClient.DownloadFile(url,filename);
                                //}
                                Console.WriteLine(url);
                                MessageBox.Show("PDF file downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (System.Net.WebException ex)
                            {
                                MessageBox.Show("PDF file download failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Console.WriteLine(ex.StackTrace); // Print the stack trace to help diagnose the issue
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occurred while downloading the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Console.WriteLine(ex.StackTrace); // Print the stack trace to help diagnose the issue
                            }
                        }

                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedclient = dataGridView1.SelectedRows[0].DataBoundItem as Client;
                textBox1ClientId.Text = selectedclient.Clientid.ToString();
                textBox2ClientName.Text = selectedclient.Clientname.ToString();
                textBox3Status.Text = selectedclient.Status.ToString();

            }
            catch
            {
                MessageBox.Show("something is wrong");
            }
        }
    }
    }
    

