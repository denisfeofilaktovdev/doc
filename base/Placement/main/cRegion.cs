using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Placements.db;
using Placements.Kernel;
using Placements.Properties;
using Placements.src;
using Placements._kernel;


namespace Placements.main
{
    public class cRegion
    {

        protected static tRegion pRegion { get; set; }

        private static frmEditRegion fEditRegion = new frmEditRegion();
        
        private static frmEditPlaceman fEditPlaceman = new frmEditPlaceman();

        private static frmEditDepartment fEditDepartment = new frmEditDepartment();
        
        public static void Edit(int indexRegion)
        {


            pRegion = tRegion.byID(indexRegion);

            fEditRegion.Text = pRegion.Region;


            if (pRegion.icon_ != null)
            {
                using (MemoryStream ms = new MemoryStream(pRegion.icon_))
                {

                    fEditRegion.pictureRegion.Image = Image.FromStream(ms);

                }
            }
            else
            {
                fEditRegion.pictureRegion.Image = null;
            }




            fEditRegion.txtNameRegion.Text = pRegion.Region;
            fEditRegion.txtGenitiveRegion.Text = pRegion.GenitiveRegion;
            fEditRegion.txtDativeRegion.Text = pRegion.DativeRegion;



            //сохранение изменных данных
            if (fEditRegion.ShowDialog() == DialogResult.OK)
            {


                if (fEditRegion.pictureRegion.Image == null)
                {

                    MemoryStream ms =
                        new MemoryStream((byte[]) new ImageConverter().ConvertTo(Resources.Ukraine, typeof (byte[])));
                    pRegion.icon_ = ms.ToArray();

                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    fEditRegion.pictureRegion.Image.Save(ms, ImageFormat.Png);
                    pRegion.icon_ = ms.ToArray();
                }



                pRegion.Region = fEditRegion.txtNameRegion.Text;
                pRegion.GenitiveRegion = fEditRegion.txtGenitiveRegion.Text;
                pRegion.DativeRegion = fEditRegion.txtDativeRegion.Text;

                pRegion.SaveAndFlush();



            }



        }

