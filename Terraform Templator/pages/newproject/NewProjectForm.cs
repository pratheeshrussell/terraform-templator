using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Terraform_Templator.includes;

namespace Terraform_Templator.pages.newProject
{
    public partial class NewProjectForm : Form
    {
        public string ProjectName { get; set; }
        public string TemplateName { get; set; }
        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void newProject_Load(object sender, EventArgs e)
        {
            AddComboboxItems();
        }

        private void AddComboboxItems()
        {
            List<String> allTemplates = TemplatesManager.GetTemplates();
            templateCombo.Items.Clear();
            templateCombo.Text = "";
            foreach (String template in allTemplates)
            {
                templateCombo.Items.Add(template);
            }
            templateCombo.Text = allTemplates[0];
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.ProjectName = textBox1.Text;
            this.TemplateName = templateCombo.Text;
            
            if (this.ProjectName != "" && this.TemplateName != "") {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

      
    }
}
