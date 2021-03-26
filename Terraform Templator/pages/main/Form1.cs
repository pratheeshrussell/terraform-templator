using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Terraform_Templator.pages.newProject;
using Terraform_Templator.includes;
using Terraform_Templator.models;
using System.Linq;
using System.Diagnostics;
using System.IO;

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

            //State
           String initFolder = Directory.GetCurrentDirectory() + "/projects/" + projectListCombo.Text + "/.terraform";
           if (Directory.Exists(initFolder)) {
                initializeButton.Enabled = false;
            } else
            {
                initializeButton.Enabled = true;
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
            initializeButton.Enabled = false;
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
                    //CreateNoWindow = true
                }
            };

            process.Start();
           
            process.WaitForExit();
           // var line = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(line);
           // cmdOutput.Text += line +"\r\n";

            while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                //Console.WriteLine(line);
                cmdOutput.Text += line + "\r\n";
            }



        }
    }
}
