using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Placements.db;
using Placements.Kernel;
using Placements.Properties;
using Placements.src;
using Placements._kernel;


namespace Placements.main
{
    public class cDistrict:cRegion
    {


        protected static tDistrict pDistrict { get; set; }
        
        private static frmEditDepartment fEditDepartment=new frmEditDepartment();

        private static frmEditPlaceman fEditPlaceman = new frmEditPlaceman();

        private static frmEditDistrict fDistrict=new frmEditDistrict();

        public cDistrict()
        {

        }

        public cDistrict(int idDistrict)
        {
            pDistrict=tDistrict.byID(idDistrict);
        }

        public static cRegion operator +(cRegion region, cDistrict district)
        {
            Cursor.Current = Cursors.Default;


            pDistrict = new tDistrict();

            fDistrict=new frmEditDistrict();
            
            if (fDistrict.ShowDialog() == DialogResult.OK)
            {

                pDistrict = new tDistrict();

                cDSA DSA = new cDSA();
                DSA++;

                cDistrictCEC DistrictCEC = new cDistrictCEC();

                DistrictCEC++;



                if (fDistrict.pictureDistrict.Image == null)
                {

                    MemoryStream ms = new MemoryStream((byte[])new ImageConverter().ConvertTo(Resources.Ukraine, typeof(byte[])));
                    pDistrict.icon_ = ms.ToArray();

                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    fDistrict.pictureDistrict.Image.Save(ms, ImageFormat.Png);
                    pDistrict.icon_ = ms.ToArray();
                }

                pDistrict.District = fDistrict.txtNameDistrict.Text;

                pDistrict.GenitiveDistrict = fDistrict.txtGenitiveDistrict.Text;

                pDistrict.DativeDistrict = fDistrict.txtDativeDistrict.Text;

                pDistrict.tRegion = pRegion;

                pDistrict.CreateAndFlush();


                

               

                cPlacements.UpdateData(Program.fMainPlacements.trvMain);
                cNavigation.SelectNode(pDistrict );
                Cursor.Current = Cursors.Default;

               

            }
            return district;
        }

        public static cRegion operator -(cRegion region, cDistrict district)
        {
            cDSA DSA=new cDSA(pDistrict.ID_District);
            
            DSA--;
            
            cDistrictCEC DistrictCEC=new cDistrictCEC(pDistrict.ID_District);

            DistrictCEC--;

            pDistrict.DeleteAndFlush();

            return district;
        }
        
