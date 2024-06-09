using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UndercoverClass.Game;

namespace UndercoverClass.Persistance
{
    public class JsonSerializer : ISerializer
    {
        

        public Partie ReadPartie()
        {
            Partie p =new Partie(new JsonSerializer());
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Partie));
            string file = "Partie.json";
           
            if (File.Exists(file))
            {
                try
                {
                    using (Stream s = File.OpenRead(file))
                    {
                        p = jsonSerializer.ReadObject(s) as Partie;
                    }

                }
                
                catch(Exception e) 
                {
                    File.Delete(file);
                }
             
            }
            return p;
        }

        public Round ReadRound()
        {
            throw new NotImplementedException();
        }

        public Round ReadRound(string file)
        {
            throw new NotImplementedException();
        }

        public Tour ReadTour(string file)
        {
            throw new NotImplementedException();
        }

        public void Write(Partie p)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Parametres));
            MemoryStream memoryStream = new MemoryStream();
            jsonSerializer.WriteObject(memoryStream, p.Parametres);
            using (FileStream stream = File.Create("Partie.json"))
            {
                memoryStream.WriteTo(stream);
            }

            
           
        }


        public void WritePartie(Partie p)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Partie));
            //MemoryStream memoryStream = new MemoryStream();
            //jsonSerializer.WriteObject(memoryStream, p);
            string file = "Partie.json";


            if (File.Exists(file))
            {
                using (FileStream stream = File.OpenWrite(file))
                {
                    using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream,
                            System.Text.Encoding.UTF8,
                            false,
                            true))
                    {
                        jsonSerializer.WriteObject(writer, p);
                    }
                }

            }

            else
            {
                using (FileStream stream = File.Create(file))
                {
                    using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream,
                            System.Text.Encoding.UTF8,
                            false,
                            true))
                    {
                        jsonSerializer.WriteObject(writer, p);
                    }
                }
            }
        }
    }
}
