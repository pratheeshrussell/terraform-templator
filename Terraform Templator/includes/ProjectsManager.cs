using System;
using System.IO;
using System.Collections.Generic;

namespace Terraform_Templator.includes
{
    class ProjectsManager
    {
        public static void Initialize()
        {
            string subPath = Directory.GetCurrentDirectory() + "/projects";
            bool exists = Directory.Exists(subPath);
            if (!exists)
            {
                Directory.CreateDirectory(subPath);
            }
        }

        public static string CreateNewProject(String projectname,String templateName)
        {
            if (!IsValidProject(Directory.GetCurrentDirectory() + "/projects/" + projectname))
            {
                String targetDir = Directory.GetCurrentDirectory() + "/projects/" + projectname;
                String sourceDir = Directory.GetCurrentDirectory() + "/templates/" + templateName;
                Directory.CreateDirectory(targetDir);
                foreach (var file in Directory.GetFiles(sourceDir))
                {
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
                }

                return "done";
            }
            else
            {
                return "already exists";
            }
        }



        public static List<string> GetProjects()
        {
            List<string> allProjects = new List<string>();
            String[] allFolders = Directory.GetDirectories(Directory.GetCurrentDirectory() + "/projects");
            foreach (String folder in allFolders)
            {
                if (IsValidProject(folder))
                {
                    allProjects.Add(folder.Replace(Directory.GetCurrentDirectory() + "/projects\\", ""));
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
