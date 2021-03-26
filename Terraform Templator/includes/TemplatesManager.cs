using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraform_Templator.includes
{
    class TemplatesManager
    {
        public static String templateFolder = "/templates";
        public static void Initialize()
        {
            string subPath = Directory.GetCurrentDirectory() + templateFolder;
            bool exists = Directory.Exists(subPath);
            if (!exists)
            {
                Directory.CreateDirectory(subPath);
            }
        }

        public static List<string> GetTemplates()
        {
            List<string> allProjects = new List<string>();
            String[] allFolders = Directory.GetDirectories(Directory.GetCurrentDirectory() + templateFolder);
            foreach (String folder in allFolders)
            {
                if (IsValidProject(folder))
                {
                    allProjects.Add(folder.Replace(Directory.GetCurrentDirectory() + templateFolder + "\\", ""));
                }
            }
            return allProjects;
        }

        public static bool IsValidProject(String path)
        {
            if (!File.Exists(path + "/main.tf"))
            {
                return false;
            }
            return true;
        }

    }
}