        public static void AddImage(OpenFileDialog openDialog)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                fEditRegion.pictureRegion.Image = Image.FromFile(openDialog.FileName);
            }
        }

        public cRegion()
        {

        }

        public cRegion(int indexRegion)
        {
            pRegion = tRegion.byID(indexRegion);
        }

        public class cRSA : cRegion
        {
            protected static tRegionalStateAdministration PRSA { get; set; }
            
            public static void Edit(TreeNode trn)
            {
                PRSA = tRegionalStateAdministration.byID((int) trn.Tag);
                
                fEditDepartment.Text = trn.Text.Substring(0, trn.Text.IndexOf(" ")) + " ОДА";

                fEditDepartment.grbEditDepartment.Text = "Данные: " + fEditDepartment.Text;

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;


                fEditDepartment.lblShortName.Text = "Короткое наименование: " + fEditDepartment.Text;

                fEditDepartment.lblName.Text = "Полное наименование: " + fEditDepartment.Text;

                fEditDepartment.txtShortName.Text = PRSA.ShortRSA;

                fEditDepartment.txtName.Text = PRSA.RSA;

                //Адрес



                if (PRSA.AdresRSA == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = PRSA.AdresRSA;

                    fEditDepartment.adressData.Text = cXML.rdAddress(PRSA.AdresRSA);
                }






                //Контакты
                fEditDepartment.txtPhone.Text = PRSA.Phone;

                fEditDepartment.txtSite.Text = PRSA.SiteRSA;

                fEditDepartment.txtFaceBook.Text = PRSA.facebook;

                fEditDepartment.txtTwitter.Text = PRSA.twitter;

                fEditDepartment.txtVK.Text = PRSA.vk_com;


                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {




                    PRSA.ShortRSA = fEditDepartment.txtShortName.Text;

                    PRSA.RSA = fEditDepartment.txtName.Text;


                    PRSA.AdresRSA = fEditDepartment.xmlAdress.Text;


                    //контакты
                    PRSA.Phone = fEditDepartment.txtPhone.Text;

                    PRSA.SiteRSA = fEditDepartment.txtSite.Text;

                    PRSA.facebook = fEditDepartment.txtFaceBook.Text;

                    PRSA.twitter = fEditDepartment.txtTwitter.Text;

                    PRSA.vk_com = fEditDepartment.txtVK.Text;

                    PRSA.ID_RSA = Convert.ToInt32(trn.Tag);

                    PRSA.SaveAndFlush();


                }


            }

            public class cPlacementsRSA : cRSA
            {
                protected static tPlacementsRegionalStateAdministration pPlacementsRSA { get; set; }

                public static void Add(TreeNode trn)
                {

                    PRSA = tRegionalStateAdministration.byID((int) trn.Tag);

                    fEditPlaceman = new frmEditPlaceman();

                    pPlacementsRSA = new tPlacementsRegionalStateAdministration();

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text.Substring(0,
                            Program.fMainPlacements.grbProperty.Text.IndexOf(" ")) + " ОДА";

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int) trn.Tag);



                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {


                        //Вкладка Должность ответсвенно лица
                        pPlacementsRSA.ShortPostRSA = fEditPlaceman.txtShortPost.Text;

                        pPlacementsRSA.PostRSA = fEditPlaceman.txtPost.Text;

                        pPlacementsRSA.PostGenitiveRSA = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsRSA.PostDativeRSA = fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementsRSA.NameRSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRSA.NameRSA = fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementsRSA.NameGenitiveRSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRSA.NameGenitiveRSA = fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementsRSA.NameDativeRSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRSA.NameDativeRSA = fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementsRSA.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsRSA.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsRSA.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsRSA.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsRSA.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsRSA.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {


                            foreach (var VARIABLE in tPlacementsRegionalStateAdministration.byRSA(PRSA.ID_RSA))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementsRSA.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementsRSA.tRegionalStateAdministration = PRSA;

                        pPlacementsRSA.CreateAndFlush();






                    }

                }

                public static void Edit(ListViewItem lsvItem)
                {

                    //загрузка окна и должности
                    pPlacementsRSA = tPlacementsRegionalStateAdministration.byID((int) lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text.Substring(0,
                            Program.fMainPlacements.grbProperty.Text.IndexOf(" ")) + " ОДА";

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int) lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementsRSA.ShortPostRSA;

                    fEditPlaceman.txtPost.Text = pPlacementsRSA.PostRSA;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementsRSA.PostGenitiveRSA;

                    fEditPlaceman.txtPostDative.Text = pPlacementsRSA.PostDativeRSA;

                    // загрузка НЕВИДИМЫХ (О_O => -_-) лейблов
                    fEditPlaceman.xmlName.Text = pPlacementsRSA.NameRSA;
                    fEditPlaceman.xmlNameGenitive.Text = pPlacementsRSA.NameGenitiveRSA;
                    fEditPlaceman.xmlNameDative.Text = pPlacementsRSA.NameDativeRSA;

                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementsRSA.NameRSA);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementsRSA.NameRSA);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementsRSA.NameGenitiveRSA);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementsRSA.NameDativeRSA);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementsRSA.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementsRSA.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementsRSA.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementsRSA.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementsRSA.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementsRSA.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementsRSA.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsRSA.ShortPostRSA = fEditPlaceman.txtShortPost.Text;

                        pPlacementsRSA.PostRSA = fEditPlaceman.txtPost.Text;

                        pPlacementsRSA.PostGenitiveRSA = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsRSA.PostDativeRSA = fEditPlaceman.txtPostDative.Text;

                        pPlacementsRSA.NameRSA = fEditPlaceman.xmlName.Text;

                        pPlacementsRSA.NameGenitiveRSA = fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementsRSA.NameDativeRSA = fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementsRSA.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsRSA.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsRSA.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsRSA.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsRSA.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsRSA.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (
                                var VARIABLE in
                                    tPlacementsRegionalStateAdministration.byRSA(
                                        pPlacementsRSA.tRegionalStateAdministration.ID_RSA))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }
                        pPlacementsRSA.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementsRSA.SaveAndFlush();



                    }





                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementsRegionalStateAdministration T =
                        tPlacementsRegionalStateAdministration.byID((int) lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();

                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementsRegionalStateAdministration T =
                        tPlacementsRegionalStateAdministration.byID((int) lsvItem.Tag);

                    if (T == null) return;

                    foreach (
                        var VARIABLE in
                            tPlacementsRegionalStateAdministration.byRSA(T.tRegionalStateAdministration.ID_RSA))
                    {
                        VARIABLE.Default_ = false;
                        VARIABLE.SaveAndFlush();

                    }

                    T.Default_ = true;

                    T.SaveAndFlush();


                }

                public static void LV(TreeNode trn)
                {



                    Program.fMainPlacements.lsvMain.Items.Clear();


                    foreach (var VARIABLE in tPlacementsRegionalStateAdministration.byRSA((int) trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShortPostRSA;

                        s[1] = cXML.rdShortName(VARIABLE.NameRSA);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementsRSA;
                        alv.Name = trn.Name;
                        Program.fMainPlacements.lsvMain.Items.Add(alv);
                    }

                    for (int i = 0; i < Program.fMainPlacements.lsvMain.Items.Count; i++)
                    {
                        if (Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text == "True")
                        {
                            Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                            Program.fMainPlacements.lsvMain.AddIconToSubitem(i, 2, 0);
                        }
                        else Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                    }

                    Program.fMainPlacements.lsvMain.ShowSubItemIcons(true);


                }


            }
        }

        public class cRegionCEC : cRegion
        {

            protected static tRegionCEC pRegionCEC { get; set; }

            public static void Edit(TreeNode trn)
            {
                pRegionCEC = tRegionCEC.byID((int) trn.Tag);

                fEditDepartment.Text = trn.Parent.Text.Substring(0, trn.Parent.Text.IndexOf(" ")) + " обласна СЕС";

                fEditDepartment.grbEditDepartment.Text = "Данные: " + fEditDepartment.Text;

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;

                fEditDepartment.lblShortName.Text = "Короткое наименование: " + fEditDepartment.Text;

                fEditDepartment.lblName.Text = "Полное наименование: " + fEditDepartment.Text;

                fEditDepartment.txtShortName.Text = pRegionCEC.ShortRegionCEC;

                fEditDepartment.txtName.Text = pRegionCEC.RegionCEC;

                if (pRegionCEC.AdresRegionCEC == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = pRegionCEC.AdresRegionCEC;

                    fEditDepartment.adressData.Text = cXML.rdAddress(pRegionCEC.AdresRegionCEC);
                }

                fEditDepartment.txtPhone.Text = pRegionCEC.Phone;

                fEditDepartment.txtSite.Text = pRegionCEC.SiteRegionCEC;

                fEditDepartment.txtFaceBook.Text = pRegionCEC.facebook;

                fEditDepartment.txtTwitter.Text = pRegionCEC.twitter;

                fEditDepartment.txtVK.Text = pRegionCEC.vk_com;

                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {




                    pRegionCEC.ShortRegionCEC = fEditDepartment.txtShortName.Text;

                    pRegionCEC.RegionCEC = fEditDepartment.txtName.Text;


                    pRegionCEC.AdresRegionCEC = fEditDepartment.xmlAdress.Text;


                    //контакты
                    pRegionCEC.Phone = fEditDepartment.txtPhone.Text;

                    pRegionCEC.SiteRegionCEC = fEditDepartment.txtSite.Text;

                    pRegionCEC.facebook = fEditDepartment.txtFaceBook.Text;

                    pRegionCEC.twitter = fEditDepartment.txtTwitter.Text;

                    pRegionCEC.vk_com = fEditDepartment.txtVK.Text;

                    pRegionCEC.ID_RegionCEC = Convert.ToInt32(trn.Tag);

                    pRegionCEC.SaveAndFlush();


                }



            }

            public class cPlacementRegionCEC : cRegionCEC
            {

                protected static tPlacementRegionCEC pPlacementRegionCEC { get; set; }
            
                public static void Add(TreeNode trn)
                {
                    pRegionCEC=tRegionCEC.byID((int)trn.Tag);

                    fEditPlaceman = new frmEditPlaceman();

                    pPlacementRegionCEC=new tPlacementRegionCEC();

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)trn.Tag);

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {


                        //Вкладка Должность ответсвенно лица
                        pPlacementRegionCEC.ShortPostRegionCEC = fEditPlaceman.txtShortPost.Text;

                        pPlacementRegionCEC.PostRegionCEC = fEditPlaceman.txtPost.Text;

                        pPlacementRegionCEC.PostGenitiveRegionCEC = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementRegionCEC.PostDativeRegionCEC = fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementRegionCEC.NameRegionCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementRegionCEC.NameRegionCEC= fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementRegionCEC.NameGenitiveRegionCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementRegionCEC.NameGenitiveRegionCEC = fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementRegionCEC.NameDativeRegionCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementRegionCEC.NameDativeRegionCEC = fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementRegionCEC.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementRegionCEC.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementRegionCEC.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementRegionCEC.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementRegionCEC.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementRegionCEC.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            
                            
                            foreach (var VARIABLE in tPlacementRegionCEC.byRegionCEC(pRegionCEC.ID_RegionCEC))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementRegionCEC.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementRegionCEC.tRegionCEC = pRegionCEC;

                        pPlacementRegionCEC.CreateAndFlush();






                    }



                }

                public static void Edit(ListViewItem lsvItem)
                {
                    
                    //загрузка окна и должности
                    pPlacementRegionCEC = tPlacementRegionCEC.byID((int)lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementRegionCEC.ShortPostRegionCEC;

                    fEditPlaceman.txtPost.Text = pPlacementRegionCEC.PostRegionCEC;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementRegionCEC.PostGenitiveRegionCEC;

                    fEditPlaceman.txtPostDative.Text = pPlacementRegionCEC.PostDativeRegionCEC;

                    // загрузка НЕВИДИМЫХ (О_O => -_-) лейблов
                    fEditPlaceman.xmlName.Text = pPlacementRegionCEC.NameRegionCEC;
                    fEditPlaceman.xmlNameGenitive.Text = pPlacementRegionCEC.NameGenitiveRegionCEC;
                    fEditPlaceman.xmlNameDative.Text = pPlacementRegionCEC.NameDativeRegionCEC;

                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementRegionCEC.NameRegionCEC);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementRegionCEC.NameRegionCEC);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementRegionCEC.NameGenitiveRegionCEC);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementRegionCEC.NameDativeRegionCEC);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementRegionCEC.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementRegionCEC.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementRegionCEC.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementRegionCEC.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementRegionCEC.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementRegionCEC.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementRegionCEC.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementRegionCEC.ShortPostRegionCEC = fEditPlaceman.txtShortPost.Text;

                        pPlacementRegionCEC.PostRegionCEC = fEditPlaceman.txtPost.Text;

                        pPlacementRegionCEC.PostGenitiveRegionCEC = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementRegionCEC.PostDativeRegionCEC = fEditPlaceman.txtPostDative.Text;

                        pPlacementRegionCEC.NameRegionCEC = fEditPlaceman.xmlName.Text;

                        pPlacementRegionCEC.NameGenitiveRegionCEC = fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementRegionCEC.NameDativeRegionCEC = fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementRegionCEC.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementRegionCEC.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementRegionCEC.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementRegionCEC.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementRegionCEC.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementRegionCEC.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (var VARIABLE in tPlacementRegionCEC.byRegionCEC(pPlacementRegionCEC.tRegionCEC.ID_RegionCEC))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }
                        pPlacementRegionCEC.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementRegionCEC.SaveAndFlush();



                    }
                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementRegionCEC T = tPlacementRegionCEC.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();
                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementRegionCEC T = tPlacementRegionCEC.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    foreach (var VARIABLE in tPlacementRegionCEC.byRegionCEC(T.tRegionCEC.ID_RegionCEC))
                    {
                        VARIABLE.Default_ = false;
                        VARIABLE.SaveAndFlush();

                    }

                    T.Default_ = true;

                    T.SaveAndFlush();

                }

                public static void LV(TreeNode trn)
                {

                    Program.fMainPlacements.lsvMain.Items.Clear();


                    foreach (var VARIABLE in tPlacementRegionCEC.byRegionCEC((int) trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShortPostRegionCEC;

                        s[1] = cXML.rdShortName(VARIABLE.NameRegionCEC);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementRegionCEC;
                        alv.Name = trn.Name;
                        Program.fMainPlacements.lsvMain.Items.Add(alv);
                    }

                    for (int i = 0; i < Program.fMainPlacements.lsvMain.Items.Count; i++)
                    {
                        if (Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text == "True")
                        {
                            Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                            Program.fMainPlacements.lsvMain.AddIconToSubitem(i, 2, 0);
                        }
                        else Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                    }

                    Program.fMainPlacements.lsvMain.ShowSubItemIcons(true);


                }

            }

        }

        public class cDepartmentECO : cRegion
        {

            protected static tDepartmentECO pDepartmentEco { get; set; }

            public static void Edit(TreeNode trn)
            {

                pDepartmentEco = tDepartmentECO.byID((int)trn.Tag);

                fEditDepartment.Text = trn.Parent.Text + ": Обласне управління екології та природних ресурсів";

                fEditDepartment.grbEditDepartment.Text = "Данные: Обласне управління екології та природних ресурсів";

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;

                fEditDepartment.lblShortName.Text =
                    "Короткое наименование: Обласного управління екології та природних ресурсів";

                fEditDepartment.lblName.Text =
                    "Полное наименование: Обласного управління екології та природних ресурсів";

                fEditDepartment.txtShortName.Text = pDepartmentEco.ShortDepECO;

                fEditDepartment.txtName.Text = pDepartmentEco.DepECO;

                if (pDepartmentEco.DepECO == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = pDepartmentEco.AdresDepECO;

                    fEditDepartment.adressData.Text = cXML.rdAddress(pDepartmentEco.AdresDepECO);
                }

                fEditDepartment.txtPhone.Text = pDepartmentEco.Phone;

                fEditDepartment.txtSite.Text = pDepartmentEco.SiteDepECO;

                fEditDepartment.txtFaceBook.Text = pDepartmentEco.facebook;

                fEditDepartment.txtTwitter.Text = pDepartmentEco.twitter;

                fEditDepartment.txtVK.Text = pDepartmentEco.vk_com;

                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {




                    pDepartmentEco.ShortDepECO = fEditDepartment.txtShortName.Text;

                    pDepartmentEco.DepECO = fEditDepartment.txtName.Text;


                    pDepartmentEco.AdresDepECO= fEditDepartment.xmlAdress.Text;


                    //контакты
                    pDepartmentEco.Phone = fEditDepartment.txtPhone.Text;

                    pDepartmentEco.SiteDepECO = fEditDepartment.txtSite.Text;

                    pDepartmentEco.facebook = fEditDepartment.txtFaceBook.Text;

                    pDepartmentEco.twitter = fEditDepartment.txtTwitter.Text;

                    pDepartmentEco.vk_com = fEditDepartment.txtVK.Text;

                    pDepartmentEco.ID_DepartmentECO = Convert.ToInt32(trn.Tag);

                    pDepartmentEco.SaveAndFlush();


                }


            }
            
            public class cPlacementsDepEco : cDepartmentECO
            {

                protected static tPlacementsDepEco pPlacementsDepEco { get; set; }

                public static void Add(TreeNode trn)
                {
                    pDepartmentEco=tDepartmentECO.byID((int)trn.Tag);

                    fEditPlaceman=new frmEditPlaceman();

                    pPlacementsDepEco = new tPlacementsDepEco();


                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)trn.Tag);

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {


                        //Вкладка Должность ответсвенно лица
                        pPlacementsDepEco.ShortPostDepECO = fEditPlaceman.txtShortPost.Text;

                        pPlacementsDepEco.PostDepECO = fEditPlaceman.txtPost.Text;

                        pPlacementsDepEco.PostGenitiveDepECO = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDepEco.PostDativeDepECO = fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementsDepEco.NameDepECO = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDepEco.NameDepECO = fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementsDepEco.NameGenitiveDepECO = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDepEco.NameGenitiveDepECO = fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementsDepEco.NameDativeDepECO= Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDepEco.NameDativeDepECO = fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementsDepEco.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDepEco.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDepEco.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDepEco.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDepEco.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDepEco.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {


                            foreach (var VARIABLE in tPlacementsDepEco.byDepECO(pDepartmentEco.ID_DepartmentECO))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementsDepEco.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementsDepEco.tDepartmentECO = pDepartmentEco;

                        pPlacementsDepEco.CreateAndFlush();






                    }


                }

                public static void Edit(ListViewItem lsvItem)
                {
                    //загрузка окна и должности
                    pPlacementsDepEco = tPlacementsDepEco.byID((int)lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementsDepEco.ShortPostDepECO;

                    fEditPlaceman.txtPost.Text = pPlacementsDepEco.PostDepECO;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementsDepEco.PostGenitiveDepECO;

                    fEditPlaceman.txtPostDative.Text = pPlacementsDepEco.PostDativeDepECO;

                    // загрузка НЕВИДИМЫХ (О_O => -_-) лейблов
                    fEditPlaceman.xmlName.Text = pPlacementsDepEco.NameDepECO;
                    fEditPlaceman.xmlNameGenitive.Text = pPlacementsDepEco.NameGenitiveDepECO;
                    fEditPlaceman.xmlNameDative.Text = pPlacementsDepEco.NameDativeDepECO;


                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementsDepEco.NameDepECO);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementsDepEco.NameDepECO);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementsDepEco.NameGenitiveDepECO);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementsDepEco.NameDativeDepECO);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementsDepEco.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementsDepEco.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementsDepEco.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementsDepEco.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementsDepEco.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementsDepEco.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementsDepEco.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsDepEco.ShortPostDepECO = fEditPlaceman.txtShortPost.Text;

                        pPlacementsDepEco.PostDepECO= fEditPlaceman.txtPost.Text;

                        pPlacementsDepEco.PostGenitiveDepECO = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDepEco.PostDativeDepECO = fEditPlaceman.txtPostDative.Text;

                        pPlacementsDepEco.NameDepECO = fEditPlaceman.xmlName.Text;

                        pPlacementsDepEco.NameGenitiveDepECO = fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementsDepEco.NameDativeDepECO = fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementsDepEco.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDepEco.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDepEco.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDepEco.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDepEco.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDepEco.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (var VARIABLE in tPlacementsDepEco.byDepECO(pPlacementsDepEco.tDepartmentECO.ID_DepartmentECO))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }
                        pPlacementsDepEco.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementsDepEco.SaveAndFlush();



                    }
                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementsDepEco T=tPlacementsDepEco.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();

                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementsDepEco T = tPlacementsDepEco.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    foreach (var VARIABLE in tPlacementsDepEco.byDepECO(T.tDepartmentECO.ID_DepartmentECO))
                    {
                        VARIABLE.Default_ = false;
                        VARIABLE.SaveAndFlush();

                    }

                    T.Default_ = true;

                    T.SaveAndFlush();
                }

                public static void LV(TreeNode trn)
                {

                    Program.fMainPlacements.lsvMain.Items.Clear();


                    foreach (var VARIABLE in tPlacementsDepEco.byDepECO((int)trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShortPostDepECO;

                        s[1] = cXML.rdShortName(VARIABLE.NameDepECO);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementDepEco;
                        alv.Name = trn.Name;
                        Program.fMainPlacements.lsvMain.Items.Add(alv);
                    }

                    for (int i = 0; i < Program.fMainPlacements.lsvMain.Items.Count; i++)
                    {
                        if (Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text == "True")
                        {
                            Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                            Program.fMainPlacements.lsvMain.AddIconToSubitem(i, 2, 0);
                        }
                        else Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                    }

                    Program.fMainPlacements.lsvMain.ShowSubItemIcons(true);


                }

            }

        }

        public class cRegionAgencyWarer : cRegion
        {

            protected static tRegionAgencyWarer pRAW { get; set; }

            public static void Edit(TreeNode trn)
            {
                pRAW = tRegionAgencyWarer.byID((int) trn.Tag);

                fEditDepartment.Text = trn.Parent.Text + ": Обласне управління водних ресусів";

                fEditDepartment.grbEditDepartment.Text = "Данные: Обласне управління водних ресусів";

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;

                fEditDepartment.lblShortName.Text =
                    "Короткое наименование: Обласного управління водних ресусів";

                fEditDepartment.lblName.Text =
                    "Полное наименование: Обласного управління водних ресусів";

                fEditDepartment.txtShortName.Text = pRAW.ShortRAW;

                fEditDepartment.txtName.Text = pRAW.RAW;

                if (pRAW.RAW == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = pRAW.AdresRAW;

                    fEditDepartment.adressData.Text = cXML.rdAddress(pRAW.AdresRAW);
                }

                fEditDepartment.txtPhone.Text = pRAW.Phone;

                fEditDepartment.txtSite.Text = pRAW.SiteRAW;

                fEditDepartment.txtFaceBook.Text = pRAW.facebook;

                fEditDepartment.txtTwitter.Text = pRAW.twitter;

                fEditDepartment.txtVK.Text = pRAW.vk_com;

                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {


                    pRAW.ShortRAW = fEditDepartment.txtShortName.Text;

                    pRAW.RAW = fEditDepartment.txtName.Text;
                    
                    pRAW.AdresRAW= fEditDepartment.xmlAdress.Text;


                    //контакты
                    pRAW.Phone = fEditDepartment.txtPhone.Text;

                    pRAW.SiteRAW= fEditDepartment.txtSite.Text;

                    pRAW.facebook = fEditDepartment.txtFaceBook.Text;

                    pRAW.twitter = fEditDepartment.txtTwitter.Text;

                    pRAW.vk_com = fEditDepartment.txtVK.Text;

                    pRAW.ID_RAW = Convert.ToInt32(trn.Tag);

                    pRAW.SaveAndFlush();


                }


            }

            public class cPlacementsRAW : cRegionAgencyWarer
            {

                protected static tPlacementsRegionAgencyWarer pPlacementsRAW { get; set; }

                
                public static void Add(TreeNode trn)
                {
                    pRAW=tRegionAgencyWarer.byID((int)trn.Tag);

                    fEditPlaceman =new frmEditPlaceman();

                    pPlacementsRAW = new tPlacementsRegionAgencyWarer();

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)trn.Tag);

                    if (fEditPlaceman.ShowDialog()==DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsRAW.ShortPostRAW = fEditPlaceman.txtShortPost.Text;

                        pPlacementsRAW.PostRAW = fEditPlaceman.txtPost.Text;

                        pPlacementsRAW.PostGenitiveRAW= fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsRAW.PostDativeRAW= fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementsRAW.NameRAW= Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRAW.NameRAW= fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementsRAW.NameGenitiveRAW= Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRAW.NameGenitiveRAW= fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementsRAW.NameDativeRAW= Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsRAW.NameDativeRAW= fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementsRAW.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsRAW.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsRAW.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsRAW.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsRAW.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsRAW.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {


                            foreach (var VARIABLE in tPlacementsRegionAgencyWarer.byRAW(pRAW.ID_RAW))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementsRAW.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementsRAW.tRegionAgencyWarer = pRAW;

                        pPlacementsRAW.CreateAndFlush();


                    }

                }

                public static void Edit(ListViewItem lsvItem)
                {
                    //загрузка окна и должности
                    pPlacementsRAW = tPlacementsRegionAgencyWarer.byID((int)lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementsRAW.ShortPostRAW;

                    fEditPlaceman.txtPost.Text = pPlacementsRAW.PostRAW;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementsRAW.PostGenitiveRAW;

                    fEditPlaceman.txtPostDative.Text = pPlacementsRAW.PostDativeRAW;

                    // загрузка НЕВИДИМЫХ (О_O => -_-) лейблов
                    fEditPlaceman.xmlName.Text = pPlacementsRAW.NameRAW;
                    fEditPlaceman.xmlNameGenitive.Text = pPlacementsRAW.NameGenitiveRAW;
                    fEditPlaceman.xmlNameDative.Text = pPlacementsRAW.NameDativeRAW;


                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementsRAW.NameRAW);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementsRAW.NameRAW);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementsRAW.NameGenitiveRAW);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementsRAW.NameDativeRAW);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementsRAW.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementsRAW.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementsRAW.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementsRAW.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementsRAW.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementsRAW.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementsRAW.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsRAW.ShortPostRAW = fEditPlaceman.txtShortPost.Text;

                        pPlacementsRAW.PostRAW = fEditPlaceman.txtPost.Text;

                        pPlacementsRAW.PostGenitiveRAW= fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsRAW.PostDativeRAW= fEditPlaceman.txtPostDative.Text;

                        pPlacementsRAW.NameRAW = fEditPlaceman.xmlName.Text;

                        pPlacementsRAW.NameGenitiveRAW= fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementsRAW.NameDativeRAW= fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementsRAW.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsRAW.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsRAW.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsRAW.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsRAW.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsRAW.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (var VARIABLE in tPlacementsRegionAgencyWarer.byRAW(pPlacementsRAW.tRegionAgencyWarer.ID_RAW))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }
                        pPlacementsRAW.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementsRAW.SaveAndFlush();



                    }

                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementsRegionAgencyWarer T = tPlacementsRegionAgencyWarer.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();
                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementsRegionAgencyWarer T = tPlacementsRegionAgencyWarer.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    foreach (var VARIABLE in tPlacementsRegionAgencyWarer.byRAW(T.tRegionAgencyWarer.ID_RAW))
                    {
                        VARIABLE.Default_ = false;
                        VARIABLE.SaveAndFlush();

                    }

                    T.Default_ = true;

                    T.SaveAndFlush();

                }

                public static void LV(TreeNode trn)
                {

                    Program.fMainPlacements.lsvMain.Items.Clear();


                    foreach (var VARIABLE in tPlacementsRegionAgencyWarer.byRAW((int) trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShortPostRAW;

                        s[1] = cXML.rdShortName(VARIABLE.NameRAW);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementsRAW;
                        alv.Name = trn.Name;
                        Program.fMainPlacements.lsvMain.Items.Add(alv);
                    }

                    for (int i = 0; i < Program.fMainPlacements.lsvMain.Items.Count; i++)
                    {
                        if (Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text == "True")
                        {
                            Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                            Program.fMainPlacements.lsvMain.AddIconToSubitem(i, 2, 0);
                        }
                        else Program.fMainPlacements.lsvMain.Items[i].SubItems[2].Text = "";
                    }

                    Program.fMainPlacements.lsvMain.ShowSubItemIcons(true);
                    

                }


            }

            
        }


    }

    

}

