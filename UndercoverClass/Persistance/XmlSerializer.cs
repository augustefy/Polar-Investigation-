using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UndercoverClass.Game;
using System.Xml.Serialization;
using System.Xml;

namespace UndercoverClass.Persistance
{
    public class XmlSerializer : ISerializer
    {
        public Parametres ReadParametres(string file)
        {
            var serializer = new DataContractSerializer(typeof(Parametres));
            Parametres r;
            file += ".xml";

            using (Stream s = File.OpenRead(file))
            {
                r = serializer.ReadObject(s) as Parametres;
            }

            return r;
        }

        public Partie ReadPartie()
        {
            var serializer = new DataContractSerializer(typeof(Partie), new DataContractSerializerSettings() { PreserveObjectReferences = true });
            Partie r= new Partie(new XmlSerializer());
            string file = "Partie.xml";

            if (File.Exists(file))
            {
                try
                {
                    using (Stream s = File.OpenRead(file))
                    {
                        r = serializer.ReadObject(s) as Partie;
                    }

                }
                
                catch (Exception e)
                {
                    File.Delete(file);
                }
                

                
            }

            return r;
        }



        public void Write(string file, Round r)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var serializer = new DataContractSerializer(typeof(Round));
            // string xmlFile = "parametresJoueurs2.xml";
            file += ".xml";

            if (File.Exists(file)) 
            {
                
                using (Stream tw = File.OpenWrite(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, r);
                    }
                }
            }
            else {
                using (TextWriter tw = File.CreateText(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, r);
                    }
                }
            }
        }

        public void Write(string file, Parametres p)
        {

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var serializer = new DataContractSerializer(typeof(Round));
            // string xmlFile = "parametresJoueurs2.xml";
            file += ".xml";

            if (File.Exists(file))
            {

                using (Stream tw = File.OpenWrite(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
            else
            {
                using (TextWriter tw = File.CreateText(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
        }

        public void Write(string file, Tour t)
        {

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var serializer = new DataContractSerializer(typeof(Round));
            // string xmlFile = "parametresJoueurs2.xml";
            file += ".xml";

            if (File.Exists(file))
            {

                using (Stream tw = File.OpenWrite(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, t);
                    }
                }
            }
            else
            {
                using (TextWriter tw = File.CreateText(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, t);
                    }
                }
            }
        }

        public void Write(string file, Partie p)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var serializer = new DataContractSerializer(typeof(Partie), new DataContractSerializerSettings() { PreserveObjectReferences = true });
            // string xmlFile = "parametresJoueurs2.xml";
            file += ".xml";

            if (File.Exists(file))
            {

                using (Stream tw = File.OpenWrite(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
            else
            {
                using (TextWriter tw = File.CreateText(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
        }

        public void WritePartie(Partie p)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            var serializer = new DataContractSerializer(typeof(Partie), new DataContractSerializerSettings() { PreserveObjectReferences = true });
            // string xmlFile = "parametresJoueurs2.xml";
            string file = "Partie.xml";

            if (File.Exists(file))
            {

                using (Stream tw = File.OpenWrite(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
            else
            {
                using (TextWriter tw = File.CreateText(file))
                {
                    using (XmlWriter writer = XmlWriter.Create(tw, settings))
                    {
                        serializer.WriteObject(writer, p);
                    }
                }
            }
        }
    }
}
