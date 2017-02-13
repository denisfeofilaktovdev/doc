using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace Placements.Kernel
{
    public partial struct DB
    {
        public delegate Type[] tDb();

        private void InitializeComponent(tDb sDb)
        {

            ActiveRecordStarter.ResetInitializationFlag();

            IDictionary<string, string> properties = new Dictionary<string, string>
            {
                {"connection.driver_class", "NHibernate.Driver.SQLite20Driver"},
                {"dialect", "NHibernate.Dialect.SQLiteDialect"},
                {"connection.provider", "NHibernate.Connection.DriverConnectionProvider"},
                {"connection.connection_string", "Data Source=" + FileDB + ";locked=true"},
                {
                    "proxyfactory.factory_class",
                    @"NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle"
                }
            };



            try
            {

                InPlaceConfigurationSource source = new InPlaceConfigurationSource();
                source.Add(typeof (ActiveRecordBase), properties);

                ActiveRecordStarter.Initialize(source, sDb());


            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }

        }


    }
}
