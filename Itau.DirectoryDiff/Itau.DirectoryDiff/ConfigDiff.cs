using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Itau.TreeFileViewer;

namespace Itau.DirectoryDiff
{
    public class ConfigDiff: ConfigSystem
    {

        public string LastDirA { get; set; }
        public string LastDirB { get; set; }
        public string CompareTool { get; set; }
        public string NotContent { get; set; }

        public override string ConfigFile()
        {
            return "configDiff";
        }

        protected override void NodeReader(XmlNode node)
        {
            base.NodeReader(node);
            if (node.Name == "LastDirA")
            {
                this.LastDirA = node.InnerText;
            }
            else if (node.Name == "LastDirB")
            {
                this.LastDirB = node.InnerText;
            }
            else if (node.Name == "CompareTool")
            {
                this.CompareTool = node.InnerText;
            }
            else if (node.Name == "NotContent")
            {
                this.NotContent = node.InnerText;
            }


        }

        protected override void NodeSaver(XmlNode node)
        {
            base.NodeSaver(node);
            if (node.Name == "CompareTool")
            {
                node.InnerText = this.CompareTool;
            }
            else if (node.Name == "NotContent")
            {
                node.InnerText = this.NotContent;
            }
        }

        public void SaveLastDiff()
        {

            String MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            if (!System.IO.File.Exists(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml"))
            {
                System.IO.File.Copy(this.ConfigFile(), MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml", true);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml");

            XmlNodeList nodes = doc.SelectNodes("Settings")[0].ChildNodes;

            foreach (XmlNode node in nodes)
            {
                if (node.Name == "LastDirA")
                {
                    node.InnerText = this.LastDirA;
                }
                else if (node.Name == "LastDirB")
                {
                    node.InnerText = this.LastDirB;
                }
            }

            doc.Save(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml");
        }

    }
}
