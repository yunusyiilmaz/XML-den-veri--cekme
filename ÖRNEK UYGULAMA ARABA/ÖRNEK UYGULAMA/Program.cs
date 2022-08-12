using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ÖRNEK_UYGULAMA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<araba> arabam = new List<araba>();
            arabam.Add(new araba
            {
                marka = "renault",
                model="symbol",
                renk ="gri"
            }) ;
            arabam.Add(new araba
            {
                marka="hyndai",
                model="Getz",
                renk="mavi"
            });
            XmlDocument doc=new XmlDocument();
            XmlNode rootname = doc.CreateElement("arabalar");
            doc.AppendChild(rootname);
            foreach(var item in arabam)
            {
                XmlNode araba=doc.CreateElement("araba");
                XmlNode marka = doc.CreateElement("marka");
                XmlNode model = doc.CreateElement("model");
                XmlNode renk = doc.CreateElement("renk");
                marka.InnerText=item.marka;
                model.InnerText=item.model;
                renk.InnerText = item.renk;
                araba.AppendChild(marka);
                araba.AppendChild(model);
                araba.AppendChild(renk);
                rootname.AppendChild(araba);
            }
            doc.Save("arabalistesi.xml");
            List<araba> arabalarım = new List<araba>();
            XmlDocument doc1 = new XmlDocument();
            StreamReader sr = new StreamReader("arabalistesi.xml");
            string okunan=sr.ReadToEnd();
            doc1.LoadXml(okunan);
            XmlNodeList node = doc1.GetElementsByTagName("araba");
            foreach(XmlNode item in node)
            {
                araba a = new araba();
                a.marka = item["marka"].InnerText;
                a.model= item["model"].InnerText;
                a.renk = item["renk"].InnerText;
                arabalarım.Add(a);
            }
            foreach(var item in arabalarım)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            
        }
    }
    class araba
    {
        public string marka { get; set; }
        public string model { get; set; }
        public string renk { get; set; }

        public override string ToString()
        {
            return "MARKA :" + marka + " " + "MODEL :" + model + " " + "RENK :" + renk;
        }
    }
}
