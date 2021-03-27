using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Terraform_Templator.pages.newProject;
using Terraform_Templator.includes;
using Terraform_Templator.models;
using System.Diagnostics;
using System.IO;
using Terraform_Templator.pages.disclaimer;
using Terraform_Templator.pages.about;

namespace Terraform_Templator
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadProject()
        {
            if(projectListCombo.Text == "")
            {
                return;
            }
            int curRow = 0;
            List<TFVariableModel> variables = TFVariableParser.GetAsModel(projectListCombo.Text);
            variableTable.Controls.Clear();

            variables.ForEach(delegate (TFVariableModel variable) {
                Label _desc = new Label { Text = variable.Name, Anchor = AnchorStyles.Left,Dock=DockStyle.Fill };
                TextBox _defVal = new TextBox {Text = variable.DefaultVal,Name= variable.Name,
                    Anchor = AnchorStyles.Left,Dock = DockStyle.Fill };
                Button _infobutton = new Button { Text = "i" };
                _infobutton.Click += (s, e) => { showInfo(variable.Desc);  };
                variableTable.Controls.Add(_desc, 0, curRow);
                variableTable.Controls.Add(_defVal, 1, curRow);
                variableTable.Controls.Add(_infobutton, 2, curRow);

                curRow += 1;          
            });
            foreach (RowStyle RS in variableTable.RowStyles)
            {
                RS.SizeType = SizeType.Absolute;
                RS.Height = 030;
            }

            loadProjectState();


        }

        void loadProjectState()
        {
            //State
            String projFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text;
            bool initFolderExist = Directory.Exists(projFolder + "/.terraform");
            bool stateFileExist = File.Exists(projFolder + "/terraform.tfstate");
            if (initFolderExist)
            {
                initializeButton.Enabled = false;
                if (stateFileExist)
                {
                    applyButton.Enabled = false;
                    destroyButton.Enabled = true;
                    detailsButton.Enabled = true;
                } else
                {
                    applyButton.Enabled = true;
                    destroyButton.Enabled = false;
                    detailsButton.Enabled = false;
                }
            }
            else
            {
                initializeButton.Enabled = true;
            }
            //if destroyed but still has state file
            //try terraform state list command
            if (stateFileExist)
            {
                String listSt =  runCommandAndReturnOutput("cmd.exe", "/C cd " + projFolder + " && terraform state list");
                if (listSt == "")
                {
                    applyButton.Enabled = true;
                    destroyButton.Enabled = false;
                    detailsButton.Enabled = false;
                } else
                {
                    applyButton.Enabled = false;
                    destroyButton.Enabled = true;
                    detailsButton.Enabled = true;
                }
            }


            }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ProjectsManager.Initialize();
            TemplatesManager.Initialize();
            AddComboboxItems();
        }
        private void AddComboboxItems()
        {
            List<String> allProjects = ProjectsManager.GetProjects();
            projectListCombo.Items.Clear();
            projectListCombo.Text = ""; 
            foreach (String project in allProjects)
            {
                projectListCombo.Items.Add(project);
            }
        }

        private void newProjButton_Click(object sender, EventArgs e)
        {
            NewProjectForm createForm = new NewProjectForm();
            DialogResult dr = createForm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string projName = createForm.ProjectName;
                string tempName = createForm.TemplateName;
                //Create project
                if (projName.Length > 3)
                {
                    if (ProjectsManager.CreateNewProject(projName, tempName) == "done")
                    {
                        
                        projectListCombo.Text = projName;
                        LoadProject();
                        MessageBox.Show("Project Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Unable to Create Project", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                AddComboboxItems();
                Console.WriteLine("ok message");

            } else
            {
                Console.WriteLine("cancelled");
            }
        }

        private void showInfo(String msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void variableSaveButton_Click(object sender, EventArgs e)
        {
            List<TFVariableModel> variables = TFVariableParser.GetAsModel(projectListCombo.Text);
            int n = 0;
            variables.ForEach(delegate (TFVariableModel variable){
                Control[] _found = variableTable.Controls.Find(variable.Name, true);
               
                variables[n].DefaultVal = _found[0].Text;

                n += 1;
            });

           String res=  TFVariableParser.SaveToProject(projectListCombo.Text, variables);
            if (res == "ok")
            {
                MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Please edit manually", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void showFolder_Click(object sender, EventArgs e)
        {
            String path = Directory.GetCurrentDirectory() + "\\projects\\" + projectListCombo.Text;
            Process.Start("explorer.exe", path);
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            String projFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text;
            runCommandAndShowOutputAsync("cmd.exe", "/C cd " + projFolder + " && terraform init" );
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            String projFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text;
            runCommandAndShowOutputAsync("cmd.exe", "/C cd " + projFolder + " && terraform apply -auto-approve");
        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            String projFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text;
            runCommandAndShowOutputAsync("cmd.exe", "/C cd " + projFolder + " && terraform destroy -auto-approve");
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            String projFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text;
            runCommandAndShowOutputAsync("cmd.exe", "/C cd " + projFolder + " && terraform output");
        }

        private void runCommandAndShowOutputAsync(String cmd, String cmdparams)
        {
            cmdOutput.Text = "";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = cmd,
                    Arguments = cmdparams,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = System.Text.Encoding.UTF8,
                    CreateNoWindow = true,
                    
                }
            };
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                ThreadTextBoxHelperClass.SetText(this, cmdOutput, e.Data + "\r\n");
                //cmdOutput.Text += e.Data + "\r\n";
            
            });            
            process.Exited += new EventHandler(( sender, e) => {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    loadProjectState();
                }));
                
                MessageBox.Show("Command run successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            
            process.Start();
            process.BeginOutputReadLine();

        }

       String runCommandAndReturnOutput(String cmd, String cmdparams)
        {
            String returner = "";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = cmd,
                    Arguments = cmdparams,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = System.Text.Encoding.UTF8,
                    CreateNoWindow = true,

                }
            };
            process.Start();
            returner = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return returner;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisclaimerForm disclaimForm = new DisclaimerForm();
            disclaimForm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}


public static class ThreadTextBoxHelperClass
{
    delegate void SetTextCallback(Form f, TextBox ctrl, string text);
    /// <summary>
    /// Set text property of various controls
    /// </summary>
    /// <param name="form">The calling form</param>
    /// <param name="ctrl"></param>
    /// <param name="text"></param>
    public static void SetText(Form form, TextBox ctrl, string text)
    {
        // InvokeRequired required compares the thread ID of the 
        // calling thread to the thread ID of the creating thread. 
        // If these threads are different, it returns true. 
        if (ctrl.InvokeRequired)
        {
            SetTextCallback d = new SetTextCallback(SetText);
            form.Invoke(d, new object[] { form, ctrl, text });
        }
        else
        {
           ctrl.AppendText(text);
            //ctrl.Text += text;
        }
    }
}