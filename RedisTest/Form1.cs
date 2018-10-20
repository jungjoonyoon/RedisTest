using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StackExchange.Redis;

namespace RedisTest
{
    public partial class Form1 : Form
    {
        string REDIS_KEY_PREFIX;        
        IDatabase redis_db;
        TimeSpan tsExpire;       

        private void InitComponents()
        {
            REDIS_KEY_PREFIX = ConfigurationManager.AppSettings["RedisKeyPrefix"];            
            int redis_key_days_expire = int.Parse(ConfigurationManager.AppSettings["RedisKeyDaysExpire"]);
            tsExpire = TimeSpan.FromDays(redis_key_days_expire);

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisConnectionString"]);
            redis_db = redis.GetDatabase();
        }
        public Form1()
        {
            InitializeComponent();
            InitComponents();
        }

        private void btnCleanFields_Click(object sender, EventArgs e)
        {
            CleanFields();
        }

        private void CleanFields()
        {
            txtKey.Text = "";
            txtValue.Text = "";
        }

        private void btnSetKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string value = txtValue.Text;

            //redis_db.StringSet(REDIS_KEY_PREFIX + key, value);
            //redis_db.KeyExpire(REDIS_KEY_PREFIX + key, tsExpire);

            redis_db.StringSet(REDIS_KEY_PREFIX + key, value, tsExpire);
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string value = redis_db.StringGet(REDIS_KEY_PREFIX + key);

            txtValue.Text = value;
        }

        private void btnDeleteKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            redis_db.KeyDelete(REDIS_KEY_PREFIX + key);
        }
    }
}
