using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Placements.main;
using Placements.Properties;
using Placements._kernel;

namespace Placements.src
{
    public partial class frmEditPlaceman : Form
    {
        public frmEditPlaceman()
        {
            InitializeComponent();

            btnName.Select();
            
            btnName.Focus();
        }

        private frmEditFIO fEditFIO=new frmEditFIO();


        private void btnName_Click(object sender, EventArgs e)
        {
            
            fEditFIO=new frmEditFIO();
            
            fEditFIO.Text = "Ввод имени в Именительном Падеже";

            fEditFIO.grbName.Text = "Полное ФИО в Именительном падеже";

            
            try
            {


                XmlTextReader xmlReader = new XmlTextReader(new StringReader(xmlName.Text));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        if (xmlReader.Name == Resources.xmlLastName)
                        {
                            fEditFIO.txtLastName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlFirstName)
                        {
                            fEditFIO.txtFirstName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlParentName)
                        {
                            fEditFIO.txtParentName.Text = xmlReader.ReadString();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex + "\n");

            }


            if (fEditFIO.ShowDialog() == DialogResult.OK)
            {

                StringWriter writer = new StringWriter();

                XmlTextWriter xmlWriter = new XmlTextWriter(writer);


                string LastName=null;
                string FirstName=null;
                string ParenetName=null;

                if (!string.IsNullOrEmpty(fEditFIO.txtLastName.Text))
                {

                    LastName = fEditFIO.txtLastName.Text.First().ToString().ToUpper() +
                               fEditFIO.txtLastName.Text.Substring(1);

                }

                if (!string.IsNullOrEmpty(fEditFIO.txtFirstName.Text))
                {

                    FirstName = fEditFIO.txtFirstName.Text.First().ToString().ToUpper() +
                                fEditFIO.txtFirstName.Text.Substring(1);

                }

                 if (!string.IsNullOrEmpty(fEditFIO.txtParentName.Text))
                 {

                     ParenetName = fEditFIO.txtParentName.Text.First().ToString().ToUpper() +
                                   fEditFIO.txtParentName.Text.Substring(1);

                 }


                xmlWriter.WriteStartDocument();

                    xmlWriter.WriteStartElement(Resources.xmlFullName);

                    xmlWriter.WriteElementString(Resources.xmlLastName, LastName);

                    xmlWriter.WriteElementString(Resources.xmlFirstName,FirstName );

                    xmlWriter.WriteElementString(Resources.xmlParentName, ParenetName );

                    xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlName.Text = writer.ToString();

                txtName.Text = cXML.rdName(xmlName.Text);

                txtShortName.Text = cXML.rdShortName(xmlName.Text);



            }
            
            
            
        }

        private void btnGenetiveName_Click(object sender, EventArgs e)
        {

            fEditFIO = new frmEditFIO();

            fEditFIO.Text = "Ввод имени в Родительном Падеже";

            fEditFIO.grbName.Text = "Полное ФИО в Родительном падеже";


            try
            {


                XmlTextReader xmlReader = new XmlTextReader(new StringReader(xmlNameDative.Text));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        if (xmlReader.Name == Resources.xmlLastName)
                        {
                            fEditFIO.txtLastName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlFirstName)
                        {
                            fEditFIO.txtFirstName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlParentName)
                        {
                            fEditFIO.txtParentName.Text = xmlReader.ReadString();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex + "\n");

            }


            if (fEditFIO.ShowDialog() == DialogResult.OK)
            {

                StringWriter writer = new StringWriter();

                XmlTextWriter xmlWriter = new XmlTextWriter(writer);


                string LastName = null;
                string FirstName = null;
                string ParenetName = null;

                if (!string.IsNullOrEmpty(fEditFIO.txtLastName.Text))
                {

                    LastName = fEditFIO.txtLastName.Text.First().ToString().ToUpper() +
                               fEditFIO.txtLastName.Text.Substring(1);

                }

                if (!string.IsNullOrEmpty(fEditFIO.txtFirstName.Text))
                {

                    FirstName = fEditFIO.txtFirstName.Text.First().ToString().ToUpper() +
                                fEditFIO.txtFirstName.Text.Substring(1);

                }

                if (!string.IsNullOrEmpty(fEditFIO.txtParentName.Text))
                {

                    ParenetName = fEditFIO.txtParentName.Text.First().ToString().ToUpper() +
                                  fEditFIO.txtParentName.Text.Substring(1);

                }


                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement(Resources.xmlFullName);

                xmlWriter.WriteElementString(Resources.xmlLastName, LastName);

                xmlWriter.WriteElementString(Resources.xmlFirstName, FirstName);

                xmlWriter.WriteElementString(Resources.xmlParentName, ParenetName);

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlNameGenitive.Text = writer.ToString();

                txtNameGenitive.Text = cXML.rdName(xmlNameGenitive.Text);
                
            }
        }

        private void btnDativeName_Click(object sender, EventArgs e)
        {

            fEditFIO = new frmEditFIO();

            fEditFIO.Text = "Ввод имени в Дательном Падеже";
            
            fEditFIO.grbName.Text = "Полное ФИО в Дательном падеже";

            try
            {


                XmlTextReader xmlReader = new XmlTextReader(new StringReader(xmlNameDative.Text));

                xmlReader.WhitespaceHandling = WhitespaceHandling.None; // пропускаем пустые узлы

                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        if (xmlReader.Name == Resources.xmlLastName)
                        {
                            fEditFIO.txtLastName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlFirstName)
                        {
                            fEditFIO.txtFirstName.Text = xmlReader.ReadString();
                        }

                        if (xmlReader.Name == Resources.xmlParentName)
                        {
                            fEditFIO.txtParentName.Text = xmlReader.ReadString();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n" + ex + "\n");

            }


            if (fEditFIO.ShowDialog() == DialogResult.OK)
            {

                StringWriter writer = new StringWriter();

                XmlTextWriter xmlWriter = new XmlTextWriter(writer);


                string LastName = null;
                string FirstName = null;
                string ParenetName = null;

                if (!string.IsNullOrEmpty(fEditFIO.txtLastName.Text))
                {

                    LastName = fEditFIO.txtLastName.Text.First().ToString().ToUpper() +
                               fEditFIO.txtLastName.Text.Substring(1);

                }

                if (!string.IsNullOrEmpty(fEditFIO.txtFirstName.Text))
                {

                    FirstName = fEditFIO.txtFirstName.Text.First().ToString().ToUpper() +
                                fEditFIO.txtFirstName.Text.Substring(1);

                }

                if (!string.IsNullOrEmpty(fEditFIO.txtParentName.Text))
                {

                    ParenetName = fEditFIO.txtParentName.Text.First().ToString().ToUpper() +
                                  fEditFIO.txtParentName.Text.Substring(1);

                }


                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement(Resources.xmlFullName);

                xmlWriter.WriteElementString(Resources.xmlLastName, LastName);

                xmlWriter.WriteElementString(Resources.xmlFirstName, FirstName);

                xmlWriter.WriteElementString(Resources.xmlParentName, ParenetName);

                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();

                xmlNameDative.Text = writer.ToString();

                txtNameDative.Text = cXML.rdName(xmlNameDative.Text);

                


            }
        }



    }
}