        public static void AddImage(OpenFileDialog openDialog)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                fDistrict.pictureDistrict.Image = Image.FromFile(openDialog.FileName);
            }
        }

        public static void Edit(int indexID)
        {
            pDistrict=tDistrict.byID(indexID);
            
            pRegion = tDistrict.byID(indexID).tRegion;

            fDistrict.Text = pRegion.Region + ": " + pDistrict.District;



            if (pDistrict.icon_ != null)
            {
                using (MemoryStream ms = new MemoryStream(pDistrict.icon_))
                {

                    fDistrict.pictureDistrict.Image = Image.FromStream(ms);
                }
            }
            else
            {
                fDistrict.pictureDistrict.Image = null;
            }


            fDistrict.txtNameDistrict.Text = pDistrict.District;
            
            fDistrict.txtGenitiveDistrict.Text = pDistrict.GenitiveDistrict;
            
            fDistrict.txtDativeDistrict.Text = pDistrict.DativeDistrict;


            if (fDistrict.ShowDialog()==DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                if (fDistrict.pictureDistrict.Image == null)
                {

                    MemoryStream ms = new MemoryStream((byte[])new ImageConverter().ConvertTo(Resources.Ukraine, typeof(byte[])));
                    pDistrict.icon_ = ms.ToArray();

                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    fDistrict.pictureDistrict.Image.Save(ms, ImageFormat.Png);
                    pDistrict.icon_ = ms.ToArray();
                }
                
                pDistrict.District = fDistrict.txtNameDistrict.Text;

                pDistrict.GenitiveDistrict = fDistrict.txtGenitiveDistrict.Text;
                
                pDistrict.DativeDistrict = fDistrict.txtDativeDistrict.Text;

                

                pDistrict.SaveAndFlush();

                cPlacements.UpdateData(Program.fMainPlacements.trvMain);

                cNavigation.SelectNode(pDistrict);

                Cursor.Current = Cursors.Default;

            }

        }
        
        public class cDSA:cDistrict
        {

            public cDSA()
            {

            }

            public cDSA(int idDistrict)
            {
                PDSA=tDistrictStateAdministration.byID(idDistrict);
            }

            protected static tDistrictStateAdministration PDSA { get; set; }

            public static cDSA operator ++(cDSA DSA)
            {
                PDSA = new tDistrictStateAdministration();

                PDSA.AdresDSA = Resources.xmlAddress;

                PDSA.CreateAndFlush();
                
                return DSA;
            }
            
            public static cDSA operator --(cDSA DSA)
            {

                foreach (var VAR in tPlacementsDistrictStateAdministration.byDSA(PDSA.ID_DSA))
                {
                    VAR.DeleteAndFlush();
                }

                PDSA.DeleteAndFlush();

                return DSA;
            }

            public static void Edit(TreeNode trn)
            {
                PDSA = tDistrictStateAdministration.byID((int)trn.Tag);
                if (trn.Text.IndexOf(" ")==-1)
                {
                    fEditDepartment.Text = trn.Text + " РДА";
                }
                else
                {
                    fEditDepartment.Text = trn.Text.Substring(0, trn.Text.IndexOf(" ")) + " РДА";
                }

                //fEditDepartment.Text = trn.Text.Substring(0, trn.Text.IndexOf(" ")) + " РДА";

                fEditDepartment.grbEditDepartment.Text = "Данные: " + fEditDepartment.Text;

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;


                fEditDepartment.lblShortName.Text = "Короткое наименование: " + fEditDepartment.Text;

                fEditDepartment.lblName.Text = "Полное наименование: " + fEditDepartment.Text;

                fEditDepartment.txtShortName.Text = PDSA.ShortDSA;

                fEditDepartment.txtName.Text = PDSA.DSA;

                //Адрес



                if (PDSA.AdresDSA == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = PDSA.AdresDSA;

                    fEditDepartment.adressData.Text = cXML.rdAddress(PDSA.AdresDSA);
                }






                //Контакты
                fEditDepartment.txtPhone.Text = PDSA.Phone;

                fEditDepartment.txtSite.Text = PDSA.SiteDSA;

                fEditDepartment.txtFaceBook.Text = PDSA.facebook;

                fEditDepartment.txtTwitter.Text = PDSA.twitter;

                fEditDepartment.txtVK.Text = PDSA.vk_com;


                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {




                    PDSA.ShortDSA = fEditDepartment.txtShortName.Text;

                    PDSA.DSA = fEditDepartment.txtName.Text;


                    PDSA.AdresDSA = fEditDepartment.xmlAdress.Text;


                    //контакты
                    PDSA.Phone = fEditDepartment.txtPhone.Text;

                    PDSA.SiteDSA = fEditDepartment.txtSite.Text;

                    PDSA.facebook = fEditDepartment.txtFaceBook.Text;

                    PDSA.twitter = fEditDepartment.txtTwitter.Text;

                    PDSA.vk_com = fEditDepartment.txtVK.Text;

                    PDSA.ID_DSA = Convert.ToInt32(trn.Tag);

                    PDSA.SaveAndFlush();


                }


            }

            public class cPlacementsDSA : cDSA
            {
                protected static tPlacementsDistrictStateAdministration pPlacementsDSA { get; set; }
                
                public static void Add(TreeNode trn)
                {
                    PDSA = tDistrictStateAdministration.byID((int) trn.Tag);

                    fEditPlaceman = new frmEditPlaceman();

                    pPlacementsDSA = new tPlacementsDistrictStateAdministration();

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text.Substring(0,
                            Program.fMainPlacements.grbProperty.Text.IndexOf(" ")) + " РДА";

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int) trn.Tag);



                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {


                        //Вкладка Должность ответсвенно лица
                        pPlacementsDSA.ShortPostDSA = fEditPlaceman.txtShortPost.Text;

                        pPlacementsDSA.PostDSA = fEditPlaceman.txtPost.Text;

                        pPlacementsDSA.PostGenitiveDSA= fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDSA.PostDativeDSA = fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementsDSA.NameDSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDSA.NameDSA = fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementsDSA.NameGenitiveDSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDSA.NameGenitiveDSA = fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementsDSA.NameDativeDSA = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDSA.NameDativeDSA = fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementsDSA.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDSA.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDSA.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDSA.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDSA.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDSA.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {


                            foreach (var VARIABLE in tPlacementsDistrictStateAdministration.byDSA(PDSA.ID_DSA))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementsDSA.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementsDSA.tDistrictStateAdministration = PDSA;

                        pPlacementsDSA.CreateAndFlush();






                    }





                    
                }

                public static void Edit(ListViewItem lsvItem)
                {
                    //загрузка окна и должности
                    pPlacementsDSA = tPlacementsDistrictStateAdministration.byID((int) lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text.Substring(0,
                            Program.fMainPlacements.grbProperty.Text.IndexOf(" ")) + " РДА";

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int) lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementsDSA.ShortPostDSA;

                    fEditPlaceman.txtPost.Text = pPlacementsDSA.PostDSA;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementsDSA.PostGenitiveDSA;

                    fEditPlaceman.txtPostDative.Text = pPlacementsDSA.PostDativeDSA;


                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementsDSA.NameDSA);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementsDSA.NameDSA);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementsDSA.NameGenitiveDSA);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementsDSA.NameDativeDSA);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementsDSA.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementsDSA.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementsDSA.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementsDSA.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementsDSA.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementsDSA.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementsDSA.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsDSA.ShortPostDSA = fEditPlaceman.txtShortPost.Text;

                        pPlacementsDSA.PostDSA = fEditPlaceman.txtPost.Text;

                        pPlacementsDSA.PostGenitiveDSA = fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDSA.PostDativeDSA = fEditPlaceman.txtPostDative.Text;

                        pPlacementsDSA.NameDSA = fEditPlaceman.xmlName.Text;

                        pPlacementsDSA.NameGenitiveDSA = fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementsDSA.NameDativeDSA = fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementsDSA.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDSA.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDSA.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDSA.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDSA.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDSA.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (
                                var VARIABLE in
                                    tPlacementsDistrictStateAdministration.byDSA(
                                        pPlacementsDSA.tDistrictStateAdministration.ID_DSA))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }
                        pPlacementsDSA.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementsDSA.SaveAndFlush();



                    }


                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementsDistrictStateAdministration T =
                       tPlacementsDistrictStateAdministration.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();

                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementsDistrictStateAdministration T =
                      tPlacementsDistrictStateAdministration.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    foreach (
                        var VARIABLE in
                            tPlacementsDistrictStateAdministration.byDSA(T.tDistrictStateAdministration.ID_DSA))
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


                    foreach (var VARIABLE in tPlacementsDistrictStateAdministration.byDSA((int)trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShortPostDSA;

                        s[1] = cXML.rdShortName(VARIABLE.NameDSA);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementsDSA;
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
        
        public class cDistrictCEC:cDistrict
        {

            public cDistrictCEC()
            {

            }

            public cDistrictCEC(int idDistrict)
            {
                pDistrictCEC=tDistrictCEC.byID(idDistrict);
            }

            protected static tDistrictCEC pDistrictCEC { get; set; }

            public static cDistrictCEC operator ++(cDistrictCEC DistrictCEC)
            {
                pDistrictCEC=new tDistrictCEC();

                pDistrictCEC.AdresDistrictCEC = Resources.xmlAddress;

                pDistrictCEC.CreateAndFlush();
                
                return DistrictCEC;
            }

            public static cDistrictCEC operator --(cDistrictCEC DistrictCEC)
            {
                foreach (var VAR in tPlacementsDistrictCEC.byDistrictCEC(pDistrictCEC.ID_DistrictCEC))
                {
                    VAR.DeleteAndFlush();
                }

                pDistrictCEC.DeleteAndFlush();
                
                return DistrictCEC;
            }

            public static void Edit(TreeNode trn)
            {
                pDistrictCEC = tDistrictCEC.byID((int)trn.Tag);
                
                fEditDepartment.Text = trn.Parent.Text + ": Районна СЕС";

                fEditDepartment.grbEditDepartment.Text = "Данные: " + fEditDepartment.Text;

                fEditDepartment.lblID.Text = Convert.ToInt32(trn.Tag).ToString();

                fEditDepartment.lblConstType.Text = trn.Name;

                fEditDepartment.lblShortName.Text = "Короткое наименование: Районної СЕС";

                fEditDepartment.lblName.Text = "Полное наименование: Районної СЕС";

                fEditDepartment.txtShortName.Text = pDistrictCEC.ShortDistrictCEC;

                fEditDepartment.txtName.Text = pDistrictCEC.DistrictCEC;

                if (pDistrictCEC.AdresDistrictCEC == null)
                {
                    fEditDepartment.xmlAdress.Text = Resources.xmlConstAddress;

                    fEditDepartment.adressData.Text = cXML.rdAddress(Resources.xmlConstAddress);
                }
                else
                {
                    fEditDepartment.xmlAdress.Text = pDistrictCEC.AdresDistrictCEC;

                    fEditDepartment.adressData.Text = cXML.rdAddress(pDistrictCEC.AdresDistrictCEC);
                }

                fEditDepartment.txtPhone.Text = pDistrictCEC.Phone;

                fEditDepartment.txtSite.Text = pDistrictCEC.SiteDistrictCEC;

                fEditDepartment.txtFaceBook.Text = pDistrictCEC.facebook;

                fEditDepartment.txtTwitter.Text = pDistrictCEC.twitter;

                fEditDepartment.txtVK.Text = pDistrictCEC.vk_com;

                if (fEditDepartment.ShowDialog() == DialogResult.OK)
                {




                    pDistrictCEC.ShortDistrictCEC= fEditDepartment.txtShortName.Text;

                    pDistrictCEC.DistrictCEC= fEditDepartment.txtName.Text;


                    pDistrictCEC.AdresDistrictCEC= fEditDepartment.xmlAdress.Text;


                    //контакты
                    pDistrictCEC.Phone = fEditDepartment.txtPhone.Text;

                    pDistrictCEC.SiteDistrictCEC = fEditDepartment.txtSite.Text;

                    pDistrictCEC.facebook = fEditDepartment.txtFaceBook.Text;

                    pDistrictCEC.twitter = fEditDepartment.txtTwitter.Text;

                    pDistrictCEC.vk_com = fEditDepartment.txtVK.Text;

                    pDistrictCEC.ID_DistrictCEC = Convert.ToInt32(trn.Tag);

                    pDistrictCEC.SaveAndFlush();


                }



            }

            public class cPlacementsDistrictCEC : cDistrictCEC
            {

                protected static tPlacementsDistrictCEC pPlacementsDistrictCEC { get; set; }

                public static void Add(TreeNode trn)
                {
                    pDistrictCEC = tDistrictCEC.byID((int)trn.Tag);

                    fEditPlaceman = new frmEditPlaceman();

                    pPlacementsDistrictCEC = new tPlacementsDistrictCEC();

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = trn.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)trn.Tag);

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {


                        //Вкладка Должность ответсвенно лица
                        pPlacementsDistrictCEC.ShorDistrictCEC = fEditPlaceman.txtShortPost.Text;

                        pPlacementsDistrictCEC.PostDistrictCEC = fEditPlaceman.txtPost.Text;

                        pPlacementsDistrictCEC.PostGenitiveDistrictCEC= fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDistrictCEC.PostDativeDistrictCEC= fEditPlaceman.txtPostDative.Text;


                        if (fEditPlaceman.xmlName.Text == "xmlName")
                        {
                            pPlacementsDistrictCEC.NameDistrictCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDistrictCEC.NameDistrictCEC = fEditPlaceman.xmlName.Text;
                        }



                        if (fEditPlaceman.xmlNameGenitive.Text == "xmlNameGenitive")
                        {
                            pPlacementsDistrictCEC.NameGenitiveDistrictCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDistrictCEC.NameGenitiveDistrictCEC = fEditPlaceman.xmlNameGenitive.Text;
                        }




                        if (fEditPlaceman.xmlNameDative.Text == "xmlNameDative")
                        {
                            pPlacementsDistrictCEC.NameDativeDistrictCEC = Resources.xmlConstName;
                        }
                        else
                        {
                            pPlacementsDistrictCEC.NameDativeDistrictCEC = fEditPlaceman.xmlNameDative.Text;
                        }



                        //Вкладка Контактные данные
                        pPlacementsDistrictCEC.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDistrictCEC.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDistrictCEC.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDistrictCEC.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDistrictCEC.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDistrictCEC.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {


                            foreach (var VARIABLE in tPlacementsDistrictCEC.byDistrictCEC(pDistrictCEC.ID_DistrictCEC))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            }
                        }

                        pPlacementsDistrictCEC.Default_ = fEditPlaceman.cheStatus.Checked;

                        pPlacementsDistrictCEC.tDistrictCEC = pDistrictCEC;

                        pPlacementsDistrictCEC.CreateAndFlush();






                    }

                }

                public static void Edit(ListViewItem lsvItem)
                {

                    //загрузка окна и должности
                    pPlacementsDistrictCEC = tPlacementsDistrictCEC.byID((int)lsvItem.Tag);

                    fEditPlaceman.Text =
                        Program.fMainPlacements.grbProperty.Text;

                    fEditPlaceman.lblConstType.Text = lsvItem.Name;

                    fEditPlaceman.lblID.Text = Convert.ToString((int)lsvItem.Tag);

                    fEditPlaceman.txtShortPost.Text = pPlacementsDistrictCEC.ShorDistrictCEC;

                    fEditPlaceman.txtPost.Text = pPlacementsDistrictCEC.PostDistrictCEC;

                    fEditPlaceman.txtPostGenitive.Text = pPlacementsDistrictCEC.PostGenitiveDistrictCEC;

                    fEditPlaceman.txtPostDative.Text = pPlacementsDistrictCEC.PostDativeDistrictCEC;


                    //загрузка имени
                    fEditPlaceman.txtShortName.Text = cXML.rdShortName(pPlacementsDistrictCEC.NameDistrictCEC);

                    fEditPlaceman.txtName.Text = cXML.rdName(pPlacementsDistrictCEC.NameDistrictCEC);

                    fEditPlaceman.txtNameGenitive.Text = cXML.rdName(pPlacementsDistrictCEC.NameDistrictCEC);

                    fEditPlaceman.txtNameDative.Text = cXML.rdName(pPlacementsDistrictCEC.NameDistrictCEC);



                    //загрузка контактов
                    fEditPlaceman.txtPhone.Text = pPlacementsDistrictCEC.Phone;

                    fEditPlaceman.txtPhoneMobile.Text = pPlacementsDistrictCEC.PhoneMobile;

                    fEditPlaceman.txtEmail.Text = pPlacementsDistrictCEC.Email_;

                    fEditPlaceman.txtFacebook.Text = pPlacementsDistrictCEC.facebook;

                    fEditPlaceman.txtTwitter.Text = pPlacementsDistrictCEC.twitter;

                    fEditPlaceman.txtVK.Text = pPlacementsDistrictCEC.vk_com;

                    fEditPlaceman.cheStatus.Checked = pPlacementsDistrictCEC.Default_;

                    if (fEditPlaceman.ShowDialog() == DialogResult.OK)
                    {
                        //Вкладка Должность ответсвенно лица
                        pPlacementsDistrictCEC.ShorDistrictCEC= fEditPlaceman.txtShortPost.Text;

                        pPlacementsDistrictCEC.PostDistrictCEC= fEditPlaceman.txtPost.Text;

                        pPlacementsDistrictCEC.PostGenitiveDistrictCEC= fEditPlaceman.txtPostGenitive.Text;

                        pPlacementsDistrictCEC.PostDativeDistrictCEC= fEditPlaceman.txtPostDative.Text;

                        pPlacementsDistrictCEC.NameDistrictCEC = fEditPlaceman.xmlName.Text;

                        pPlacementsDistrictCEC.NameGenitiveDistrictCEC= fEditPlaceman.xmlNameGenitive.Text;

                        pPlacementsDistrictCEC.NameDativeDistrictCEC = fEditPlaceman.xmlNameDative.Text;




                        //Вкладка Контактные данные
                        pPlacementsDistrictCEC.Phone = fEditPlaceman.txtPhone.Text;

                        pPlacementsDistrictCEC.PhoneMobile = fEditPlaceman.txtPhoneMobile.Text;

                        pPlacementsDistrictCEC.Email_ = fEditPlaceman.txtEmail.Text;

                        pPlacementsDistrictCEC.facebook = fEditPlaceman.txtFacebook.Text;

                        pPlacementsDistrictCEC.twitter = fEditPlaceman.txtTwitter.Text;

                        pPlacementsDistrictCEC.vk_com = fEditPlaceman.txtVK.Text;


                        //Значение по умолчанию

                        if (fEditPlaceman.cheStatus.Checked)
                        {
                            foreach (var VARIABLE in tPlacementsDistrictCEC.byDistrictCEC(pPlacementsDistrictCEC.tDistrictCEC.ID_DistrictCEC))
                            {
                                VARIABLE.Default_ = false;
                                VARIABLE.SaveAndFlush();
                            } 
                        }
                        pPlacementsDistrictCEC.Default_ = fEditPlaceman.cheStatus.Checked;



                        pPlacementsDistrictCEC.SaveAndFlush();



                    }

                }

                public static void Del(ListViewItem lsvItem)
                {
                    tPlacementsDistrictCEC T = tPlacementsDistrictCEC.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    T.DeleteAndFlush();

                }

                public static void Def(ListViewItem lsvItem)
                {
                    tPlacementsDistrictCEC T = tPlacementsDistrictCEC.byID((int)lsvItem.Tag);

                    if (T == null) return;

                    foreach (var VARIABLE in tPlacementsDistrictCEC.byDistrictCEC(T.tDistrictCEC.ID_DistrictCEC))
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


                    foreach (var VARIABLE in tPlacementsDistrictCEC.byDistrictCEC((int)trn.Tag))
                    {
                        ListViewItem alv;


                        string[] s = new string[4];

                        s[0] = VARIABLE.ShorDistrictCEC;

                        s[1] = cXML.rdShortName(VARIABLE.NameDistrictCEC);

                        s[2] = VARIABLE.Default_.ToString();

                        StringBuilder strContacts = new StringBuilder();
                        strContacts.Append(VARIABLE.Phone + " " + VARIABLE.PhoneMobile);
                        s[3] = strContacts.ToString();
                        alv = new ListViewItem(s);
                        alv.Tag = VARIABLE.ID_PlacementsDistrictCEC;
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
