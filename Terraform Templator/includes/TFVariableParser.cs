using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terraform_Templator.models;

namespace Terraform_Templator.includes
{
    class TFVariableParser
    {
        static public List<TFVariableModel> GetAsModel(String projName)
        {
            string tfFilecontent = System.IO.File.ReadAllText(
                 Directory.GetCurrentDirectory() + "/projects/" + projName + "/variables.tf")
                .Replace("\r", "");
            List<TFVariableModel> returner = new List<TFVariableModel>();
            List<String> variableSplit = new List<String>();
            variableSplit.AddRange(
                tfFilecontent.Split(new string[] { "variable" }, StringSplitOptions.None));
            


            variableSplit.ForEach(delegate (String variable)
            {
                TFVariableModel _tmpModel = new TFVariableModel();              
                variable = variable.Replace("{","\n").Replace("}", "");
                

                //variable = variable.Replace("type", "\ntype");
                //variable = variable.Replace("default", "\ndefault");
                List<String> subSplitter = variable.Split('\n').ToList();
                subSplitter.ForEach(delegate (String lines)
                {
                    lines = lines.Trim();
                    List<String> equalSplitter = lines.Split('=').ToList();

                    if (equalSplitter.Count == 1 && equalSplitter[0].Trim() != "" )
                    {
                        
                        _tmpModel.Name = equalSplitter[0].Replace("\"","");
                    }
                    if (equalSplitter[0].ToLower().Contains("description") && equalSplitter.Count > 1)
                    {
                        _tmpModel.Desc = equalSplitter[1].Replace("\"", "").Replace("description", "")
                        .Replace("=", "").Trim();
                    }
                    if (equalSplitter[0].ToLower().Contains("type") && equalSplitter.Count > 1)
                    {
                        _tmpModel.VarType = equalSplitter[1].Replace("\"", "").Replace("type", "")
                        .Replace("=", "").Trim();
                    }
                    if (equalSplitter[0].ToLower().Contains("default") && equalSplitter.Count > 1)
                    {
                        _tmpModel.DefaultVal = equalSplitter[1].Replace("\"", "").Replace("default", "")
                        .Replace("=", "").Trim();
                    }

                });
                if (_tmpModel.Name != null && _tmpModel.Name != "") {
                    returner.Add(_tmpModel); }
            });
            return returner;
        }

        static public String SaveToProject(String projName, List<TFVariableModel> vars)
        {
            String saveString = "";
            vars.ForEach(delegate (TFVariableModel variable) {
                saveString += "variable \""+ variable.Name + "\" {\n" ;
                saveString += "description =\"" + variable.Desc + "\" \n";
                saveString += "type = " + variable.VarType + " \n";
                if (variable.VarType == "string")
                {
                    saveString += "default = \"" + variable.DefaultVal + "\" \n";
                }else
                {
                    saveString += "default =  " + variable.DefaultVal + "  \n";
                }
              
                
                saveString += "} \n";
            });

            System.IO.File.WriteAllText(
               Directory.GetCurrentDirectory() + "/projects/" + projName + "/variables.tf", saveString);

            return "ok";
        }


        }
}
