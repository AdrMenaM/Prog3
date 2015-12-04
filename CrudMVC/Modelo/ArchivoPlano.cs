using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;

namespace Modelo
{
    public class ArchivoPlano
    {
        private List<Persona> mListaPersonas;
        private XmlSerializer mSerializador;
        private XmlSerializer mDeserializador;
        
        private String mPath;

        public ArchivoPlano()
        {
            
        }

        //public ArchivoPlano(String path)
        //{
        //    mPath = System.Environment.CurrentDirectory;
        //    mPath += path;
        //}

        public ArchivoPlano(String path)
        {
            
            mPath = path;
        }

        public void Serializar(List<Persona> obj)
        {
            mSerializador = new XmlSerializer(typeof(List<Persona>));
            TextWriter textWriter = new StreamWriter(mPath);
            mSerializador.Serialize(textWriter, obj);
            textWriter.Close();
        }

        public List<Persona> Deserializar()
        {
            if (File.Exists(mPath))
            {
                mDeserializador = new XmlSerializer(typeof(List<Persona>));
                mListaPersonas = new List<Persona>();
                TextReader textReader = new StreamReader(mPath);
                mListaPersonas = (List<Persona>)mDeserializador.Deserialize(textReader);
                textReader.Close();
            }

            return mListaPersonas;
        }
    }
}
