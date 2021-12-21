using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Data;

namespace RustabBot_v1._0
{
    public class XMLManager
    {
        public List<string> ScnFiles { get; set; }

        public string RstFileName { get; set; }
        public string SchFileName { get; set; }
        public string DfwFileName { get; set; }
        public string Ut2FileName { get; set; }

        public XMLManager(string rstFileName, string schFileName, string dfwFileName, string ut2FileName, List<string> scnFiles)
        {
            RstFileName = rstFileName;
            SchFileName = schFileName;
            DfwFileName = dfwFileName;
            Ut2FileName = ut2FileName;
            ScnFiles = scnFiles;
        }

        public static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RustabBotFileNames.xml"; // This is the path of MyDocuments folder of your pc

        public static void SaveXMLFile(string rstFileName, string schFileName, string dfwFileName, string ut2FileName, List<string> scnFileNames)
        {
            XDocument xdoc = new XDocument();

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            // создаем корневой элемент
            XElement files = new XElement("files");


            files.Add(new XElement("file",
                                  new XAttribute("name", "Файл динамики"),
                                  new XElement("FilePath", rstFileName)
                                 ));
            files.Add(new XElement("file",
                                  new XAttribute("name", "Файл сечений"),
                                  new XElement("FilePath", schFileName)
                                 ));
            files.Add(new XElement("file",
                                  new XAttribute("name", "Файл автоматики"),
                                  new XElement("FilePath", dfwFileName)
                                 ));
            files.Add(new XElement("file",
                                  new XAttribute("name", "Файл траектории"),
                                  new XElement("FilePath", ut2FileName)
                                 ));
            foreach (string scn in scnFileNames)
            {
                files.Add(new XElement("file",
                                      new XAttribute("name", "Файл сценария"),
                                      new XElement("FilePath", scn)
                                     ));

            }
            xdoc.Add(files);
            xdoc.Save(filePath);
        }

        public void LoadFromXMLFile()
        {
            ScnFiles.Clear();
            XDocument xdoc = XDocument.Load(filePath);

            foreach (XElement fileElement in xdoc.Element("files").Elements("file"))
            {
                switch (fileElement.Attribute("name").Value)
                {
                    case ("Файл динамики"):
                        {
                            RstFileName = fileElement.Element("FilePath").Value;
                            break;
                        }
                    case ("Файл сечений"):
                        {
                            SchFileName = fileElement.Element("FilePath").Value;
                            break;
                        }
                    case ("Файл автоматики"):
                        {
                            DfwFileName = fileElement.Element("FilePath").Value;
                            break;
                        }
                    case ("Файл траектории"):
                        {
                            Ut2FileName = fileElement.Element("FilePath").Value;
                            break;
                        }
                    case ("Файл сценария"):
                        {
                            ScnFiles.Add(fileElement.Element("FilePath").Value);
                            break;
                        }
                }
            }
        }

        public static bool IsFileExists()
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
