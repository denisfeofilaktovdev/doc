using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Placements.main;
using Placements.Properties;
using Placements._kernel;

namespace Placements.src
{
    public partial class frmEditDepartment : Form
    {
        public frmEditDepartment()
        {
            InitializeComponent();
            
            txtShortName.Select();
            txtShortName.Focus();
        }

        private void EditAdress_Click(object sender, EventArgs ex)
        {

            frmAdressDepartament fAdressDepartament = new frmAdressDepartament();

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(new StringReader(xmlAdress.Text));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        if (xmlReader.Name == Resources.xmlIndex)
                        {
                            fAdressDepartament.PostIndex.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlRegion)
                        {
                            fAdressDepartament.Region.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlDistrict)
                        {
                            fAdressDepartament.District.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlSettlementType)
                        {
                            fAdressDepartament.SettlementType.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlSettlementName)
                        {
                            fAdressDepartament.SettlementName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlToponimType)
                        {
                            fAdressDepartament.ToponimType.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlToponimName)
                        {
                            fAdressDepartament.ToponimName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlBuilding)
                        {
                            fAdressDepartament.Building.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlCorpus)
                        {
                            fAdressDepartament.Corpus.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlOfficeType)
                        {
                            fAdressDepartament.OfficeType.Text = xmlReader.ReadString();
                        }


                        if (xmlReader.Name == Resources.xmlOfficeName)
                        {
                            fAdressDepartament.OfficeName.Text = xmlReader.ReadString();
                        }




                    }
                }
            }
            catch (Exception e)
            {

                Debug.WriteLine("\n" + e + "\n");
            }




            if (fAdressDepartament.ShowDialog() == DialogResult.OK)
            {

                StringWriter writer = new StringWriter();

                XmlTextWriter xmlWriter = new XmlTextWriter(writer);

                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement(Resources.xmlAddress);

                xmlWriter.WriteElementString(Resources.xmlIndex, fAdressDepartament.PostIndex.Text);
                xmlWriter.WriteElementString(Resources.xmlRegion, fAdressDepartament.Region.Text);
                xmlWriter.WriteElementString(Resources.xmlDistrict, fAdressDepartament.District.Text);
                xmlWriter.WriteElementString(Resources.xmlSettlementType, fAdressDepartament.SettlementType.Text);
                xmlWriter.WriteElementString(Resources.xmlSettlementName, fAdressDepartament.SettlementName.Text);
                xmlWriter.WriteElementString(Resources.xmlToponimType, fAdressDepartament.ToponimType.Text);
                xmlWriter.WriteElementString(Resources.xmlToponimName, fAdressDepartament.ToponimName.Text);
                xmlWriter.WriteElementString(Resources.xmlBuilding, fAdressDepartament.Building.Text);
                xmlWriter.WriteElementString(Resources.xmlCorpus, fAdressDepartament.Corpus.Text);
                xmlWriter.WriteElementString(Resources.xmlOfficeType, fAdressDepartament.OfficeType.Text);
                xmlWriter.WriteElementString(Resources.xmlOfficeName, fAdressDepartament.OfficeName.Text);



                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlAdress.Text= writer.ToString();

                adressData.Text = cXML.rdAddress(xmlAdress.Text);


            }

            
            
        }

        
    }
}
