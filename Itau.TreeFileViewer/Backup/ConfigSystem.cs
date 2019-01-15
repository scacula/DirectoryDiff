using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Itau.TreeFileViewer
{
    public class ConfigSystem
    {
        public List<string> IgnoreExtensions { get; set; }
        public List<string> IgnorePaths { get; set; }
        public List<string> NodeTypes { get; set; }

        public virtual string ConfigFile()
        {
            return "ConfigSystem";
        }


        public void Load()
        {
            this.Load(true);
        }
        public void Load(bool defaultLoad)
        {
            this.IgnoreExtensions = new List<string>();
            this.IgnorePaths = new List<string>();
            this.NodeTypes = new List<string>();

            String MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            if (!System.IO.File.Exists(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml"))
            {

                try
                {
                    System.IO.File.Copy(this.ConfigFile(), MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml", true);
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                
            }


            XmlDocument doc = new XmlDocument();
            doc.Load(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml");

            XmlNodeList nodes = doc.SelectNodes("Settings")[0].ChildNodes;

            foreach (XmlNode node in nodes)
            {

                if (defaultLoad)
                {
                    if (!string.IsNullOrEmpty(node.InnerText))
                    {
                        if (node.Name == "IgnoreExtensions")
                        {
                            this.IgnoreExtensions = node.InnerText.Split(',').ToList();
                        }
                        else if (node.Name == "IgnorePaths")
                        {
                            this.IgnorePaths = node.InnerText.Split(',').ToList();
                        }
                        else if (node.Name == "NodeTypes")
                        {
                            this.NodeTypes = node.InnerText.Split(',').ToList();
                        }
                        else
                        {
                            this.NodeReader(node);
                        }
                    }
                }

            }
        }

        protected virtual void NodeReader(XmlNode node)
        {
            //if (node.Name == "NodeTypes")
            //{
            //    this.NodeTypes = node.InnerText.Split(',').ToList();
            //}
        }

        protected virtual void NodeSaver(XmlNode node)
        {
            //if (node.Name == "NodeTypes")
            //{
            //    this.NodeTypes = node.InnerText.Split(',').ToList();
            //}
        }


        public void Save()
        {
            this.Save(true);
        }
        public void Save(bool defaultSave)
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
                if (defaultSave)
                {
                    if (node.Name == "IgnoreExtensions")
                    {
                        node.InnerText = Util.ListToString(this.IgnoreExtensions);
                    }
                    else if (node.Name == "IgnorePaths")
                    {
                        node.InnerText = Util.ListToString(this.IgnorePaths);
                    }
                    else if (node.Name == "NodeTypes")
                    {
                        node.InnerText = Util.ListToString(this.NodeTypes);
                    }
                    else
                    {
                        this.NodeSaver(node);
                    }
                }
            }

            doc.Save(MyDocumentsFolder + "\\" + this.ConfigFile() + ".xml");
        }

    }
}
