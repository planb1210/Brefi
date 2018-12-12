using Brefi.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Brefi.Data.Repositories
{
    public class ToolTypeRepository
    {
        private string filePath;
        private string tempFilePath;

        public ToolTypeRepository()
        {
            filePath = ConfigurationManager.AppSettings.Get("ToolTypePath");
            tempFilePath = ConfigurationManager.AppSettings.Get("TempToolTypePath");
        }

        public List<ToolType> GetLines(DateTime? date)
        {
            List<ToolType> res = new List<ToolType>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var toolType = AddPart(line);
                    if (date == null || toolType.UpdateTime > date)
                    {
                        res.Add(toolType);
                    }
                }
            }
            return res;
        }

        public void AddOrUpdate(ToolType toolType)
        {
            var isEdit = false;
            using (StreamWriter sw = new StreamWriter(tempFilePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var newToolType = AddPart(line);

                        if (newToolType.Id == toolType.Id)
                        {
                            var editLine = $"{toolType.Id},{toolType.Name},{toolType.OptionsDescription},{toolType.UpdateTime},{toolType.IsDeleted}";
                            sw.WriteLine(editLine);
                            isEdit = true;
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                    if(!isEdit)
                    {
                        var newLine = $"{toolType.Id},{toolType.Name},{toolType.OptionsDescription},{toolType.UpdateTime},{toolType.IsDeleted}";
                        sw.WriteLine(newLine);
                    }
                }
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public void AddOrUpdateRange(List<ToolType> toolTypes)
        {
            if (toolTypes != null)
            {
                foreach (var toolType in toolTypes)
                {
                    AddOrUpdate(toolType);
                }
            }
        }

        private ToolType AddPart(string line)
        {
            string[] parts = line.Split(',');

            return new ToolType { Id = Convert.ToInt32(parts[0]), Name = parts[1], OptionsDescription = parts[2] };
        }
    }
}
