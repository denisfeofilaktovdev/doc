using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.ActiveRecord;

namespace Placements.Kernel
{
    public partial struct DB
    {
        
            
        private static string FileDB { get; set; }

        private void CreateDB()
        {
            try
            {
                ActiveRecordStarter.CreateSchema();
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.ToString());
            }


        }

        /// <summary>
        /// Создание БД с указанием местонахождения файла и
        /// имени файла
        /// </summary>
        /// <param name="ActualFile">Наименование файла</param>
        /// <param name="sDb">Перечень таблиц.</param>
        public DB(string ActualFile, tDb sDb)
        {
            

            FileDB = ActualFile;
           

            InitializeComponent(sDb);
            CreateDB();

           


        }
        
        /// <summary>
        /// Создание БД без указания имени и местонахождения файла
        /// </summary>
        /// <param name="sDb">Перечень таблиц</param>
        public DB(tDb sDb)
        {

            
            
            FileDB = Application.StartupPath + @"\Database.ebu";

            
            InitializeComponent(sDb);
            CreateDB();

            
        }

        /// <summary>
        /// Открытие БД с командной строки
        /// </summary>
        /// <param name="sDb">Перечень таблиц.</param>
        /// <param name="tmpFile">Имя файла</param>
        public DB OpenFromCMD (string orFile, tDb sDb)
        {



            FileDB = orFile;

            
            InitializeComponent(sDb);
            
            return this;

        }

        
       

        
    }
}
