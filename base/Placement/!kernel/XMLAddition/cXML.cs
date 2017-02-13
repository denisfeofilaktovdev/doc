using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Placements.Properties;

namespace Placements._kernel
{
    public static class cXML
    {
        public static string rdName(string tmpXML)
        {
            StringBuilder tmpSTR = new StringBuilder();

            try
            {

                XmlTextReader xmlReader = new XmlTextReader(new StringReader(tmpXML));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {


                        if (xmlReader.Name == Resources.xmlLastName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(a);
                            }

                        }

                        if (xmlReader.Name == Resources.xmlFirstName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(" " + a);
                            }

                        }

                        if (xmlReader.Name == Resources.xmlParentName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(" " + a);
                            }

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex + "\n");

            }

            return tmpSTR.ToString();
        }

        public static string rdShortName(string tmpXML)
        {

            StringBuilder tmpSTR = new StringBuilder();

            try
            {

                XmlTextReader xmlReader = new XmlTextReader(new StringReader(tmpXML));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {


                        if (xmlReader.Name == Resources.xmlLastName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(a);
                            }

                        }

                        if (xmlReader.Name == Resources.xmlFirstName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(" " + a.ToUpper().Substring(0, 1) + ".");
                            }

                        }

                        if (xmlReader.Name == Resources.xmlParentName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                tmpSTR.Append(" " + a.ToUpper().Substring(0, 1) + ".");
                            }

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex + "\n");

            }

            return tmpSTR.ToString();


        }

        public static string rdAddress(string tmpXNL)
        {
            StringBuilder str = new StringBuilder();

           
            try
            {


                XmlTextReader xmlReader = new XmlTextReader(new StringReader(tmpXNL));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {

                        if (xmlReader.Name == Resources.xmlIndex)
                        {


                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(a + ", ");
                            }



                        }

                        if (xmlReader.Name == Resources.xmlRegion)
                        {

                            string a = xmlReader.ReadString();

                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(a);
                            }


                        }

                        if (xmlReader.Name == Resources.xmlDistrict)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlSettlementType)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", " + a);
                            }

                        }

                        if (xmlReader.Name == Resources.xmlSettlementName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(" " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlToponimType)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlToponimName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(" " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlBuilding)
                        {
                            string a = xmlReader.ReadString();

                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", д. " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlCorpus)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", корпус, " + a);
                            }
                        }

                        if (xmlReader.Name == Resources.xmlOfficeType)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", " + a);
                            }
                        }


                        if (xmlReader.Name == Resources.xmlOfficeName)
                        {
                            string a = xmlReader.ReadString();
                            if (!string.IsNullOrEmpty(a))
                            {
                                str.Append(", "+a + ".");
                            }
                        }




                    }
                }
            }
            catch (Exception e)
            {
                //Debug.WriteLine("\n" + e + "\n");

            }


            return str.ToString();
        }

    }
}
