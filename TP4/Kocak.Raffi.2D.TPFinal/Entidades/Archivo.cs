using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Entidades
{
    public static class Archivo <T>
    {
        private static string rutaBase;

        static Archivo()
        {
            rutaBase = AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Escribe texto plano en un archivo txt
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="datoAGuardar"></param>
        /// <exception cref="ArchivoException"></exception>
        public static void EscribirTxt(string nombreArchivo, string datoAGuardar)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".txt";
            try
            {
                using(StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    sw.WriteLine(datoAGuardar);
                }
            }catch(Exception ex)
            {
                throw new ArchivoException($"Error al escribir archivo en {rutaCompleta}", ex);
            }
        }

        /// <summary>
        /// Lee texto plano de un archivo txt
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoException"></exception>
        public static string LeerTxt(string nombreArchivo)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".txt";
            string dato = String.Empty;
            try
            {
                using(StreamReader sr = new StreamReader(rutaCompleta))
                {
                    dato = sr.ReadToEnd();
                }

                return dato;
            }catch(Exception ex)
            {
                throw new ArchivoException($"Error al leer archivo en {rutaCompleta}", ex);
            }
        }

        /// <summary>
        /// Escribe datos genericos a un archivo json
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="datoAGuardar"></param>
        /// <exception cref="ArchivoException"></exception>
        public static void EscribirJson(string nombreArchivo, T datoAGuardar)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".json";
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string datoSerializado = JsonSerializer.Serialize(datoAGuardar, options);
                File.WriteAllText(rutaCompleta, datoSerializado);
            }
            catch (Exception ex)
            {
                throw new ArchivoException($"Error al escribir el archivo {rutaCompleta}", ex);
            }
        }

        /// <summary>
        /// Lee datos genericos de un archivo json
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoException"></exception>
        public static T LeerJson(string nombreArchivo)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".json";
            T dato = default;
            try
            {
                string archivo = File.ReadAllText(rutaCompleta);
                dato = JsonSerializer.Deserialize<T>(archivo);

                return dato;
            } catch (Exception ex)
            {
                throw new ArchivoException($"Error al leer el archivo {rutaCompleta}",ex);
            }
        }

        /// <summary>
        /// Escribe datos genericos de un archivo xml
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="datoAGuardar"></param>
        /// <exception cref="ArchivoException"></exception>
        public static void EscribirXml(string nombreArchivo, T datoAGuardar)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".xml";
            try
            {
                using (XmlTextWriter tw = new XmlTextWriter(rutaCompleta, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    tw.Formatting = Formatting.Indented;
                    serializador.Serialize(tw, datoAGuardar);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException($"Error al escribir el archivo {rutaCompleta}", ex);
            }
        }

        /// <summary>
        /// Lee datos genericos de un archivo xml
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoException"></exception>
        public static T LeerXml(string nombreArchivo)
        {
            string rutaCompleta = rutaBase + nombreArchivo + ".xml";
            T dato = default;
            try
            {
                using (XmlTextReader sr = new XmlTextReader(rutaCompleta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    dato = (T)serializer.Deserialize(sr);
                }
  
                return dato;
            }
            catch (Exception ex)
            {
                throw new ArchivoException($"Error al leer el archivo {rutaCompleta}", ex);
            }
        }
    }
}
